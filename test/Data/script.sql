-- Active: 1716325718623@@b6rv4kq1zn9llto4y79h-mysql.services.clever-cloud.com@3306@b6rv4kq1zn9llto4y79h
-- -- Crear tabla Roles
-- CREATE TABLE Roles (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(45) NOT NULL
-- );

-- Insertar roles iniciales
-- INSERT INTO Roles (Nombre) VALUES ('Cliente'), ('Admin'), ('Marketing');

-- Crear tabla TipoDocumentos
-- CREATE TABLE TipoDocumentos (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(125) NOT NULL
-- );

-- Insertar tipos de documentos iniciales
-- INSERT INTO TipoDocumentos (Nombre) VALUES ('DNI'), ('Pasaporte');

-- -- Crear tabla Usuarios
-- CREATE TABLE Usuarios (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(125) NOT NULL,
--     Email VARCHAR(255) NOT NULL,
--     Password VARCHAR(255) NOT NULL,
--     Documento VARCHAR(255) NOT NULL,
--     IdTipoDocumento INT,
--     IdRol INT,
--     FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumentos(Id),
--     FOREIGN KEY (IdRol) REFERENCES Roles(Id)
-- );


ALTER TABLE `Cupones`
ADD FOREIGN KEY (IdEmpleado) REFERENCES `Usuarios` (Id)

-- Insertar usuarios iniciales (ejemplo)
-- INSERT INTO Usuarios (Nombre, Email, Password, Documento, IdTipoDocumento, IdRol) VALUES 
-- ('Juan Perez', 'juan.perez@example.com', 'hashed_password', '12345678', 1, 1),
-- ('Maria Lopez', 'maria.lopez@example.com', 'hashed_password', '87654321', 2, 2);

-- Crear tabla Estados
-- CREATE TABLE Estados (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(50) NOT NULL
-- );

-- Insertar estados iniciales
-- INSERT INTO Estados (Nombre) VALUES ('Activo'), ('Inactivo');

-- -- Crear tabla TipoDescuentos
-- CREATE TABLE TipoDescuentos (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(50) NOT NULL
-- );

-- Insertar tipos de descuentos iniciales
-- INSERT INTO TipoDescuentos (Nombre) VALUES ('Porcentaje'), ('Monto fijo');

-- -- Crear tabla RegistroFechas
-- CREATE TABLE RegistroFechas (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     FechaCreacion DATE,
--     FechaActivacion DATE,
--     FechaExpiracion DATE
-- );

-- Insertar registros de fechas iniciales (ejemplo)
INSERT INTO RegistroFechas (FechaCreacion, FechaActivacion, FechaExpiracion) VALUES 
('2023-01-01', '2023-02-01', '2023-12-31'),
('2023-03-01', '2023-04-01', '2023-11-30');

-- Crear tabla Cupones
-- CREATE TABLE Cupones (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(255) NOT NULL,
--     Descuento DOUBLE NOT NULL,
--     RangoPrecio DOUBLE NOT NULL,
--     CantidadDisponible INT NOT NULL,
--     LimiteUsoUsuario INT NOT NULL,
--     IdEmpleado INT,
--     IdMarca INT,
--     IdRegistroFechas INT,
--     IdEstado INT,
--     IdTipoDescuento INT,
--     FOREIGN KEY (IdRegistroFechas) REFERENCES RegistroFechas(Id),
--     FOREIGN KEY (IdEstado) REFERENCES Estados(Id),
--     FOREIGN KEY (IdTipoDescuento) REFERENCES TipoDescuentos(Id)
-- );

-- Insertar cupones iniciales
INSERT INTO Cupones (Nombre, Descuento, RangoPrecio, CantidadDisponible, LimiteUsoUsuario, IdEstado, IdTipoDescuento) VALUES 
('CUPON10', 10.0, 50.0, 100, 2, 1, 1),
('CUPON15', 15.0, 75.0, 50, 3, 1, 1),
('CUPON25', 25.0, 125.0, 75, 5, 1, 1),
('CUPON5', 5.0, 30.0, 10, 1, 2, 2),
('CUPON20', 20.0, 100.0, 0, 1, 2, 2);

ALTER TABLE `Cupones`
ADD IdRangoPrecio INT;

ALTER TABLE `Cupones`
ADD FOREIGN KEY (IdRangoPrecio) REFERENCES `RangosPrecio` (Id)

-- Crear tabla HistorialRedimidos
-- CREATE TABLE HistorialRedimidos (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     IdCupon INT,
--     IdUsuario INT,
--     FOREIGN KEY (IdCupon) REFERENCES Cupones(Id),
--     FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
-- );

-- Insertar historial redimidos iniciales (ejemplo)
INSERT INTO HistorialRedimidos (IdCupon, IdUsuario) VALUES 
(1, 1),
(2, 1);


-- CREATE TABLE Marca (
--     Id INT AUTO_INCREMENT PRIMARY KEY,
--     Nombre VARCHAR(255) NOT NULL
-- )

ALTER TABLE `Cupones`
ADD FOREIGN KEY (IdMarca) REFERENCES `Marca` (Id)

-- INSERT INTO Marca (Nombre) VALUES
-- ('McDonalds'),
-- ('Exito'),
-- ('Hogar y Moda')