
GO
 -- 1 -- 
 -- gsp_RemovePerson -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_RemovePerson]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_RemovePerson]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE gsp_RemovePerson
	-- Add the parameters for the stored procedure here
	@PersonID numeric(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	   
        
	   DELETE FROM dbo.PersonAddress WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonContact WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonPhoto WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonDLID WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonIDCard WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonOtherID WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonPAN WHERE PersonId=@PersonID
	   DELETE FROM dbo.PersonUID WHERE PersonId=@PersonID
	   DELETE FROM dbo.Person WHERE PersonId=@PersonID
END


GO
 -- 2 -- 
 -- gsp_GetUserDetails -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetUserDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetUserDetails]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE gsp_GetUserDetails 
	-- Add the parameters for the stored procedure here
	@sLoginName varchar(20)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF ISNULL(@sLoginName,'')=''
	BEGIN
     	SELECT * FROM dbo.Users AS U	
     END
     ELSE
     BEGIN
     	SELECT * FROM dbo.Users AS U WHERE U.LoginName=@sLoginName
     END
END


GO
 -- 3 -- 
 -- gsp_AddPerson -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_AddPerson]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_AddPerson]

GO


CREATE PROCEDURE [dbo].[gsp_AddPerson](
	  @udtPerson                    dbo.Person_UDT READONLY,
	  @udtPersonCards               dbo.Person_Cards READONLY,
	  @udtPersonContacts            dbo.Person_Contacts READONLY,
	  @udtPersonVerificationDetails dbo.Person_VerificationDetails READONLY,
	  @udtPersonPhotoDetails        dbo.Person_PhotoDetails READONLY,
	  @udtPersonAddressDetails      dbo.Person_AddressDetails READONLY
	  )
