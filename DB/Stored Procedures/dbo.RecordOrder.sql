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
	@CarID BIGINT,
	@ServicePackType INT,
	@Parts PartList READONLY,
	@TotalPrice DECIMAL(13,2)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @now DATETIME = GETUTCDATE()
		   ,@OrderNumber BIGINT

	INSERT INTO dbo.Orders (CustomerID, SoldBy, TotalPrice, RecordedAt)
	SELECT @CustomerID, @UserID, @TotalPrice, @now

	SET @OrderNumber = SCOPE_IDENTITY() 

	INSERT INTO dbo.OrderItems (OrderID, PartID, Quantity, NetPrice, Tax)
	SELECT @OrderNumber, p.PartID, p.Quantity, p2.Price, (p2.Price * 0.27) -- Dont do this
	FROM @Parts p
	INNER JOIN dbo.Parts AS p2 ON p2.PartID = p.PartID

	IF EXISTS (SELECT 1 FROM dbo.WarrantyTypes wt WHERE wt.ServicePackTypeID = @ServicePackType)
	BEGIN
		INSERT INTO dbo.Warranties (CarID, CustomerID, PartTypeID, StartDate, EndDate, Status)
		SELECT @CarID, @CustomerID, AssociatedPartType, @now, DATEADD(yy, wt.LengthInYears, @now), 1 -- active
		FROM dbo.WarrantyTypes wt
		WHERE wt.ServicePackTypeID = @ServicePackType
	END

	/*
	OR Try this one too, what happens when there are more than one warranties
	INSERT INTO dbo.Warranties (CarID, CustomerID, PartTypeID, StartDate, EndDate, Status)
	SELECT @CarID, @CustomerID, AssocietadPartType, @now, DATEADD(yy, wt.LengthInYears, @now), 1 -- active
	FROM dbo.WarrantyTypes wt
	WHERE wt.ServicePackTypeID = @ServicePackType
	*/
	RETURN 0

END


GO
