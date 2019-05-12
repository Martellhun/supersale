SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[searchCustomers](@Firstname VARCHAR(20), @Lastname VARCHAR(20), @WithWildCard BIT)
AS
BEGIN

  IF (@Lastname = '') 
  RETURN 1

  IF @WithWildCard	= 0
  BEGIN
	IF @Firstname = '' 
		BEGIN
		SELECT c.CustomerID, c.Firstname, c.Lastname, c.Company, c.Email
		FROM dbo.Customers AS c
		WHERE c.LastName = @Lastname
		END
	ELSE
		SELECT c.CustomerID, c.Firstname, c.Lastname, c.Company, c.Email
		FROM dbo.Customers AS c
		WHERE c.LastName = @Lastname AND c.FirstName = @Firstname
  END
  ELSE
  BEGIN
	SELECT c.CustomerID, c.Firstname, c.Lastname, c.Company, c.Email
	FROM dbo.Customers AS c
	WHERE c.LastName LIKE @Lastname+'%' AND c.FirstName LIKE @Firstname+'%'
  END

RETURN 0
END
GO
