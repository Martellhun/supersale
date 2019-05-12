SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[newWarrantyType] (@ServicePackTypeID INT, @PartTypeID INT, @LengthInYears INT)
AS
BEGIN
	INSERT INTO dbo.WarrantyTypes (ServicePackTypeID, AssociatedPartType, LengthInYears)
	SELECT @ServicePackTypeID, 	@PartTypeID,  @LengthInYears
END
GO
