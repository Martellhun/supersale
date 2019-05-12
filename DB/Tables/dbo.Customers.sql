CREATE TABLE [dbo].[Customers]
(
[CustomerID] [bigint] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Company] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers_CustomerID] PRIMARY KEY CLUSTERED  ([CustomerID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Customers_LastName_FirstName] ON [dbo].[Customers] ([LastName], [FirstName]) INCLUDE ([Company], [Email]) ON [PRIMARY]
GO
