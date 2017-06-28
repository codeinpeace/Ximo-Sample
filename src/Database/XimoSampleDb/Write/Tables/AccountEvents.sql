CREATE TABLE [Write].[AccountEvents] (
    [EventId]          UNIQUEIDENTIFIER NOT NULL,
    [Name]             NVARCHAR (200)   NOT NULL,
    [AggregateId]      UNIQUEIDENTIFIER NOT NULL,
    [Payload]          NVARCHAR (4000)  NOT NULL,
    [EventSequence]    INT              NOT NULL,
    [CreatedOnUtc]     DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [AggregateVersion] INT              NOT NULL,
    CONSTRAINT [PK_Write.AccountEvents] PRIMARY KEY CLUSTERED ([EventId] ASC)
);




GO
CREATE TRIGGER [Write].[AccountEventInserted]
ON [Write].[AccountEvents]
AFTER INSERT
AS
BEGIN

    SELECT [EventId]
    INTO [#ControlTable]
    FROM [Inserted]
    ORDER BY [Inserted].[EventSequence];

    DECLARE @currentEventId UNIQUEIDENTIFIER;
    DECLARE @currentEventName NVARCHAR(200);
    DECLARE @currentEventPayload NVARCHAR(4000);

    WHILE EXISTS (SELECT 1 FROM [#ControlTable])
    BEGIN

        SET @currentEventId =
        (
            SELECT TOP 1 [#ControlTable].[EventId] FROM [#ControlTable]
        );

        SET @currentEventName =
        (
            SELECT [Name] FROM [Inserted] WHERE [Inserted].[EventId] = @currentEventId
        );

        IF (@currentEventName = 'XimoSample.DomainEvents.AccountReinstated')
        BEGIN

            DECLARE @currentAccountId UNIQUEIDENTIFIER;
            DECLARE @currentSequence INT;

            SELECT @currentAccountId = [Inserted].[AggregateId],
                   @currentSequence = [Inserted].[EventSequence]
            FROM [Inserted]
            WHERE [Inserted].[EventId] = @currentEventId;

            EXEC [Read].[ReinstateAccount] @accountId = @currentAccountId, -- uniqueidentifier
                                          @sequence = @currentSequence;   -- int
        END;
        ELSE
        BEGIN

            SET @currentEventPayload =
            (
                SELECT [Payload]
                FROM [Inserted]
                WHERE [Inserted].[EventId] = @currentEventId
            );

            EXEC [Read].[HandleAccountEvent] @eventName = @currentEventName,  -- nvarchar(200)
                                            @payload = @currentEventPayload; -- nvarchar(4000)

        END;

        DELETE [#ControlTable]
        WHERE [EventId] = @currentEventId;
    END;

    DROP TABLE [#ControlTable];

END;