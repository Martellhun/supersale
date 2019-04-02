CREATE TABLE [dbo].[CarParts]
(
[ConnectionID] [bigint] NOT NULL IDENTITY(1, 1),
[CarID] [bigint] NOT NULL,
[PartID] [bigint] NOT NULL,
[TypeID] [tinyint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarParts] ADD CONSTRAINT [PK_CarParts_ConnectionID] PRIMARY KEY CLUSTERED  ([ConnectionID]) ON [PRIMARY]
GO
