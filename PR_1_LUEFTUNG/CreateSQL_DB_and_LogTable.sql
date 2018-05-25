CREATE DATABASE LogGLueftung

USE LogGLueftung

CREATE TABLE tblEngineLogs
(
	ID					int identity(1,1) NOT NULL,
	ActCurrent				varchar(255) NOT NULL,
	ActPower			varchar(255) NOT NULL,
	ActSpeed			varchar(255) NOT NULL,
	ActVoltage			varchar(255) NOT NULL,
	ActDate			varchar(255) NOT NULL,

	CONSTRAINT	PK_LogNmbr		PRIMARY KEY(ID)
);
GO

DELETE tblEngineLogs

DROP TABLE tblEngineLogs