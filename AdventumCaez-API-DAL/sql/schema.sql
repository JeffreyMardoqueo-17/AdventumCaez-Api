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
-- Grado (Maestro, director, tesoreero)
CREATE TABLE Cargo (
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
    InformacionPersonal VARCHAR(500),
);
GO

-------------------esto es para los administradores
CREATE TABLE Administrador (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdMaestro INT NOT NULL FOREIGN KEY REFERENCES Maestro(Id),
    IdCargo INT NOT NULL FOREIGN KEY REFERENCES Cargo(Id),
    FechaIngreso DATETIME DEFAULT GETDATE(),  -- Fecha de ingreso al rol de administrador
    Usuario VARCHAR(50) NOT NULL UNIQUE,  -- Nombre de usuario único
    Contraseña VARCHAR(255) NOT NULL,  -- Contraseña (recomiendo cifrarla antes de insertarla)
    UNIQUE(IdMaestro)  -- Para evitar que un maestro sea registrado más de una vez como administrador
);
GO

GO

---------ENCARGADO DE EL ALUMNO O LOS ALUMNOS 
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
-----------------------------ALUMNOS 

CREATE TABLE Alumno(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Telefono VARCHAR(15),
    Direccion VARCHAR(100) NOT NULL,
    IdEncargado INT NOT NULL FOREIGN KEY REFERENCES Encargado(Id),
    IdTipoDocumento INT NOT NULL FOREIGN KEY REFERENCES TipoDocumento(Id),
    NumDocumento VARCHAR (15) NOT NUll,
    IdGrupo INT NOT NULL FOREIGN KEY REFERENCES Grupo(Id),
    Estado BIT NOT NULL DEFAULT 1, ---  1: activo, 0 esat inactivo
);

GO

CREATE TABLE Pago (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdAlumno INT NOT NULL,
    IdAdministrador INT NOT NULL, -- Administrador que procesó el pago
    FechaPago DATETIME NOT NULL DEFAULT GETDATE(),
    MontoTotal DECIMAL(10,2) NOT NULL,
    EstadoPago BIT NOT NULL DEFAULT 1, -- 1: Pagado, 0: Pendiente
    NombrePagador VARCHAR(100) NOT NULL, -- Nombre de la persona que hizo el pago
    TipoPagador VARCHAR(50) NOT NULL CHECK (TipoPagador IN ('Alumno', 'Encargado', 'Otro')), -- Quién pagó
    FOREIGN KEY (IdAlumno) REFERENCES Alumno(Id),
    FOREIGN KEY (IdAdministrador) REFERENCES Administrador(Id) -- Relación con el admin
);
GO

CREATE TABLE DetallePago (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdPago INT NOT NULL,
    IdTipoPago INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdPago) REFERENCES Pago(Id),
    FOREIGN KEY (IdTipoPago) REFERENCES TipoPago(Id)
);
GO
