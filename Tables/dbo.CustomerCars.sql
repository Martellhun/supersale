CREATE TABLE [dbo].[CustomerCars]
(
[CustomerCarID] [bigint] NOT NULL IDENTITY(1, 1),
[CustomerID] [bigint] NOT NULL,
[CarID] [bigint] NOT NULL,
[Manufactured] [date] NOT NULL,
[LastServiced] [smalldatetime] NULL,
[RecordedAt] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerCars] ADD CONSTRAINT [PK_CustomerCars_CustomerCarsID] PRIMARY KEY CLUSTERED  ([CustomerCarID]) ON [PRIMARY]
GO
