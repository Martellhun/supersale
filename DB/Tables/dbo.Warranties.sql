CREATE TABLE [dbo].[Warranties]
(
[WarrantyID] [bigint] NOT NULL IDENTITY(1, 1),
[CustomerID] [bigint] NOT NULL,
[CarID] [bigint] NOT NULL,
[PartTypeID] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[Status] [tinyint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Warranties] ADD CONSTRAINT [PK_Warranties_WarrantyID] PRIMARY KEY CLUSTERED  ([WarrantyID]) ON [PRIMARY]
GO
