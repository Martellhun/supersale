SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[getParts]
AS
BEGIN
SET NOCOUNT ON

SELECT  p.PartID, p.Name, dpt.Name PartType, p.Price, p.UM, p.SERVICE
FROM dbo.Parts AS p 
INNER JOIN dbo.di_PartTypes AS dpt ON dpt.PartTypeID = p.PartTypeID

RETURN 0
END



GO
