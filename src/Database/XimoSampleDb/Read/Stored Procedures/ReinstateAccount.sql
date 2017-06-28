CREATE PROCEDURE [Read].[ReinstateAccount]
(
    @accountId UNIQUEIDENTIFIER,
    @sequence INT
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT [EventId]
    INTO [#ReplayTable]
    FROM [Write].[AccountEvents]
    WHERE [AccountEvents].[AggregateId] = @accountId
          AND [AccountEvents].[EventSequence] <= @sequence
          AND [AccountEvents].[Name] NOT IN ( 'XimoSample.DomainEvents.AccountApproved',
                                              'XimoSample.DomainEvents.AccountDeleted',
                                              'XimoSample.DomainEvents.AccountReinstated'
                                            )
    ORDER BY [EventSequence];

    DECLARE @currentEventId UNIQUEIDENTIFIER;
    DECLARE @currentEventName NVARCHAR(200);
    DECLARE @currentEventPayload NVARCHAR(4000);

    WHILE EXISTS (SELECT 1 FROM [#ReplayTable])
    BEGIN

        SET @currentEventId =
        (
            SELECT TOP 1 [#ReplayTable].[EventId] FROM [#ReplayTable]
        );

        SET @currentEventName =
        (
            SELECT [Name]
            FROM [Write].[AccountEvents]
            WHERE [EventId] = @currentEventId
        );

        SET @currentEventPayload =
        (
            SELECT [Payload]
            FROM [Write].[AccountEvents]
            WHERE [Write].[AccountEvents].[EventId] = @currentEventId
        );

        EXEC [Read].[HandleAccountEvent] @eventName = @currentEventName,  -- nvarchar(200)
                                        @payload = @currentEventPayload; -- nvarchar(4000)

        DELETE [#ReplayTable]
        WHERE [EventId] = @currentEventId;

    END;

    DROP TABLE [#ReplayTable];
END;