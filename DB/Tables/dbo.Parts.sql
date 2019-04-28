CREATE TABLE [dbo].[Parts]
(
[PartID] [bigint] NOT NULL IDENTITY(1, 1),
[PartTypeID] [tinyint] NULL,
[Price] [decimal] (13, 2) NOT NULL,
[UM] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SERVICE] [bit] NOT NULL,
[Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parts] ADD CONSTRAINT [PK_Parts_PartID] PRIMARY KEY CLUSTERED  ([PartID]) ON [PRIMARY]
GO