AS
	BEGIN

	    BEGIN TRY

		   BEGIN TRANSACTION AddPerson;

		   IF
		   (
			  SELECT COUNT([PersonId]) AS [Cnt]
			  FROM   @udtPerson
		   ) > 0
			  BEGIN

				 DECLARE
					   @RegistrationId AS BIGINT = NULL;
				 SET @RegistrationId = dbo.GetUniqueID_V2();
				 DECLARE
					   @dtCreatedOn AS DATETIME;
				 DECLARE
					   @dtLastModifiedOn AS DATETIME;

				 SET @dtCreatedOn =
				 (
					SELECT GETDATE()
				 );
				 SET @dtLastModifiedOn = @dtCreatedOn;
				 
				 INSERT INTO dbo.Person
				 ([PersonId],
				  [Code],
				  [FirstName],
				  [MiddleName],
				  [LastName],
				  [OrganizationName],
				  [Gender],
				  [DOB],
				  [EntityTypeCode],
				  [EntityTypeDesc],
				  [PersonTypeCode],
				  [PersonTypeDesc],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT @RegistrationId AS [PersonId],
							[Code],
							[FirstName],
							[MiddleName],
							[LastName],
							[OrganizationName],
							[Gender],
							[DOB],
							[EntityTypeCode],
							[EntityTypeDesc],
							[PersonTypeCode],
							[PersonTypeDesc],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPerson;
					   PRINT 'Insert person Done'
				 
				 
				 --dbo.PersonUID  

				 INSERT INTO dbo.PersonUID
				 ([UIDId],
				  [PersonId],
				  [UID],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [UIDId],
							@RegistrationId,
							[AadhaarCardNo],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonVerificationDetails;
				 PRINT 'Insert UID Done'
				 --dbo.PersonPAN  
				 
				 INSERT INTO dbo.PersonPAN
				 ([PANId],
				  [PersonId],
				  [PAN],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [PANId],
							@RegistrationId,
							[PANCardNo],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonVerificationDetails;
				PRINT 'Insert PAN Done'
				 --dbo.PersonDLID  

				 INSERT INTO dbo.PersonDLID
				 ([DLIDId],
				  [PersonId],
				  [DLID],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [DLIDId],
							@RegistrationId,
							[DrivingLicenceNo],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonVerificationDetails;
				PRINT 'Insert DL Done'
				 --dbo.PersonOtherID  

				 INSERT INTO dbo.PersonOtherID
				 ([OtherIdentificationId],
				  [PersonId],
				  [IDNo],
				  [IDDocumentName],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [OtherIdentificationId],
							@RegistrationId AS [PersonId],
							[OtherIdCardDocumentNo],
							[OtherIdCardDocumentName],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonVerificationDetails;
				PRINT 'Insert Other ID Done'
				 --dbo.PersonPhoto  

				 INSERT INTO dbo.PersonPhoto
				 ([PhotoId],
				  [PersonId],
				  [iPhoto],
				  [FileExtension],
				  [MIMEType],
				  [FileSize],
				  [Width],
				  [Height],
				  [Thumbnail],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [PhotoId],
							@RegistrationId AS [PersonId],
							[iPhoto],
							[FileExtension],
							[MIMEType],
							[FileSize],
							[Width],
							[Height],
							[Thumbnail],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonPhotoDetails;
					   PRINT 'Insert Photo Done'
				 --dbo.PersonContact  

				 INSERT INTO dbo.PersonContact
				 ([ContactId],
				  [PersonId],
				  [ContactNo],
				  [ContactTypeCode],
				  [ContactTypeDesc],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [ContactId],
							@RegistrationId AS [PersonId],
							[ContactNo],
							[ContactTypeCode],
							[ContactTypeDesc],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonContacts;
					   PRINT 'Insert Contact Done'
				 --dbo.PersonAddress  

				 INSERT INTO dbo.PersonAddress
				 ([AddressId],
				  [AddressType],
				  [PersonId],
				  [AddressLine1],
				  [AddressLine2],
				  [City],
				  [Taluka],
				  [District],
				  [State],
				  [ZipCode],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [AddressId],
							[AddressType],
							@RegistrationId AS [PersonId],
							[AddressLine1],
							[AddressLine2],
							[City],
							[Taluka],
							[District],
							[State],
							[ZipCode],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonAddressDetails;
					   PRINT 'Insert Address Done'
				 --dbo.PersonIDCard  

				 INSERT INTO dbo.PersonIDCard
				 ([CardId],
				  [PersonId],
				  [ReferenceId],
				  [IDTypeCode],
				  [IDTypeDesc],
				  [iCard],
				  [CreatedOn],
				  [LastModifiedOn]
				 )
					   SELECT [dbo].[GetUniqueID_V2]() AS [CardId],
							@RegistrationId AS [PersonId],
							[ReferenceId],
							[IDTypeCode],
							[IDTypeDesc],
							[iCard],
							@dtCreatedOn,
							@dtLastModifiedOn
					   FROM   @udtPersonCards;
					   PRINT 'Insert Card Done'
				 --dbo.Person  

				 
			  END;

		   COMMIT TRANSACTION AddPerson;
	    END TRY
	    BEGIN CATCH
		   IF @@TRANCOUNT > 0
			  BEGIN
				 ROLLBACK TRANSACTION AddPerson;
			  END;
		   --TODO: Log here and insert into database table for SQL Exception  
		   SELECT ERROR_LINE(),ERROR_MESSAGE(),ERROR_PROCEDURE();
	    END CATCH;
	END;






GO
 -- 4 -- 
 -- gsp_GetPersonByPersonType -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetPersonByPersonType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetPersonByPersonType]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE gsp_GetPersonByPersonType
-- Add the parameters for the stored procedure here
	  @PersonTypeCode INT 
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    IF CONVERT(int,@PersonTypeCode) = -1
		   BEGIN
			  SELECT [P].[PersonId],
				    [P].[Code],
				    [P].[FirstName],
				    [P].[MiddleName],
				    [P].[LastName],
				    [P].[DOB],
				    CASE [P].[Gender]
						 WHEN 1 THEN 'Male'
						 WHEN 2 THEN 'Female'
						 ELSE 'Other'
					  END AS [Gender],
				    [P].[OrganizationName],
				    --[P].[PersonTypeCode],
				    [P].[PersonTypeDesc],
				    --[P].[EntityTypeCode],
				    [P].[EntityTypeDesc]
			  FROM   dbo.Person AS P;
		   END;
	    ELSE
		   BEGIN
			  SELECT [P].[PersonId],
				    [P].[Code],
				    [P].[FirstName],
				    [P].[MiddleName],
				    [P].[LastName],
				    [P].[DOB],
				    CASE [P].[Gender]
						 WHEN 1 THEN 'Male'
						 WHEN 2 THEN 'Female'
						 ELSE 'Other'
					  END AS [Gender],
				    [P].[OrganizationName],
				    --[P].[PersonTypeCode],
				    [P].[PersonTypeDesc],
				    --[P].[EntityTypeCode],
				    [P].[EntityTypeDesc]
			  FROM   dbo.Person AS P
			  WHERE  [P].[PersonTypeCode] = @PersonTypeCode;
		   END;
	END;


GO
 -- 5 -- 
 -- gsp_INUP_UserMaster -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_INUP_UserMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_INUP_UserMaster]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE [dbo].[gsp_INUP_UserMaster]
-- Add the parameters for the stored procedure here
	 @UserId           BIGINT OUTPUT,
	 @LoginName        VARCHAR(20),
	 @Password         VARCHAR(50),
	 @FirstName        VARCHAR(200),
	 @MiddleName       VARCHAR(200),
	 @LastName         VARCHAR(200),
	 @Gender           TINYINT,
	 @DOB              DATE,
	 @RegistrationDate DATETIME,
	 @Phone            VARCHAR(50),
	 @Mobile           VARCHAR(50),
	 @Mobile1          VARCHAR(50),
	 @eMail            VARCHAR(256),
	 @AddressLine1     VARCHAR(255),
	 @AddressLine2     VARCHAR(255),
	 @City             VARCHAR(255),
	 @State            VARCHAR(255),
	 @Zip              VARCHAR(10),
	 @bIsBlocked       BIT,
	 @RoleID           BIGINT
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    IF @UserId = 0
		   BEGIN
			  DECLARE
				    @ID NUMERIC;
			  SET @ID = [dbo].[GetUniqueID_V2]();
			  INSERT INTO dbo.Users
			  ([UserId],
			   [LoginName],
			   [Password],
			   [FirstName],
			   [MiddleName],
			   [LastName],
			   [Gender],
			   [DOB],
			   [RegistrationDate],
			   [Phone],
			   [Mobile],
			   [Mobile1],
			   [eMail],
			   [AddressLine1],
			   [AddressLine2],
			   [City],
			   [State],
			   [Zip]
			  )
			  VALUES      (@ID, -- UserId - bigint
						@LoginName, -- LoginName - varchar
						@Password, -- Password - varchar
						@FirstName, -- FirstName - varchar
						@MiddleName, -- MiddleName - varchar
						@LastName, -- LastName - varchar
						@Gender, -- Gender - tinyint
						@DOB, -- DOB - date
						@RegistrationDate, -- RegistrationDate - datetime
						@Phone, -- Phone - varchar
						@Mobile, -- Mobile - varchar
						@Mobile, -- Mobile1 - varchar
						@eMail, -- eMail - varchar
						@AddressLine1, -- AddressLine1 - varchar
						@AddressLine1, -- AddressLine2 - varchar
						@City, -- City - varchar
						@State, -- State - varchar
						@Zip -- Zip - varchar
			  );
			  SET @UserId = @ID;

			  INSERT INTO dbo.UserStatus
			  ([UserDetailId],
			   [UserId],
			   [bIsBlocked]
			  )
			  VALUES      (dbo.GetUniqueID_V2(), -- UserDetailId - bigint
						@ID, -- UserId - bigint
						@bIsBlocked -- bIsBlocked - bit
			  );

			  INSERT INTO dbo.UserRole
			  ([UserRoleID],
			   [UserID],
			   [RoleID]
			  )
			  VALUES      (dbo.GetUniqueID_V2(), -- UserRoleID - numeric
						@ID, -- UserID - bigint
						@RoleID -- RoleID - numeric
			  );
		   END;
	    ELSE
		   BEGIN
			  UPDATE Users
			    SET
				   [LoginName] = @LoginName, -- varchar
				   [Password] = @Password, -- varchar
				   [FirstName] = @FirstName, -- varchar
				   [MiddleName] = @MiddleName, -- varchar
				   [LastName] = @LastName, -- varchar
				   [Gender] = @Gender, -- tinyint
				   [DOB] = @DOB, -- date
				   [RegistrationDate] = @RegistrationDate, -- datetime
				   [Phone] = @Phone, -- varchar
				   [Mobile] = @Mobile, -- varchar
				   [Mobile1] = @Mobile1, -- varchar
				   [eMail] = @eMail, -- varchar
				   [AddressLine1] = @AddressLine1, -- varchar
				   [AddressLine2] = @AddressLine1, -- varchar
				   [City] = @City, -- varchar
				   [State] = @State, -- varchar
				   [Zip] = @Zip, -- varchar
				   [LastModifiedOn] = GETDATE() -- datetime
			  WHERE  [UserId] = @UserId;

			  UPDATE dbo.UserStatus
			    SET
				   [dbo].[UserStatus].[bIsBlocked] = @bIsBlocked     -- bit
			  WHERE  [dbo].[UserStatus].[UserId] = @UserId; -- bigint

			  UPDATE dbo.UserRole
			    SET
				   [dbo].[UserRole].[RoleID] = @RoleID -- numeric
			  WHERE  [dbo].[UserRole].[UserID] = @UserId;
		   END;
	END;

GO
 -- 6 -- 
 -- gsp_GetPersonFullDetails -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetPersonFullDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetPersonFullDetails]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE gsp_GetPersonFullDetails
-- Add the parameters for the stored procedure here
	  @PersonID NUMERIC(18, 0)
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here
	    --Address Details--
	    SELECT *
	    FROM   dbo.PersonAddress
	    WHERE  [PersonId] = @PersonID;
	    
	    --Contact Details--
	    SELECT *
	    FROM   dbo.PersonContact
	    WHERE  [PersonId] = @PersonID;
	    
	    --Photo Details--
	    SELECT *
	    FROM   dbo.PersonPhoto
	    WHERE  [PersonId] = @PersonID;
	    
	    --Verification Details--
	    SELECT [dbo].[PersonDLID].[DLIDId] AS [ID],
			 [dbo].[PersonDLID].[DLID] AS [No],
			 '' AS [Name],
			 '2' AS [TypeCode]
	    FROM     dbo.PersonDLID
	    WHERE   [PersonId] = @PersonID
	    UNION ALL
	    --SELECT * FROM dbo.PersonIDCard WHERE PersonId=@PersonID
	    SELECT [dbo].[PersonOtherID].[OtherIdentificationId] AS [ID],
			 [dbo].[PersonOtherID].[IDNo] AS [No],
			 [dbo].[PersonOtherID].[IDDocumentName] AS [Name],
			 '3' AS [TypeCode]
	    FROM     dbo.PersonOtherID
	    WHERE   [PersonId] = @PersonID
	    UNION ALL
	    SELECT [dbo].[PersonPAN].[PANId] AS [ID],
			 [dbo].[PersonPAN].[PAN] AS [No],
			 '' AS [Name],
			 '1' AS [TypeCode]
	    FROM     dbo.PersonPAN
	    WHERE   [PersonId] = @PersonID
	    UNION ALL
	    SELECT [dbo].[PersonUID].[UIDId] AS [ID],
			 [dbo].[PersonUID].[UID] AS [No],
			 '' AS [Name],
			 '0' AS [TypeCode]
	    FROM   dbo.PersonUID
	    WHERE  [PersonId] = @PersonID;
	    
	    --Person Details--
	    SELECT *
	    FROM   dbo.Person
	    WHERE  [PersonId] = @PersonID;
	END;


GO
 -- 7 -- 
 -- gsp_GetPincodeDetails -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetPincodeDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetPincodeDetails]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE gsp_GetPincodeDetails
-- Add the parameters for the stored procedure here
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    SELECT 
			 [ZM].[PinCode],
			 [ZM].[PostName],
			 [ZM].[Taluka],
			 [ZM].[District],
			 [ZM].[State]
	    FROM   dbo.ZipMaster AS ZM;
	END;


GO
 -- 8 -- 
 -- gsp_GetUsersDetails_ByUserType -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetUsersDetails_ByUserType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetUsersDetails_ByUserType]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE [dbo].[gsp_GetUsersDetails_ByUserType]
-- Add the parameters for the stored procedure here
	 @nUserType INT
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    IF @nUserType = 0
		   BEGIN
			  SELECT    [U].[UserId],
					  [U].[LoginName],
					  [U].[FirstName]+CASE
									  WHEN ISNULL([U].[MiddleName], '') = '' THEN ''
									  ELSE ''+[U].[middleName]+''+[U].[LastName]
								   END AS [PatientName],
					  CASE [U].[Gender]
						 WHEN 1 THEN 'Male'
						 WHEN 2 THEN 'Female'
						 ELSE 'Other'
					  END AS [Gender],
					  [U].[DOB],
					  [U].[RegistrationDate],
					  [U].[Phone],
					  [U].[Mobile],
					  [U].[Mobile1],
					  [U].[AddressLine1],
					  [U].[AddressLine2],
					  [U].[State],
					  [U].[UserId],
					  [U].[Zip],
					  [U].[City],
					  [U].[eMail],
					  [US].[bIsBlocked],
			  (
				 SELECT [RM].[RoleName]
				 FROM    [dbo].[RoleMaster] AS [RM]
				 WHERE  [RM].[RoleId] = [UR].[RoleId]
			  ) AS [UserRole],
					  [U].[CreatedOn],
					  [U].[LastModifiedOn]
			  FROM dbo.Users AS U
				  INNER JOIN dbo.UserStatus AS US ON US.UserId = U.UserId
				  LEFT OUTER JOIN dbo.UserRole AS UR ON ur.UserID = u.UserId;
		   END;
	    ELSE
		   BEGIN
			  IF @nUserType = 1 --Active users

				 BEGIN
					SELECT    [U].[UserId],
							[U].[LoginName],
							[U].[FirstName]+CASE
											WHEN ISNULL([U].[MiddleName], '') = '' THEN ''
											ELSE ''+[U].[middleName]+''+[U].[LastName]
										 END AS [PatientName],
							CASE [U].[Gender]
							    WHEN 1 THEN 'Male'
							    WHEN 2 THEN 'Female'
							    ELSE 'Other'
							END AS [Gender],
							[U].[DOB],
							[U].[RegistrationDate],
							[U].[Phone],
							[U].[Mobile],
							[U].[Mobile1],
							[U].[AddressLine1],
							[U].[AddressLine2],
							[U].[State],
							[U].[UserId],
							[U].[Zip],
							[U].[City],
							[U].[eMail],
							[US].[bIsBlocked],
					(
					    SELECT [RM].[RoleName]
					    FROM    [dbo].[RoleMaster] AS [RM]
					    WHERE  [RM].[RoleId] = [UR].[RoleId]
					) AS [UserRole],
							[U].[CreatedOn],
							[U].[LastModifiedOn]
					FROM dbo.Users AS U
						INNER JOIN dbo.UserStatus AS US ON US.UserId = U.UserId
						LEFT OUTER JOIN dbo.UserRole AS UR ON ur.UserID = u.UserId
					WHERE [US].[bIsBlocked] = 0;
				 END;
			  ELSE
				 BEGIN
					SELECT    [U].[UserId],
							[U].[LoginName],
							[U].[FirstName]+CASE
											WHEN ISNULL([U].[MiddleName], '') = '' THEN ''
											ELSE ''+[U].[middleName]+''+[U].[LastName]
										 END AS [PatientName],
							CASE [U].[Gender]
							    WHEN 1 THEN 'Male'
							    WHEN 2 THEN 'Female'
							    ELSE 'Other'
							END AS [Gender],
							[U].[DOB],
							[U].[RegistrationDate],
							[U].[Phone],
							[U].[Mobile],
							[U].[Mobile1],
							[U].[AddressLine1],
							[U].[AddressLine2],
							[U].[State],
							[U].[UserId],
							[U].[Zip],
							[U].[City],
							[U].[eMail],
							[US].[bIsBlocked],
					(
					    SELECT [RM].[RoleName]
					    FROM    [dbo].[RoleMaster] AS [RM]
					    WHERE  [RM].[RoleId] = [UR].[RoleId]
					) AS [UserRole],
							[U].[CreatedOn],
							[U].[LastModifiedOn]
					FROM dbo.Users AS U
						INNER JOIN dbo.UserStatus AS US ON US.UserId = U.UserId
						LEFT OUTER JOIN dbo.UserRole AS UR ON ur.UserID = u.UserId
					WHERE [US].[bIsBlocked] = 1;
				 END;
		   END;
	END;

GO
 -- 9 -- 
 -- gsp_GetRoles -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_GetRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_GetRoles]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE gsp_GetRoles
-- Add the parameters for the stored procedure here
	  @RoleID BIGINT = 0
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    IF @RoleID = 0
		   BEGIN
			  SELECT *
			  FROM   dbo.RoleMaster AS RM;
		   END;
	    ELSE
		   BEGIN
			  SELECT *
			  FROM   dbo.RoleMaster AS RM
			  WHERE  [RM].[RoleId] = @RoleID;
		   END;
	END;


GO
 -- 10 -- 
 -- gsp_ChangePassword -- 

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gsp_ChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[gsp_ChangePassword]

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE gsp_ChangePassword
-- Add the parameters for the stored procedure here
	  @UserId    BIGINT OUTPUT,
	  @LoginName VARCHAR(20),
	  @Password  VARCHAR(50)
AS
	BEGIN
	    -- SET NOCOUNT ON added to prevent extra result sets from
	    -- interfering with SELECT statements.

	    SET NOCOUNT ON;
	    -- Insert statements for procedure here

	    UPDATE dbo.Users
		 SET
			[Password] = @Password, -- varchar
			[LastModifiedOn] = GETDATE()    -- datetime	  
	    WHERE  [UserId] = @UserId
			 AND [LoginName] = @LoginName;   -- bigint
	END;

