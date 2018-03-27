CREATE TABLE [dbo].[ACTIVITEIT]
(
	[activiteitCode] INT NOT NULL PRIMARY KEY, 
    [naam] NVARCHAR(50) NOT NULL, 
    [plaats] NVARCHAR(50) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)
