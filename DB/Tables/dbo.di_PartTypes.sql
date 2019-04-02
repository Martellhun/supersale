CREATE TABLE [dbo].[di_PartTypes]
(
[PartTypeID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[di_PartTypes] ADD CONSTRAINT [PK_di_PartTypes_PartTypeID] PRIMARY KEY CLUSTERED  ([PartTypeID]) ON [PRIMARY]
GO
