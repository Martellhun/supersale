CREATE TABLE [dbo].[Cars]
(
[CarID] [bigint] NOT NULL IDENTITY(1, 1),
[BrandID] [bigint] NOT NULL,
[TypeID] [int] NOT NULL,
[Engine] [int] NULL,
[GENERATION] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars] ADD CONSTRAINT [PK_Cars_CarID] PRIMARY KEY CLUSTERED  ([CarID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Cars_BrandID] ON [dbo].[Cars] ([BrandID], [CarID]) ON [PRIMARY]
GO
