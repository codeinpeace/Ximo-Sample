CREATE TABLE [Read].[SystemTagView] (
    [SystemTagId]         INT              IDENTITY (1, 1) NOT NULL,
    [AccountId]           UNIQUEIDENTIFIER NOT NULL,
    [Name]                NVARCHAR (MAX)   NULL,
    [AppliesToExpenses]   BIT              NOT NULL,
    [AppliesToTimesheets] BIT              NOT NULL,
    CONSTRAINT [PK_Read.SystemTagView] PRIMARY KEY CLUSTERED ([SystemTagId] ASC)
);

