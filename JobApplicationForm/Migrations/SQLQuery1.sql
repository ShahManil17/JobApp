DROP PROCEDURE getPerticularData;

CREATE PROCEDURE getPerticularData (@id INT)
AS
BEGIN
	SELECT * FROM BasicDetails WHERE Id = @id;
	SELECT * FROM EducationDetails WHERE BasicDetailsId = @id;
	SELECT * FROM WorkExperiences WHERE BasicDetailsId = @id;
	SELECT * FROM Languages WHERE BasicDetailsId = @id;
	SELECT * FROM Technologies WHERE BasicDetailsId = @id;
	SELECT * FROM Preferences WHERE BasicDetailsId = @id;
END;
EXEC getPerticularData 2;