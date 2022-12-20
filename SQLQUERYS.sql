CREATE DATABASE DBPrueba
GO

USE DBPrueba
GO

CREATE TABLE Usuario(
	IdUsuario int PRIMARY KEY IDENTITY,
	NombreUsuario VARCHAR(20),
	Clave VARCHAR(20)
)
GO

INSERT INTO Usuario(NombreUsuario, Clave)
VALUES
('Admin', '123')
GO

-- Pruebas para explicacion de como funciona el Refresh Token Si quieren lo pueden ejecutar para probarlo la idea es
-- Se cree un token y se compruebe todo el tiempo la fecha de expiracion de ese token a medida que el tiempo avanze para
-- despues verificar si el token expiro
--CREATE TABLE TABLA_PRUEBA(
--	FechaCreacion datetime,
--	FechaExpiracion datetime,
--	EsActivo AS ( iif (FechaExpiracion < getdate(), convert(bit, 0), convert(bit, 1)))
--)
--GO

--insert into TABLA_PRUEBA(FechaCreacion, FechaExpiracion)
--values(
--GETDATE(),
--DATEADD(SECOND, 10, GETDATE()))

--select * from TABLA_PRUEBA

--drop table TABLA_PRUEBA

CREATE TABLE HistorialRefreshToken(
IdHistorialToken int PRIMARY KEY IDENTITY,
IdUsuario int REFERENCES Usuario(IdUsuario),
Token VARCHAR(100),
RefreshToken VARCHAR(200),
FechaCreacion DATETIME,
FechaExpiracion DATETIME,
EsActivo AS ( iif(FechaExpiracion < GETDATE(), CONVERT(bit, 0), CONVERT(bit, 1)) ) -- Columna calculada
)
GO