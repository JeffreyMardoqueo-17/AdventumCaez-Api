CREATE DATABASE AdventumCAEZ;
USE AdventumCAEZ;
GO

----------------------------// TABLAS SIN LLAVES FORÁNEAS


-- Tipo de pago (matrícula, cuota, etc.)
CREATE TABLE TipoPago (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-- Tipo de documento (NIE, DUI, pasaporte, etc.)
CREATE TABLE TipoDocumento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-- Turno (Mañana, tarde)
CREATE TABLE Turno (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-- Grado (Primero, Segundo, Tercero)
CREATE TABLE Grado (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

----------------------------// TABLAS CON LLAVES FORÁNEAS

-- Maestro (información del maestro)
CREATE TABLE Maestro (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Correo VARCHAR(150) NOT NULL,
    FechaNacimiento DATE,
    IdTipoDocumento INT NOT NULL FOREIGN KEY REFERENCES TipoDocumento(Id),
    NumDocumento VARCHAR(15) NOT NULL,
    InformacionPersonal VARCHAR(500)
);
GO

CREATE TABLE Encargado(
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Correo VARCHAR(150) NOT NULL,
    FechaNacimiento DATE,
    IdTipoDocumento INT NOT NULL FOREIGN KEY REFERENCES TipoDocumento(Id),
    NumDocumento VARCHAR(15) NOT NULL,
    InformacionPersonal VARCHAR(500)
);

-- Grupo (relaciona Grado con Turno y Maestro encargado)
CREATE TABLE Grupo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdGrado INT NOT NULL FOREIGN KEY REFERENCES Grado(Id),
    IdTurno INT NOT NULL FOREIGN KEY REFERENCES Turno(Id),
    IdMaestroEncargado INT NOT NULL FOREIGN KEY REFERENCES Maestro(Id)
);
GO
