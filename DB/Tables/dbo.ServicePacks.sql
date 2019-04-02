CREATE TABLE [dbo].[ServicePacks]
(
[ServicePackID] [bigint] NOT NULL IDENTITY(1, 1),
[CarID] [tinyint] NOT NULL,
[ServicePackTypeID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ServicePacks] ADD CONSTRAINT [PK_ServicePacks_ServicePackID] PRIMARY KEY CLUSTERED  ([ServicePackID]) ON [PRIMARY]
GO
