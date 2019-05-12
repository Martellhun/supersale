SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getRecipes]	( @ServicePackID BIGINT )
AS
BEGIN
	SELECT r.Quantity, p.UM, p.Name PartName, spt.Name ServiceName
	FROM dbo.ServicePacks AS sp
	INNER JOIN dbo.Recipes AS r ON r.ServicePackID = sp.ServicePackID
	INNER JOIN dbo.di_ServicePackTypes AS spt ON spt.ServicePackTypeID = sp.ServicePackTypeID
	INNER JOIN dbo.Parts AS p ON p.PartID = r.PartID
	WHERE sp.ServicePackID = @ServicePackID
RETURN 0
END
GO
