SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getParts]
@CarID BIGINT,
@PartTypeID TINYINT
AS
BEGIN
SET NOCOUNT ON
IF @CarID IS NULL RETURN 1

SELECT c.CarID, db.Name, dt.Name, c.Generation, c.Engine, p.Name, dpt.Name,p.UM, p.Price
FROM dbo.Cars AS c
INNER JOIN dbo.di_Brands AS db ON db.BrandID = c.BrandID
INNER JOIN dbo.di_Types AS dt ON dt.BrandID=c.BrandID AND dt.TypeID = c.TypeID
INNER JOIN dbo.CarParts AS cp ON cp.CarID = c.CarID
INNER JOIN dbo.Parts AS p ON p.PartID = cp.PartID
INNER JOIN dbo.di_PartTypes AS dpt ON dpt.PartTypeID = p.PartTypeID
WHERE c.CarID = @CarID AND (@PartTypeID IS NULL OR p.PartTypeID = @PartTypeID)

RETURN 0
END
GO
