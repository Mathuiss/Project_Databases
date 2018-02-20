CREATE TABLE [dbo].[DOCENT]
(
	[docentCode] INT NOT NULL PRIMARY KEY, 
    [voornaam] NVARCHAR(50) NULL, 
    [achternaam] NVARCHAR(50) NULL, 
    [isBegeleider] BIT NULL
)
