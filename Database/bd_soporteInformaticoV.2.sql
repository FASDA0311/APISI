-- Create the database if it does not exist
IF EXISTS (SELECT * FROM sys.databases WHERE name = N'bd_soporteInformatico')
DROP DATABASE bd_soporteInformatico;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'bd_soporteInformatico')
CREATE DATABASE bd_soporteInformatico;
GO


USE bd_soporteInformatico;
GO

-- Create Ambiente table
CREATE TABLE Ambiente (
    Codigo INT NOT NULL IDENTITY PRIMARY KEY,
    Nombre VARCHAR(45) NULL,
    Descripcion VARCHAR(45) NULL,
	Vigente BIT NOT NULL Default 1
);
GO

-- Create Equipo table
CREATE TABLE Equipo (
    Codigo INT NOT NULL IDENTITY PRIMARY KEY,
    CodigoPatrimonial VARCHAR(30) NOT NULL,
	Nombre VARCHAR(45) NOT NULL,
	Marca VARCHAR(45) NULL,
	Modelo VARCHAR(45) NULL,
	NumSerie VARCHAR(20) NOT NULL,
	Estado CHAR(2) NULL,
    Caracteristicas VARCHAR(60) NULL,
	Vigente BIT NOT NULL Default 1,
    CodigoAmbiente INT NOT NULL,
    FOREIGN KEY (CodigoAmbiente) REFERENCES Ambiente(Codigo)
);
GO

-- Create Documento table
CREATE TABLE Documento (
    Codigo INT NOT NULL IDENTITY PRIMARY KEY,
	Nombre VARCHAR(45) NOT NULL,
	Fecha DATE NOT NULL,
    Archivo VARCHAR(45) NULL,
	Vigente BIT NOT NULL Default 1
);
GO

-- Create DetalleDocumento table
CREATE TABLE DetalleDocumento (
    Codigo INT NOT NULL IDENTITY PRIMARY KEY,
    CodigoEquipo INT NOT NULL,
    CodigoDocumento INT NOT NULL,
    FOREIGN KEY (CodigoEquipo) REFERENCES Equipo(Codigo),
    FOREIGN KEY (CodigoDocumento) REFERENCES Documento(Codigo)
);
GO

-- Create PersonalSoporte table
CREATE TABLE PersonalSoporte (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
	Nombres VARCHAR(45) NOT NULL,
	Apellidos VARCHAR(45) NOT NULL,
	Telefono VARCHAR(9) NULL,
	Correo VARCHAR(45)  NULL,
	DNI VARCHAR(8) NOT NULL,
    Vigente BIT NOT NULL Default 1,
);
GO

-- Create Usuario table
CREATE TABLE Usuario (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Nombre VARCHAR(45) NULL,
	Contraseña VARCHAR(45) NOT NULL,
	TipoUsuario CHAR(1) NOT NULL,
	Vigente BIT NOT NULL Default 1,
	CodigoPersonalSoporte INT NULL,
    FOREIGN KEY (CodigoPersonalSoporte) REFERENCES PersonalSoporte(Codigo)
);
GO

-- Create Responsable table
CREATE TABLE Responsable (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Nombres VARCHAR(45) NOT NULL,
	Apellidos VARCHAR(45) NOT NULL,
	Telefono VARCHAR(9) NULL,
	Correo VARCHAR(45)  NULL,
	DNI VARCHAR(8) NOT NULL,
    Vigente BIT NOT NULL Default 1,
    CodigoAmbiente INT NOT NULL,
    FOREIGN KEY (CodigoAmbiente) REFERENCES Ambiente(Codigo)
);
GO

-- Create TipoMaterial table
CREATE TABLE TipoMaterial (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Nombre VARCHAR(45) NOT NULL,
	Vigente BIT NOT NULL Default 1
);
GO

-- Create MATERIAL table
CREATE TABLE Material (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Cantidad VARCHAR(45) NULL,
    TipoProducto_Codigo INT NOT NULL,
	Vigente BIT NOT NULL Default 1,
    FOREIGN KEY (TipoProducto_Codigo) REFERENCES TipoMaterial(Codigo)
);
GO

-- Create ORDEN_REPOSICION table
CREATE TABLE Orden_Reposicion (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Total VARCHAR(45) NULL,
    CodigoPersonalSoporte INT NOT NULL,
	Vigente BIT NOT NULL Default 1,
    FOREIGN KEY (CodigoPersonalSoporte) REFERENCES PersonalSoporte(Codigo)
);
GO

