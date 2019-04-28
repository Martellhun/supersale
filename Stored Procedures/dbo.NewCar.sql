SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[NewCar]
@BrandName varchar(25),
@Typename VARCHAR(25),
@Generation VARCHAR(5),
@Engine INT,
@CarID BIGINT = NULL OUTPUT
AS
BEGIN
	
	DECLARE @BrandID BIGINT
	DECLARE @TypeId INT 

    SELECT @BrandID = BrandID FROM dbo.di_Brands AS db WHERE db.Name = @BrandName 
	IF @BrandID IS NULL 
	BEGIN
		INSERT INTO dbo.di_Brands (Name)
		SELECT @BrandName

		SET @BrandID = SCOPE_IDENTITY()
	END

	SELECT @TypeId = dt.TypeID FROM dbo.di_Types AS dt WHERE dt.BrandID = @BrandID AND dt.Name = @Typename
	IF @TypeId IS NULL
	BEGIN
		INSERT INTO dbo.di_Types (BrandID, Name)
		SELECT @BrandID, @Typename

		SET @TypeId = SCOPE_IDENTITY()
	END

	INSERT INTO dbo.Cars (BrandID, TypeID, Generation, Engine)
	SELECT @BrandID, @TypeId, @Generation, @Engine
	WHERE NOT EXISTS (SELECT 1 FROM dbo.Cars AS c WHERE c.BrandID = @BrandID AND c.TypeID = @TypeId AND c.Generation = @Generation AND c.Engine = @Engine)

	SET @CarID = SCOPE_IDENTITY()

RETURN 0
END
GO
