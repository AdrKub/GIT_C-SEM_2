CREATE DATABASE FootballMngmt

USE FootballMngmt

CREATE TABLE tblTeams
(
	ID					int identity(1,1) NOT NULL,
	Country				varchar(100) NOT NULL,
	PicturePath			varchar(max) NULL,

	CONSTRAINT	PK_TeamID		PRIMARY KEY(ID)
);
GO

CREATE TABLE tblPositions
(
	ID					int identity(1,1) NOT NULL,
	Position			varchar(100) NOT NULL,

	CONSTRAINT	PK_PositionID		PRIMARY KEY(ID),
);
GO

CREATE TABLE tblPlayers
(
	ID					int identity(1,1) NOT NULL,
	Name				varchar(100) NOT NULL,
	FirstName			varchar(100) NOT NULL,
	Height				int NOT NULL,
	BirthDate			datetime NOT NULL,
	PlayerNmbr			int NULL,
	Position_ID			int NOT NULL,
	PlayedGames			int NOT NULL,
	Goals				int NOT NULL,
	PicturePath			varchar(max) NULL,
	Team_ID				int NULL,

	CONSTRAINT	PK_PlayerID		PRIMARY KEY(ID),
	--CONSTRAINT	UQ_PlayerNmbr	UNIQUE(PlayerNmbr, Team_ID)
);
GO

ALTER TABLE tblPlayers
	ADD CONSTRAINT		FK_Player_Team			FOREIGN KEY(Team_ID)
		REFERENCES		tblTeams(ID),

		CONSTRAINT		FK_Player_Position		FOREIGN KEY(Position_ID)
		REFERENCES		tblPositions(ID)
GO


INSERT INTO tblPositions (Position)
	VALUES ('Torwart'),
			('Verteidiger'),
			('Mittelfeld'),
			('Stürmer')
GO

INSERT INTO tblTeams (Country)
	VALUES ('Schweiz'),
			('Deutschland')
GO

INSERT INTO tblPlayers (Name, FirstName, Height, BirthDate, PlayerNmbr, Position_ID, PlayedGames, Goals, Team_ID, PicturePath)
	VALUES ('Sommer','Yann',183,'12-17-88',1,(SELECT ID FROM tblPositions WHERE Position = 'Torwart'),37,0,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'yannSommer.png'),
		('Mvogo','Yvon',186,'06-06-94',12,(SELECT ID FROM tblPositions WHERE Position = 'Torwart'),0,0,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'yvonMvogo.png'),
		('Buerki','Roman',188,'11-14-90',21,(SELECT ID FROM tblPositions WHERE Position = 'Torwart'),9,0,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'romanBuerki.png'),
		('Lichtsteiner','Stephan',181,'01-16-84',2,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),102,8,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'stephanLichtsteiner.png'),
		('Lang','Michael',185,'02-08-91',6,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),25,2,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'michaelLang.png'),
		('Rodriguez','Ricardo',180,'08-25-92',13,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),55,5,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'ricardoRodriguez.png'),
		('Behrami','Valon',184,'04-19-85',11,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),81,2,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'valonBehrami.png'),
		('Zuber','Steven',182,'08-17-91',14,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),14,4,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'stevenZuber.png'),
		('Fernandes','Gelson',180,'09-02-86',16,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),67,2,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'gelsonFernandes.png'),
		('Embolo','Breel',184,'02-14-97',7,(SELECT ID FROM tblPositions WHERE Position = 'Stürmer'),27,3,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'breelEmbolo.png'),
		('Seferovic','Haris',186,'02-22-92',9,(SELECT ID FROM tblPositions WHERE Position = 'Stürmer'),53,12,(SELECT ID FROM tblTeams WHERE Country = 'Schweiz'),'harisSeferovic.png'),
		
		('Neuer','Manuel',193,'03-27-86',1,(SELECT ID FROM tblPositions WHERE Position = 'Torwart'),78,0,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'manuelNeuer.png'),
		('Trapp','Kevin',189,'06-08-90',12,(SELECT ID FROM tblPositions WHERE Position = 'Torwart'),3,0,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'kevinTrapp.png'),
		('Hector','Jonas',185,'05-27-90',3,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),39,3,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'jonasHector.png'),
		('Hummels','Mats',192,'12-16-88',5,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),65,5,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'matsHummels.png'),
		('Boateng','Jerome',192,'09-03-88',17,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),73,1,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'jeromeBoateng.png'),
		('Draxler','Julian',185,'09-20-93',7,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),46,6,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'julianDraxler.png'),
		('Toni','Kroos',182,'01-04-90',8,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),85,13,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'toniKroos.png'),
		('Mueller','Thomas',186,'09-13-89',13,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),93,38,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'thomasMueller.png'),
		('Brandt','Julian',183,'05-02-96',20,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),18,1,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'julianBrandt.png'),
		('Reus','Marco',180,'05-31-89',11,(SELECT ID FROM tblPositions WHERE Position = 'Stürmer'),33,10,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'marcoReus.png'),
		('Gomez','Mario',189,'07-10-85',23,(SELECT ID FROM tblPositions WHERE Position = 'Stürmer'),77,31,(SELECT ID FROM tblTeams WHERE Country = 'Deutschland'),'marioGomez.png'),
		
		('Müller','Heribert',201,'08-17-91',NULL,(SELECT ID FROM tblPositions WHERE Position = 'Stürmer'),23,0,NULL,'anonymus.jpg'),
		('Rickenbach','Harald',175,'08-17-91',NULL,(SELECT ID FROM tblPositions WHERE Position = 'Mittelfeld'),3,0,NULL,'anonymus.jpg'),
		('Frei','Alex',178,'08-17-91',NULL,(SELECT ID FROM tblPositions WHERE Position = 'Verteidiger'),99,0,NULL,'anonymus.jpg')
GO



DELETE tblTeams
DELETE tblPositions
DELETE tblPlayers

DROP TABLE tblTeams
DROP TABLE tblPositions
DROP TABLE tblPlayers