SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getWarrantyTypes]
AS
BEGIN
	SELECT spt.ServicePackTypeID, spt.Name AS ServiceName, pt.PartTypeID, pt.Name AS PartTypeName,
	wt.LengthInYears AS Years
	FROM dbo.WarrantyTypes AS wt
	INNER JOIN dbo.di_ServicePackTypes AS spt ON spt.ServicePackTypeID = wt.ServicePackTypeID
	INNER JOIN dbo.di_PartTypes AS pt ON pt.PartTypeID = wt.AssociatedPartType
RETURN 0
END
GO
