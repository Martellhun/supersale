CREATE TABLE [dbo].[Customers]
(
[CustomerID] [bigint] NOT NULL,
[FirstName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Company] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers_CustomerID] PRIMARY KEY CLUSTERED  ([CustomerID]) ON [PRIMARY]
GO
