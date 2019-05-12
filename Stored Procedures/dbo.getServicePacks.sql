SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getServicePacks]
AS
BEGIN
	SELECT sp.ServicePackID, b.Name BrandName, t.Name CartypeName, spt.Name ServiceTypeName
	, c.GENERATION Generation, c.Engine 
	FROM dbo.ServicePacks AS sp
	INNER JOIN dbo.di_ServicePackTypes AS spt ON spt.ServicePackTypeID = sp.ServicePackTypeID
	INNER JOIN dbo.Cars AS c ON c.CarID = sp.CarID
	INNER JOIN dbo.di_Brands AS b ON b.BrandID = c.BrandID
	INNER JOIN dbo.di_Types AS t ON t.TypeID = c.TypeID
RETURN 0
END
GO
