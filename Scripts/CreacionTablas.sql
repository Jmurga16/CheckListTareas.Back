USE DB_TASK
GO

--TABLA TAREAS
CREATE TABLE TBL_Task(
    nIdTask INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	isDone BIT NOT NULL DEFAULT 0,
	sNameTask VARCHAR(MAX),	
	isActive BIT NOT NULL DEFAULT 1
)
GO

--TABLA LOGIN
CREATE TABLE TBL_Login(
    sUsuario VARCHAR(MAX),		
    sPassword VARCHAR(MAX),
)
GO

--TABLA Menu
CREATE TABLE Menu(
    IdMenu INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    Name VARCHAR(20),
	Route VARCHAR(MAX),
	Icon VARCHAR(MAX),
	IdParent INT,
	Level INT,
	Status BIT NOT NULL DEFAULT 1
)
GO

--DATOS
INSERT INTO Menu(Name,Route,Icon,IdParent,Level, Status)
	VALUES('Lista de Tareas', 'task', 'task', 0, 1, 1)

INSERT INTO TBL_Login 
	VALUES ('test01','test01')

INSERT INTO TBL_Task 
	VALUES(0,'Tarea 01',1)

INSERT INTO TBL_Task 
	VALUES(1,'Tarea 02',1)

