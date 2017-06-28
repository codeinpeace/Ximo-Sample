CREATE PROCEDURE [Read].[HandleAccountEvent]
(
    @eventName NVARCHAR(200),
    @payload NVARCHAR(4000)
)
AS
BEGIN

    SET NOCOUNT ON;

    IF (@eventName = 'XimoSample.DomainEvents.AccountCreated')
    BEGIN

        INSERT INTO [Read].[AccountDetailsView]
        (
            [AccountId],
            [AccountNumber],
            [BusinessName]
        )
        SELECT [jsonPayload].[AccountId],
               [jsonPayload].[AccountNumber],
               [jsonPayload].[BusinessName]
        FROM
            OPENJSON(@payload)
            WITH
            (
                [AccountId] UNIQUEIDENTIFIER,
                [AccountNumber] INT,
                [BusinessName] NVARCHAR(100)
            ) AS [jsonPayload];

    END;
    IF (@eventName = 'XimoSample.DomainEvents.SystemTagAdded')
    BEGIN

        INSERT INTO [Read].[SystemTagView]
        (
            [AccountId],
            [Name],
            [AppliesToExpenses],
            [AppliesToTimesheets]
        )
        SELECT [jsonPayload].[AccountId],
               [jsonPayload].[Name],
               [jsonPayload].[AppliesToExpenses],
               [jsonPayload].[AppliesToTimesheets]
        FROM
            OPENJSON(@payload)
            WITH
            (
                [AccountId] UNIQUEIDENTIFIER,
                [Name] NVARCHAR(MAX),
                [AppliesToExpenses] BIT,
                [AppliesToTimesheets] BIT
            ) AS [jsonPayload];

    END;
    ELSE IF (@eventName = 'XimoSample.DomainEvents.AddressUpdated')
    BEGIN

        UPDATE [Read].[AccountDetailsView]
        SET [AccountDetailsView].[AddressLine1] = [jsonPayload].[AddressLine1],
            [AccountDetailsView].[AddressLine2] = [jsonPayload].[AddressLine2],
            [AccountDetailsView].[City] = [jsonPayload].[City],
            [AccountDetailsView].[Postcode] = [jsonPayload].[Postcode],
            [AccountDetailsView].[State] = [jsonPayload].[State],
            [AccountDetailsView].[CountryName] = [jsonPayload].[CountryName]
        FROM
            OPENJSON(@payload)
            WITH
            (
                [AccountId] UNIQUEIDENTIFIER,
                [AddressLine1] NVARCHAR(100),
                [AddressLine2] NVARCHAR(100),
                [City] NVARCHAR(100),
                [Postcode] NVARCHAR(12),
                [State] NVARCHAR(100),
                [CountryName] NVARCHAR(100)
            ) AS [jsonPayload]
        WHERE [AccountDetailsView].[AccountId] = [jsonPayload].[AccountId];

    END;
    ELSE IF (@eventName = 'XimoSample.DomainEvents.AccountApproved')
    BEGIN

        UPDATE [Read].[AccountDetailsView]
        SET [AccountDetailsView].[IsApproved] = 1,
            [AccountDetailsView].[ApprovedBy] = [jsonPayload].[ApprovedBy]
        FROM
            OPENJSON(@payload)
            WITH
            (
                [AccountId] UNIQUEIDENTIFIER,
                [ApprovedBy] NVARCHAR(100)
            ) AS [jsonPayload]
        WHERE [AccountDetailsView].[AccountId] = [jsonPayload].[AccountId];

    END;
    ELSE IF (@eventName = 'XimoSample.DomainEvents.AccountDeleted')
    BEGIN
        DECLARE @accountId UNIQUEIDENTIFIER;

        SELECT @accountId = [jsonPayload].[AccountId]
        FROM
            OPENJSON(@payload)
            WITH
            (
                [AccountId] UNIQUEIDENTIFIER
            ) AS [jsonPayload];

        DELETE [Read].[AccountDetailsView]
        WHERE [AccountDetailsView].[AccountId] = @accountId;

        DELETE [Read].[SystemTagView]
        WHERE [SystemTagView].[AccountId] = @accountId;
    END;

END;