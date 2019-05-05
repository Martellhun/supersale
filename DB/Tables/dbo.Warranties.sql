CREATE TABLE [dbo].[Warranties]
(
[WarrantyID] [bigint] NOT NULL IDENTITY(1, 1),
[OrderItemID] [bigint] NOT NULL,
[CustomerID] [bigint] NOT NULL,
[CustomerCarID] [bigint] NOT NULL,
[PartTypeID] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[Status] [tinyint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Warranties] ADD CONSTRAINT [PK_Warranties_WarrantyID] PRIMARY KEY CLUSTERED  ([WarrantyID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Warranties_CustomerID_Status] ON [dbo].[Warranties] ([CustomerID], [Status]) WHERE ([status]=(1)) ON [PRIMARY]
GO
