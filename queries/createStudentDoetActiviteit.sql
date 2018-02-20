CREATE TABLE [dbo].[STUDENT_DOET_ACTIVITEIT]
(
	[studentNr] INT NOT NULL PRIMARY KEY, 
    [activiteitCode] NVARCHAR(8) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)
