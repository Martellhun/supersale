SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- =============================================
-- Author:		Máté Rudasi
-- Create date: 2019-03-10
-- Description:	This sp can be called when you want to add or modify a package
-- =============================================
CREATE PROCEDURE [dbo].[UpsertRecipe]
	@ServicePackType INT,
	@CarID BIGINT,
	@Parts PartList READONLY
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ServicePackID BIGINT

	IF( @ServicePackType IS NULL
		OR @CarID IS NULL
		OR NOT EXISTS (SELECT 1 FROM @Parts p)
	) RETURN 1

	SELECT @ServicePackID = sp.ServicePackID FROM dbo.ServicePacks sp WITH(NOLOCK) WHERE sp.ServicePackTypeID = @ServicePackType AND sp.CarID = @CarID
	IF (@ServicePackID IS NULL) 
	BEGIN
	INSERT INTO dbo.ServicePacks (ServicePackTypeID, CarID)
	SELECT @ServicePackType, @CarID	

	SET @ServicePackID = SCOPE_IDENTITY()
	END

	MERGE dbo.Recipes AS target  
    USING (SELECT p.PartID, p.Quantity, @ServicePackID FROM @Parts p) AS source ( Part, Qty, ServicePackID )  
    ON ( target.ServicePackID = source.ServicePackID AND target.PartID = source.Part )  
    WHEN MATCHED THEN -- Update existing part
        UPDATE SET Quantity = source.Qty
	WHEN NOT MATCHED BY TARGET THEN  -- Insert not existing parts
		INSERT (ServicePackID, PartID, Quantity)  
		VALUES (source.ServicePackID, source.Part, source.Qty )  
	OUTPUT $action, Deleted.RecipeID, Deleted.ServicePackID, Deleted.PartID, Deleted.Quantity
				  , Inserted.RecipeID, Inserted.ServicePackID, Inserted.PartID, Inserted.Quantity;

	RETURN 0
	
END
GO
