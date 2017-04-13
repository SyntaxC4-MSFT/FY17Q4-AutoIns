-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetClaimCountByVehicle
    @VehicleId INT 
AS
BEGIN   
DECLARE @ClaimCount INT
SET @ClaimCount = (SELECT COUNT(*) FROM [CRM].[Claims] WHERE VehicleId = @VehicleId)
RETURN @ClaimCount
END 
