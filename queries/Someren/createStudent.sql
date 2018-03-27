CREATE TABLE [dbo].[STUDENT]
(
	[studentNr] INT NOT NULL PRIMARY KEY, 
    [voornaam] NVARCHAR(50) NULL, 
    [achternaam] NVARCHAR(50) NULL, 
    [slaapt_op] INT NULL, 
    [docentConde] INT NULL
)
