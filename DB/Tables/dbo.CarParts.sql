CREATE TABLE [dbo].[CarParts]
(
[CarID] [bigint] NOT NULL,
[PartID] [bigint] NOT NULL,
[PartTypeID] [tinyint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarParts] ADD CONSTRAINT [PK_CarParts_CarID_PartID] PRIMARY KEY CLUSTERED  ([CarID], [PartID]) ON [PRIMARY]
GO
