CREATE TABLE [dbo].[BEGELEIDER]
(
	[docentCode] INT NOT NULL , 
    [startTijd] DATETIME NOT NULL,
    [eindTijd] DATETIME NOT NULL, 
    PRIMARY KEY ([docentCode], [eindTijd], [startTijd]),
)
