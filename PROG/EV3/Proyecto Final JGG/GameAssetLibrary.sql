--CREATE DATABASE GAME_ASSET_LIBRARYGal�n
--USE GAME_ASSET_LIBRARY

CREATE TABLE CHARACTERS(
	idCharacter INT IDENTITY,
	name VARCHAR(150),
	class INT,
	element INT,
	attack INT,
	defense INT,
	speed INT,
	health INT,
	magic INT

	CONSTRAINT PK_IDCHARACTER PRIMARY KEY (idCharacter),
	CONSTRAINT FK_CLASSES_CHARACTERS FOREIGN KEY (class)
		REFERENCES CLASSES (idClass)
)

CREATE TABLE CLASSES(
	idClass INT IDENTITY,
	name VARCHAR(150),

	CONSTRAINT PK_IDCLASS PRIMARY KEY (idClass),
)

