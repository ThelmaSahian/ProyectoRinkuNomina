USE [DispositivosIoT]

--Creación de tablas Dispositivos y Eventos

CREATE TABLE Dispositivos(
	 DispositivoID BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 IdTipo INT NOT NULL,
	 Nombre VARCHAR(250) NOT NULL,
	 FechaCreacion DATETIME NOT NULL,
	 UsuarioCreacion INT NOT NULL,
	 FechaModificacion DATETIME NULL,
	 UsuarioModificion INT NULL,
)

CREATE TABLE Eventos(
	 Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	 IdTipo INT NULL,
	 IdDispositivo BIGINT NOT NULL,
	 Descripcion VARCHAR(250) NOT NULL,
	 Valor INT NOT NULL,
	 FechaHora DATETIME NOT NULL,
	 UsuarioCreacion INT NOT NULL,
	 FechaHoraModificacion DATETIME NULL,
	 UsuarioModificion INT NULL,
	 FOREIGN KEY (IdDispositivo) REFERENCES Dispositivos(DispositivoID)
)

-- Alta de datos dummys para tablas Dispositivos y Eventos
INSERT INTO Dispositivos(
	IdTipo,
	Nombre,
	FechaCreacion,
	UsuarioCreacion
) 
--Tipo 1: sensores
VALUES  (1, 'Sensor Alfa', GETDATE(), 0),
		(1, 'Sensor Alfa 2', GETDATE(), 0),
		(1, 'Sensor Omega', GETDATE(), 0);

INSERT INTO Eventos(
	IdDispositivo,
	Descripcion,
	Valor,
	FechaHora,
	UsuarioCreacion
)
VALUES  (1, 'Temperatura', 16, GETDATE(), 0),
		(1, 'Temperatura', 14, GETDATE(), 0),
		(2, 'Temperatura', 5, GETDATE(), 0),
		(3, 'Humedad', 10, GETDATE(), 0),
		(3, 'Humedad', 9, GETDATE(), 0),
		(3, 'Humedad', 11, GETDATE(), 0);

/*
* Query para obtener la cantidad de eventos por dispositivo.
*/
SELECT D.Nombre, COUNT(*) AS Cantidad
FROM Eventos E JOIN Dispositivos D 
ON E.IdDispositivo = D.DispositivoID
GROUP BY D.DispositivoID, D.Nombre; 