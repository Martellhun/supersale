CREATE TABLE [dbo].[Orderitems]
(
[OrderItemID] [bigint] NOT NULL IDENTITY(1, 1),
[OrderID] [bigint] NOT NULL,
[PartID] [bigint] NOT NULL,
[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orderitems] ADD CONSTRAINT [PK_OrderItems_OrderItemID] PRIMARY KEY CLUSTERED  ([OrderItemID]) ON [PRIMARY]
GO
