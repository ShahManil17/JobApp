USE [JobApplicationForm]
GO
/****** Object:  StoredProcedure [dbo].[getPerticularData]    Script Date: 26-06-2024 09:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getPerticularData] --1
(@id INT)
                AS
                BEGIN
					SELECT basic.*,
					(
						SELECT
						edu.BoardName, edu.Percentage, edu.PassingYear,edu.EduLevel
						FROM EducationDetails as edu
						WHERE edu.BasicDetailsId = basic.Id
						FOR JSON PATH
					) AS education,
					(
						SELECT 
						work.Company, work.Designation, work.StartDate, work.EndDate
						FROM WorkExperiences AS work
						WHERE work.BasicDetailsId = basic.Id
						FOR JSON PATH
					) AS work,
					(
						SELECT 
						lang.LangName, lang.LangLevel
						FROM Languages as lang
						WHERE lang.BasicDetailsId = basic.Id
						FOR JSON PATH
					) AS languages,
					(
						SELECT 
						tech.TechName, tech.TechLevel
						FROM Technologies AS tech
						WHERE tech.BasicDetailsId = basic.Id
						FOR JSON PATH
					) AS technologies,
					(
						SELECT 
						pref.ExpectedCtc, pref.CurrentCtc, pref.Location, pref.Notice, pref.Department
						FROM Preferences AS pref
						WHERE pref.BasicDetailsId = basic.Id
						FOR JSON PATH
					) AS preferences

					FROM BasicDetails as basic
					WHERE basic.Id = @id
					FOR JSON PATH;
                END;
