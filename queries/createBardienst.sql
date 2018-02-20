CREATE TABLE [dbo].[BARDIENST]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [startTijd] DATETIME NULL, 
    [eindTijd] DATETIME NULL, 
    [docentCode] INT NOT NULL, 
    [studentNr] INT NOT NULL,
)
