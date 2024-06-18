----------### DATOS PRINCIPAL DE USUARIOS ###---------- 
-----## Crear Datos Usuarios ##-----
INSERT INTO Usuarios (Nombre, Email, Password, Documento, IdTipoDocumento, IdRol) VALUES 
('Juan Perez', 'juan.perez@example.com', 'hashed_password', '12345678', 1, 1),
('Maria Lopez', 'maria.lopez@example.com', 'hashed_password', '87654321', 2, 2);

-----## Data Roles
INSERT INTO Roles (Nombre) VALUES
('Cliente'),
('Admin'),
('Marketing');

-----## Data TipoDocumentos
INSERT INTO TipoDocumentos (Nombre) VALUES
('Cedula'),
('DNI'),
('Pasaporte');

-----## Crear Datos HistorialRedimidos
INSERT INTO HistorialRedimidos (IdCupon, IdUsuario) VALUES
(20, 2),
(21, 1),
(20, 2),
(22, 1);
----------### DATOS PRINCIPAL DE CUPONES ###---------- 
-----## Crear Datos Cupones ##-----
INSERT INTO Cupones (Nombre, Descuento, CantidadDisponible, IdEmpleado, IdRangoPrecio, LimiteUsoUsuario, IdEstado, IdTipoDescuento) VALUES 
('Zanahorias florencia', 10.0, 100, 1, 1, 2, 1, 1),
('Frutas D1', 15.0, 20, 2, 5, 3, 1, 1),
('Comida italiana', 25.0, 30, 1, 3, 2, 1, 1),
('Ropa infantil', 5.0, 40, 1, 1, 1, 2, 2),
('Ingles empresarial', 20.0, 50, 2, 1, 1, 2, 2);

-----## Crear Datos TipoDescuentos
INSERT INTO TipoDescuentos (Nombre) VALUES
('Porcentaje'),
('Monto fijo');

-----## Crear Datos RangosPrecio
INSERT INTO RangosPrecio (Minimo, Maximo) VALUES
(0, 10),
(11, 20),
(21, 30),
(31, 40),
(41, 50);

-----## Crear Datos Estados
INSERT INTO Estados (Nombre) VALUES
('Creado'),
('Activo'),
('Inactivo');

-----## Crear Datos RegistroFechas
INSERT INTO RegistroFechas (FechaCreacion, FechaActivacion, FechaExpiracion) VALUES 
('2023-01-01', '2023-02-01', '2023-12-31'),
('2023-03-01', '2023-04-01', '2023-11-30');

-----## Crear Datos Marcas ##-----
INSERT INTO Marcas (Nombre) VALUES
('McDonalds'),
('Exito'),
('Hogar y Moda');