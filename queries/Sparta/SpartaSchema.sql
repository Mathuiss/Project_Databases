
CREATE TABLE [BlokTijd](
	[BlokId] [int] NOT NULL,
	[BeginTijd] [smallint] NOT NULL,
	[EindTijd] [smallint] NOT NULL,
 CONSTRAINT [PK_BlokTijd] PRIMARY KEY (BlokId)
)

CREATE TABLE [ContactInfo](
	[ContactInfoId] [int] IDENTITY(10,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[Straat] [nvarchar](50) NOT NULL,
	[Huisnummer] [int] NOT NULL CONSTRAINT [DF_ContactInfo_Huisnummer]  DEFAULT ((0)),
	[Huisnummertoevoeging] [nvarchar](10) NULL,
	[Plaats] [nvarchar](50) NOT NULL,
	[Postcode] [nchar](6) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Telefoon] [nvarchar](20) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY (ContactInfoId)
)

CREATE TABLE [Cursus](
	[CursusId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
	[Niveau] [smallint] NOT NULL,
	[Toelichting] [nvarchar](50) NOT NULL,
	[Categorie] [smallint] NOT NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY (CursusId)
)

CREATE TABLE [Inschrijving](
	[InschrijvingId] [int] IDENTITY(1,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[CursusId] [int] NOT NULL,
 CONSTRAINT [PK_Inschrijving] PRIMARY KEY (InschrijvingId) 
)

CREATE TABLE [InstructeurRooster](
	[InstructeurId] [int] NOT NULL,
	[RoosterId] [int] NOT NULL,
 CONSTRAINT [PK_InstructeurRooster] PRIMARY KEY (InstructeurId, RoosterId) 
)

CREATE TABLE [Instructie](
	[InstructeurId] [int] IDENTITY(1,1) NOT NULL,
	[PersoonId] [int] NOT NULL,
	[CursusId] [int] NOT NULL,
 CONSTRAINT [PK_Instructeur] PRIMARY KEY (InstructeurId, PersoonId, CursusId) 
)

CREATE TABLE [Locatie](
	[LocatieId] [int] IDENTITY(1,1) NOT NULL,
	[Gebouw] [nvarchar](50) NULL,
	[Zaal] [nvarchar](10) NULL,
	[Omschrijving] [nvarchar](50) NULL,
 CONSTRAINT [PK_Locatie] PRIMARY KEY (LocatieId) 
)

CREATE TABLE [Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[AanmeldNaam] [nvarchar](50) NOT NULL,
	[PwdHash] [nchar](32) NOT NULL,
	[PersoonId] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY (LoginId) 
)

CREATE TABLE [Persoon](
	[PersoonId] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NOT NULL,
	[Achternaam] [nvarchar](50) NOT NULL,
	[Categorie] [smallint] NOT NULL CONSTRAINT [DF_pers_Categorie]  DEFAULT ((0)),
	[GeboorteDatum] [date] NULL,
 CONSTRAINT [PK_pers] PRIMARY KEY (PersoonId) 
)

CREATE TABLE [SpartaRooster](
	[RoosterId] [int] IDENTITY(1,1) NOT NULL,
	[CursusId] [int] NOT NULL,
	[LocatieId] [int] NOT NULL,
	[DagId] [int] NOT NULL,
	[BlokId] [int] NOT NULL,
 CONSTRAINT [PK_Rooster] PRIMARY KEY (RoosterId) 
)