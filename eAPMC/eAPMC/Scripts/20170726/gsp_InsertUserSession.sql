
GO
 -- 1 -- 
 -- gsp_InsertUserSession -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_InsertUserSession]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_InsertUserSession]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE gsp_InsertUserSession
	-- Add the parameters for the stored procedure here
	@LoginName varchar(100),
	@LocalMachineName varchar(100),
	@LocalMachineIP varchar(100),
	@LocalUserName varchar(100),
	@RemoteMachineName varchar(100),
	@RemoteMachineIP varchar(100),
	@RemoteUserName varchar(100),
	@Domain varchar(100),
	@ClientProcessID numeric(18, 0),
	@LoginSessionID numeric(18,0)=0 Output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @dtgloDate DateTime
	Declare @UserID numeric(18,0)

	Select @dtgloDate = GETDATE();

	
	Select @UserID= (select UserId from dbo.Users where LoginName = @LoginName)

	Set @LoginSessionID = dbo.GetUniqueID_V2()
	
	INSERT INTO	dbo.UsersSessions
	(
	    SessionId,
	    UserId,
	    LoginName,
	    LocalMachineName,
	    LocalMachineIP,
	    LocalUserName,
	    RemoteMachineName,
	    RemoteMachineIP,
	    RemoteUserName,
	    Domain,
	    ClientProcessID,
	    LoginDate
	)
	VALUES
	(
	    @LoginSessionID, -- SessionId - bigint
	    @UserID, -- UserId - bigint
	    @LoginName, -- LoginName - varchar
	    @LocalMachineName, -- LocalMachineName - varchar
	    @LocalMachineIP, -- LocalMachineIP - varchar
	    @LocalUserName, -- LocalUserName - varchar
	    @RemoteMachineName, -- RemoteMachineName - varchar
	    @RemoteMachineIP, -- RemoteMachineIP - varchar
	    @RemoteUserName, -- RemoteUserName - varchar
	    @Domain, -- Domain - varchar
	    @ClientProcessID, -- ClientProcessID - int
	    @dtgloDate -- LoginDate - datetime
	)

	--Insert into loginsession(LoginSessionID,sLoginName,LocalMachineName,LocalMachineIP,LocalUserName,RemoteMachineName,
	--RemoteMachineIP,RemoteUserName,Domain,ClientProcessID,LoginDate,UserID,SoftwareComponent,ClinicID)
	--Values(@LoginSessionID,@sLoginName,@LocalMachineName,@LocalMachineIP,@LocalUserName,@RemoteMachineName,@RemoteMachineIP,
	--@RemoteUserName,@Domain,@ClientProcessID,@dtgloDate,@UserID,@SoftwareComponent,@ClinicID)
END

