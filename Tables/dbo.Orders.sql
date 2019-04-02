CREATE TABLE [dbo].[Orders]
(
[OrderID] [bigint] NOT NULL IDENTITY(1, 1),
[CustomerID] [bigint] NULL,
[SoldBy] [bigint] NOT NULL,
[TotalPrice] [decimal] (13, 2) NOT NULL,
[RecordedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders_OrderID] PRIMARY KEY CLUSTERED  ([OrderID]) ON [PRIMARY]
GO
