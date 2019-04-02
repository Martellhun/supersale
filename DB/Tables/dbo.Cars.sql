CREATE TABLE [dbo].[Cars]
(
[CarID] [bigint] NOT NULL IDENTITY(1, 1),
[BrandID] [tinyint] NOT NULL,
[TypeID] [tinyint] NOT NULL,
[Generation] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Engine] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars] ADD CONSTRAINT [PK_Cars_CarID] PRIMARY KEY CLUSTERED  ([CarID]) ON [PRIMARY]
GO
