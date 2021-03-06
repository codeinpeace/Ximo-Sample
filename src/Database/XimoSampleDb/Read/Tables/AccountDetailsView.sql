﻿CREATE TABLE [Read].[AccountDetailsView] (
    [AccountId]     UNIQUEIDENTIFIER NOT NULL,
    [AccountNumber] INT              NOT NULL,
    [BusinessName]  NVARCHAR (100)   NOT NULL,
    [AddressLine1]  NVARCHAR (100)   NULL,
    [AddressLine2]  NVARCHAR (100)   NULL,
    [City]          NVARCHAR (100)   NULL,
    [Postcode]      NVARCHAR (12)    NULL,
    [State]         NVARCHAR (100)   NULL,
    [CountryName]   NVARCHAR (100)   NULL,
    [IsApproved]    BIT              CONSTRAINT [DF_AccountDetailsView_IsApproved] DEFAULT ((0)) NOT NULL,
    [ApprovedBy]    NVARCHAR (100)   NULL,
    CONSTRAINT [PK_Read.AccountDetailsView] PRIMARY KEY CLUSTERED ([AccountId] ASC)
);

