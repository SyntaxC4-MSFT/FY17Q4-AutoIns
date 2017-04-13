IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[Insert_CRM_Claim]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[Insert_CRM_Claim]
END
go
CREATE PROCEDURE Insert_CRM_Claim
    @VehicleId INT,
    @Description nvarchar(max),
	@DateTime DATETIME,
	@CorrelationId UNIQUEIDENTIFIER,
	@FirstName nvarchar(max),     
    @LastName nvarchar(max),   
    @Street nvarchar(max), 
	@City nvarchar(max), 
	@State nvarchar(max), 
	@Zip nvarchar(max), 
	@DOB DATE, 
	@MobilePhone nvarchar(max), 
	@PolicyId nvarchar(max),
	@PolicyStart DATE,
	@PolicyEnd DATE,
	@DriversLicenseNumber nvarchar(max),
	@LicensePlate nvarchar(max),
	@VIN nvarchar(max),
	@LicensePlateImageUrl nvarchar(max),
	@InsuranceCardImageUrl nvarchar(max),
	@DriversLicenseImageUrl nvarchar(max),
	@ClaimCountByVehicle INT OUTPUT,
	@CustomerEmail nvarchar(max) OUTPUT,
	@CustomerName nvarchar(max) OUTPUT
AS
BEGIN   
  INSERT INTO [CRM].[OtherParties]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[City]
           ,[State]
           ,[Zip]
           ,[DOB]
           ,[MobilePhone]
           ,[PolicyId]
           ,[PolicyStart]
           ,[PolicyEnd]
           ,[DriversLicenseNumber]
           ,[LicensePlate]
           ,[VIN]
           ,[LicensePlateImageUrl]
           ,[InsuranceCardImageUrl]
           ,[DriversLicenseImageUrl])
		VALUES
           (@FirstName
           ,@LastName
           ,@Street
           ,@City
           ,@State
           ,@Zip
           ,@DOB
           ,@MobilePhone
           ,@PolicyId
           ,@PolicyStart
           ,@PolicyEnd
           ,@DriversLicenseNumber
           ,@LicensePlate
           ,@VIN
           ,@LicensePlateImageUrl
           ,@InsuranceCardImageUrl
           ,@DriversLicenseImageUrl)
DECLARE @OtherPartyId INT
SELECT @OtherPartyId = SCOPE_IDENTITY()
INSERT INTO [CRM].[Claims]
           ([VehicleId]
           ,[OtherPartyId]
           ,[DateTime]
           ,[DueDate]
           ,[CorrelationId]
           ,[Status]
           ,[Type]
           ,[DamageAssessment]
           ,[Description])
     VALUES
           (@VehicleId
           ,@OtherPartyId
           ,@DateTime
           ,DATEADD(day,7,@DateTime)
           ,@CorrelationId
           ,0
           ,N'Automobile'
           ,NULL
           ,@Description)
DECLARE @ClaimId INT
SELECT @ClaimId = SCOPE_IDENTITY()
SET @ClaimCountByVehicle = (SELECT COUNT(*) FROM [CRM].[Claims] WHERE VehicleId = @VehicleId)
SET @CustomerName = (SELECT FirstName + ' ' + LastName FROM [CRM].[Customers] WHERE Id = (SELECT CustomerId FROM [CRM].[CustomerVehicles] WHERE Id = @VehicleId))
SET @CustomerEmail = (SELECT Email FROM [CRM].[Customers] WHERE Id = (SELECT CustomerId FROM [CRM].[CustomerVehicles] WHERE Id = @VehicleId))
RETURN @ClaimId
END 