CREATE TABLE [dbo].[di_ServicePackTypes]
(
[ServicePackTypeID] [int] NOT NULL,
[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[di_ServicePackTypes] ADD CONSTRAINT [PK_di_ServicePackTypes_ServicePackTypeID] PRIMARY KEY CLUSTERED  ([ServicePackTypeID]) ON [PRIMARY]
GO
