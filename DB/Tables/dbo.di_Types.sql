CREATE TABLE [dbo].[di_Types]
(
[TypeID] [int] NOT NULL IDENTITY(1, 1),
[BrandID] [bigint] NULL,
[Name] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[di_Types] ADD CONSTRAINT [PK_di_Types_TypeID] PRIMARY KEY CLUSTERED  ([TypeID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Types_BrandID] ON [dbo].[di_Types] ([BrandID]) ON [PRIMARY]
GO
