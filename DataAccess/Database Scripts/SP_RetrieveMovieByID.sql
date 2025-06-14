CREATE PROCEDURE RET_USER_BY_ID_PR
    @Id INT
AS
BEGIN
    SELECT Id, Created, Updated, UserCode, Name, Email, Password, BirthDate, Status
    FROM TBL_User
    WHERE Id = @Id
END
GO