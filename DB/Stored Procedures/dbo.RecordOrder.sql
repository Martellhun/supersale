SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Máté Rudasi
-- Create date: 2019-03-10
-- Description:	This sp can be called when you want to create a new order
-- =============================================
CREATE PROCEDURE [dbo].[RecordOrder]
	@UserID BIGINT,
	@CustomerID BIGINT,
	@CustomerCarID BIGINT,
	@ServicePackIDList IdList READONLY,
	@Parts PartList READONLY,
	@TotalPrice DECIMAL(13,2)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @now DATETIME = GETUTCDATE()
		   ,@OrderNumber BIGINT
	
	DECLARE @localParts AS TABLE (
		PartID BIGINT,
		Quantity INT,
		ServicePackID BIGINT,
		OrderItemID BIGINT	
	) 

	DECLARE @ServicePacksAndOrderItems AS TABLE (
		ServicePackID BIGINT,
		OrderItemID BIGINT
	)

	INSERT INTO @localParts (PartID, Quantity, ServicePackID)
	SELECT p.PartID, p.Quantity, NULL
	FROM @Parts AS p

	INSERT INTO @localParts (PartID, Quantity, ServicePackID)
	SELECT r.PartID, r.Quantity, spil.ID
	FROM dbo.Recipes AS r
	INNER JOIN @ServicePackIDList AS spil ON spil.ID = r.ServicePackID

	IF NOT EXISTS (SELECT 1 FROM @localParts AS p) RETURN 

	INSERT INTO dbo.Orders (CustomerID, SoldBy, TotalPrice, RecordedAt)
	SELECT @CustomerID, @UserID, @TotalPrice, @now

	SET @OrderNumber = SCOPE_IDENTITY() 

	MERGE dbo.OrderItems AS Target
	USING (
	SELECT @OrderNumber, p.PartID, p.Quantity, p2.Price, (p2.Price * 0.27), p.ServicePackID 
	FROM @localParts AS p
	INNER JOIN dbo.Parts AS p2 ON p2.PartID = p.PartID
	) AS Source (OrderID, PartID, Quantity, Price, Tax, ServicePackID) ON (1 = 2)
	WHEN NOT MATCHED THEN
	INSERT (OrderID, PartID, Quantity, NetPrice, Tax)
	VALUES (Source.OrderID, Source.PartID, Source.Quantity, Source.Price, Source.Tax)
	OUTPUT Inserted.OrderItemID, Source.ServicePackID INTO @ServicePacksAndOrderItems;

	IF EXISTS (SELECT 1 FROM dbo.WarrantyTypes wt INNER JOIN @ServicePackIDList AS spil ON spil.TypeID = wt.ServicePackTypeID)
	BEGIN
		INSERT INTO dbo.Warranties (CustomerCarID, OrderItemID, CustomerID, PartTypeID, StartDate, EndDate, Status)
		OUTPUT Inserted.WarrantyID,Inserted.CustomerCarID, Inserted.OrderItemID, Inserted.CustomerID, Inserted.PartTypeID, Inserted.StartDate, Inserted.EndDate, Inserted.Status, @now
		INTO dbo.WarrantyHistory (WarrantyID, CustomerCarID, OrderItemID, CustomerID, PartTypeID, StartDate, EndDate, Status, RecordedAt)
		SELECT @CustomerCarID, spaoi.OrderItemID, @CustomerID, AssociatedPartType, @now, DATEADD(yy, wt.LengthInYears, @now), 1 -- active
		FROM dbo.WarrantyTypes wt
		INNER JOIN @ServicePackIDList AS spil ON wt.ServicePackTypeID = spil.TypeID
		INNER JOIN @ServicePacksAndOrderItems AS spaoi ON spaoi.ServicePackID = spil.ID		
	END

	/*
	OR Try this one too, what happens when there is no warranty, without if
	INSERT INTO dbo.Warranties (CarID, CustomerID, PartTypeID, StartDate, EndDate, Status)
	SELECT @CarID, @CustomerID, AssocietadPartType, @now, DATEADD(yy, wt.LengthInYears, @now), 1 -- active
	FROM dbo.WarrantyTypes wt
	WHERE wt.ServicePackTypeID = @ServicePackType
	*/
	RETURN 0

END


GO
