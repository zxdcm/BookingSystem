/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF (NOT EXISTS(SELECT * FROM [dbo].[Roles]))
BEGIN
	INSERT INTO Roles ([Name])
	VALUES
		('Admin'),
		('User');
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Countries]))
BEGIN
    INSERT INTO [dbo].[Countries]([Name]) 
	VALUES ('United States'), ('United Kingdom'), ('Spain')
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Cities]))
BEGIN
	INSERT INTO [dbo].[Cities]([CountryId], [Name])
	SELECT [Countries].[CountryId], [Cities].[Name]
	FROM (SELECT [CountryId], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num 
		  FROM [dbo].[Countries]) AS [Countries]
	JOIN 
		(SELECT [Name], ROW_NUMBER() OVER (ORDER BY (SELECT 0)) AS row_num
		 FROM (VALUES ('New York'),('London'),('Madrid')) AS [Cities]([Name])) AS [Cities]
	ON [Countries].row_num = [Cities].row_num
END

