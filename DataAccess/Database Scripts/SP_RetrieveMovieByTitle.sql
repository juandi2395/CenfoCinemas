CREATE PROCEDURE [dbo].[RET_MOVIE_BY_TITLE_PR]
@P_TITLE NVARCHAR(75)
AS
BEGIN
	SELECT Id, Created, Updated, Title, Description, ReleaseDate, Genre, Director
	FROM TBL_Movie
	WHERE Title = @P_TITLE
END