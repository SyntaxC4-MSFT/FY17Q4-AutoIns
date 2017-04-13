IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[Insert_Mobile_Claim]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[Insert_Mobile_Claim]
END
go
create  PROCEDURE Insert_Mobile_Claim
(
@claimId  [nvarchar](128),
@userId [nvarchar](255),
@vehicleId int,
@OtherPartyMobilePhone [nvarchar](max),
@Description [nvarchar](max)
)
AS
BEGIN
insert into [Mobile].[Claims](Id,UserId,VehicleId,Coordinates,[DateTime],OtherPartyMobilePhone,[Description],Deleted)
	values(@claimId,@userId,@vehicleId,geography::Point(47.608013, -122.335167, 4326), getdate(),@OtherPartyMobilePhone,@Description,0)
END
