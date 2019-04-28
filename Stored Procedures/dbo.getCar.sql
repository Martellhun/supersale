SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getCar]
@BrandID BIGINT = NULL
AS
BEGIN
SET NOCOUNT ON

SELECT c.CarID, b.Name AS Brand, t.Name AS Type, c.Generation AS Gen, c.Engine
FROM dbo.Cars AS c
INNER JOIN dbo.di_Brands AS b ON b.BrandID = c.BrandID
INNER JOIN dbo.di_Types AS t ON t.BrandID=c.BrandID AND t.TypeID = c.TypeID
WHERE (c.BrandID = @BrandID OR @BrandID IS NULL)

RETURN 0
END
GO
