CREATE TABLE [dbo].[CarParts]
(
[CarID] [bigint] NOT NULL,
[PartID] [bigint] NOT NULL,
[PartTypeID] [tinyint] NULL
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [ix_Carparts_CarID_TypeID] ON [dbo].[CarParts] ([CarID], [PartTypeID]) ON [PRIMARY]
GO
