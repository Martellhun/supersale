SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[setCustomer] (@CustomerID BIGINT, @FirstName VARCHAR(20), @LastName VARCHAR(20), @Company VARCHAR(30), @Email VARCHAR(50))
AS
BEGIN

	UPDATE dbo.Customers
	SET	FirstName = @FirstName,
		LastName  = @LastName,
		Company   = @Company,
		Email     = @Email
	WHERE CustomerID = @CustomerID

RETURN 0
END
GO
