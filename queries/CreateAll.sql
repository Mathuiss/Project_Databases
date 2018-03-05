CREATE TABLE [dbo].[STUDENT_DOET_ACTIVITEIT]
(
	[studentNr] INT NOT NULL PRIMARY KEY, 
    [activiteitCode] NVARCHAR(8) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)
CREATE TABLE [dbo].[ACTIVITEIT]
(
	[activiteitCode] INT NOT NULL PRIMARY KEY, 
    [naam] NVARCHAR(50) NOT NULL, 
    [plaats] NVARCHAR(50) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)
CREATE TABLE [dbo].[BARDIENST]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [startTijd] DATETIME NULL, 
    [eindTijd] DATETIME NULL, 
    [docentCode] INT NOT NULL, 
    [studentNr] INT NOT NULL,
)
CREATE TABLE [dbo].[BEGELEIDER]
(
	[docentCode] INT NOT NULL , 
    [startTijd] DATETIME NOT NULL,
    [eindTijd] DATETIME NOT NULL, 
    PRIMARY KEY ([docentCode], [eindTijd], [startTijd]),
)
CREATE TABLE [dbo].[BEGELEIDER_BEGELEIDT_ACTIVITEIT]
(
	[docentCode] INT NOT NULL PRIMARY KEY, 
    [activiteitCode] NVARCHAR(8) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)
CREATE TABLE [dbo].[STUDENT]
(
	[studentNr] INT NOT NULL PRIMARY KEY, 
    [voornaam] NVARCHAR(50) NULL, 
    [achternaam] NVARCHAR(50) NULL, 
    [slaapt_op] INT NULL, 
    [docentConde] INT NULL
)
CREATE TABLE [dbo].[KAMER]
(
	[kamerCode] INT NOT NULL PRIMARY KEY, 
    [maxPersonen] INT NULL
)
CREATE TABLE [dbo].[DOCENT]
(
	[docentCode] INT NOT NULL PRIMARY KEY, 
    [voornaam] NVARCHAR(50) NULL, 
    [achternaam] NVARCHAR(50) NULL, 
    [isBegeleider] BIT NULL
)