-- Create DETALLE_REPOSICION table
CREATE TABLE DETALLE_REPOSICION (
    Codigo INT IDENTITY NOT NULL  PRIMARY KEY,
    Cantidad VARCHAR(45) NULL,
    PrecioUnitario VARCHAR(45) NULL,
    CodigoReposicion INT NOT NULL,
    CodigoMaterial INT NOT NULL,
	Vigente BIT NOT NULL Default 1,
    FOREIGN KEY (CodigoReposicion) REFERENCES ORDEN_REPOSICION(Codigo),
    FOREIGN KEY (CodigoMaterial) REFERENCES MATERIAL(Codigo)
);
GO

-- Create Entrada table
CREATE TABLE Entrada (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Fecha DATETIME NOT NULL,
	Motivo VARCHAR(45) NULL,
	NivelPrioridad CHAR(1),
	Estado CHAR(1),
	Vigente BIT NOT NULL Default 1,
    CodigoPersonalSoporte INT NOT NULL,
    CodigoDocumento INT NOT NULL,
    CodigoResponsable INT NOT NULL,
    FOREIGN KEY (CodigoPersonalSoporte) REFERENCES PersonalSoporte(Codigo),
    FOREIGN KEY (CodigoDocumento) REFERENCES Documento(Codigo),
    FOREIGN KEY (CodigoResponsable) REFERENCES Responsable(Codigo)
);
GO

-- Create Desarrollo table
CREATE TABLE Desarrollo (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
	FechaInicio DATETIME NOT NULL,
	FechaFinal DATETIME NOT NULL,
	Detalle TEXT NOT NULL,
	Estado CHAR(1),
    Vigente TINYINT NOT NULL DEFAULT 1,
    CodigoEntrada INT NOT NULL,
    FOREIGN KEY (CodigoEntrada) REFERENCES Entrada(Codigo)
);
GO

-- Create Salida table
CREATE TABLE Salida (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
	Fecha DATETIME NOT NULL,
	Observacion TEXT,
	Vigente TINYINT NOT NULL DEFAULT 1,
    CodigoDesarrollo INT NOT NULL,
    CodigoPersonalSoporte INT NOT NULL,
    CodigoResponsable INT NOT NULL,
    FOREIGN KEY (CodigoDesarrollo) REFERENCES Desarrollo(Codigo),
    FOREIGN KEY (CodigoPersonalSoporte) REFERENCES PersonalSoporte(Codigo),
    FOREIGN KEY (CodigoResponsable) REFERENCES Responsable(Codigo)
);
GO

-- Create DetalleEntrada table
CREATE TABLE DetalleEntrada (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
	Observacion TEXT,
	Vigente TINYINT NOT NULL DEFAULT 1,
    CodigoEquipo INT NOT NULL,
    CodigoEntrada INT NOT NULL,
    CodigoSalida INT NOT NULL,
    FOREIGN KEY (CodigoEquipo) REFERENCES Equipo(Codigo),
    FOREIGN KEY (CodigoEntrada) REFERENCES Entrada(Codigo),
    FOREIGN KEY (CodigoSalida) REFERENCES Salida(Codigo)
);
GO

-- Create Actividad table
CREATE TABLE Actividad (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    Fecha DATETIME NULL,
    Nombre VARCHAR(45) NOT NULL,
	Estado CHAR(1) NOT NULL,
    CodigoDesarrollo INT NOT NULL,
    FOREIGN KEY (CodigoDesarrollo) REFERENCES Desarrollo(Codigo)
);
GO

-- Create DETALLE_MATERIAL table
CREATE TABLE Detalle_Material (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    CodigoMaterial INT NOT NULL,
    CodigoActividad INT NOT NULL,
    FOREIGN KEY (CodigoMaterial) REFERENCES MATERIAL(Codigo),
    FOREIGN KEY (CodigoActividad) REFERENCES Actividad(Codigo)
);
GO

-- Create PersonalDesarrollo table
CREATE TABLE PersonalDesarrollo (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    CodigoPersonalSoporte INT NOT NULL,
    CodigoDesarrollo INT NOT NULL,
    FOREIGN KEY (CodigoPersonalSoporte) REFERENCES PersonalSoporte(Codigo),
    FOREIGN KEY (CodigoDesarrollo) REFERENCES Desarrollo(Codigo)
);
GO

-- Create ActividadDetalleEntrada table
CREATE TABLE ActividadDetalleEntrada (
    Codigo INT IDENTITY NOT NULL PRIMARY KEY,
    CodigoDetalleEntrada INT NOT NULL,
    CodigoActividad INT NOT NULL,
    FOREIGN KEY (CodigoDetalleEntrada) REFERENCES DetalleEntrada(Codigo),
    FOREIGN KEY (CodigoActividad) REFERENCES Actividad(Codigo)
);
GO

-- Drop the procedure if it already exists
IF OBJECT_ID('registrarEntrada', 'P') IS NOT NULL
DROP PROCEDURE registrarEntrada;
GO
