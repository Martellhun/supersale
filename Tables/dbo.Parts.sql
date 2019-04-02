CREATE TABLE [dbo].[Parts]
(
[PartID] [bigint] NOT NULL IDENTITY(1, 1),
[PartType] [int] NULL,
[Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Price] [decimal] (13, 2) NOT NULL,
[UM] [varchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SERVICE] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parts] ADD CONSTRAINT [PK_Parts_PartID] PRIMARY KEY CLUSTERED  ([PartID]) ON [PRIMARY]
GO
