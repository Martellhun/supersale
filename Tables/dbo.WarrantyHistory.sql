CREATE TABLE [dbo].[WarrantyHistory]
(
[WarrantyHistoryID] [bigint] NOT NULL IDENTITY(1, 1),
[WarrantyID] [bigint] NOT NULL,
[OrderItemID] [bigint] NOT NULL,
[CustomerID] [bigint] NOT NULL,
[CustomerCarID] [bigint] NOT NULL,
[PartTypeID] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[Status] [tinyint] NOT NULL,
[RecordedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WarrantyHistory] ADD CONSTRAINT [PK_WarrantyHistory_WarrantyHistoryID] PRIMARY KEY CLUSTERED  ([WarrantyID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_WarrantyHistory_WarrantyID] ON [dbo].[WarrantyHistory] ([WarrantyID]) ON [PRIMARY]
GO
