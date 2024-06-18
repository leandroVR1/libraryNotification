-- Active: 1716860430489@@127.0.0.1@3306@b6rv4kq1zn9llto4y79h

----------### MODELO PRINCIPAL DE USUARIOS ###---------- 
-----## Crear Tabla Usuarios ##-----
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(125) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Documento VARCHAR(255) NOT NULL,
    IdTipoDocumento INT,
    IdRol INT,
    FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumentos(Id),
    FOREIGN KEY (IdRol) REFERENCES Roles(Id)
);

-----## Tabla Tabla TipoDocumentos
CREATE TABLE TipoDocumentos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(125) NOT NULL
);

-----## Crear Tabla Roles
CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(45) NOT NULL
);

-----## Crear Tabla HistorialRedimidos ##-----
CREATE TABLE HistorialRedimidos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdCupon INT,
    IdUsuario INT,
    FOREIGN KEY (IdCupon) REFERENCES Cupones(Id),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
);

----------### MODELO PRINCIPAL DE CUPONES ###---------- 
-----## Crear Tabla Cupones ##-----
CREATE TABLE Cupones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Descuento DOUBLE NOT NULL,
    CantidadDisponible INT NOT NULL,
    LimiteUsoUsuario INT NOT NULL,
    IdEmpleado INT,
    IdMarca INT,
    IdRegistroFechas INT,
    IdEstado INT,
    IdTipoDescuento INT,
    IdRangoPrecio INT NOT NULL,
    FOREIGN KEY (IdRegistroFechas) REFERENCES RegistroFechas(Id),
    FOREIGN KEY (IdEstado) REFERENCES Estados(Id),
    FOREIGN KEY (IdTipoDescuento) REFERENCES TipoDescuentos(Id),
    FOREIGN KEY (IdRangoPrecio) REFERENCES RangosPrecio(Id)
);

-----## Crear Tabla TipoDescuentos
CREATE TABLE TipoDescuentos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-----## Crear Tabla RangosPrecios
CREATE TABLE RangosPrecio(
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Minimo DOUBLE,
    Maximo DOUBLE
);

-----## Crear Tabla Estado
-- Se refiere al tipo de estado del cupon; si activo, inactivo o creado 
CREATE TABLE Estados (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(45),
);

-----## Crear Tabla RegistroFechas
CREATE TABLE RegistroFechas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FechaCreacion DATE,
    FechaActivacion DATE,
    FechaExpiracion DATE
);

-----## Crear Tabla Marcas ##-----
CREATE TABLE Marcas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
)