SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getCustomer](@CustomerId Bigint)
AS
BEGIN

SELECT c.CustomerID, c.FirstName, c.LastName, c.Company, c.Email
FROM dbo.Customers AS c
WHERE c.CustomerID = @CustomerId

SELECT c.CarID, b.Name AS Brand, t.Name AS Type, c.Generation AS Gen, c.Engine
FROM dbo.CustomerCars AS cc
INNER JOIN dbo.Cars AS c ON cc.CarID = c.CarID
INNER JOIN dbo.di_Brands AS b ON b.BrandID = c.BrandID
INNER JOIN dbo.di_Types AS t ON t.BrandID=c.BrandID AND t.TypeID = c.TypeID 
WHERE cc.CustomerID = @CustomerId
  

RETURN 0
END
GO
