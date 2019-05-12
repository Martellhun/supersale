SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[newCustomer] (@FirstName NVARCHAR(20), @LastName NVARCHAR(20), @Company NVARCHAR(30), @Email NVARCHAR(50))
AS
BEGIN

	INSERT INTO dbo.Customers (FirstName, LastName, Company, Email)
	SELECT @FirstName, @LastName, @Company, @Email

RETURN 0
END
GO
