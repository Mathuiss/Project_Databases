﻿CREATE TABLE [dbo].[BEGELEIDER_BEGELEIDT_ACTIVITEIT]
(
	[docentCode] INT NOT NULL PRIMARY KEY, 
    [activiteitCode] NVARCHAR(8) NOT NULL, 
    [startTijd] DATETIME NOT NULL, 
    [eindTijd] DATETIME NOT NULL
)