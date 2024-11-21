DROP DATABASE IF EXISTS CALLCENTER;
go
create database CALLCENTER;
go
use CALLCENTER;
go

-- TIPO INCIDENCIA
CREATE TABLE TIPO_INCIDENCIA(
Id int identity(1,1) not null primary key,
Nombre varchar(70) not null unique,
Visible bit not null,
Activo bit not null)
go
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Demoras en la Entrega', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Producto Defectuoso o Dañado', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Cambio o Devolución', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Garantías y Reparaciones', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Errores en el Pedido', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Problemas con Facturación', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Atención en Tienda Física', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Problemas en el Sitio Web/App', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Problemas con el Envío', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Consulta o Reclamo por Promociones', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Soporte Técnico para Electrodomésticos/Electrónica', 1, 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES ('Cobertura de Garantía Extendida', 1, 1);
go

-- PRIORIDADES
create table PRIORIDADES(
Id int identity(1,1) not null primary key,
Nombre varchar(30) not null unique,
Visible bit NOT NULL, 
Activo bit not null)
go
insert into PRIORIDADES (Nombre, Visible, Activo)
values ('Urgente',1,1);
insert into PRIORIDADES (Nombre, Visible, Activo)
values ('Alta',1,1);
insert into PRIORIDADES (Nombre, Visible, Activo)
values ('Media',1,1);
insert into PRIORIDADES (Nombre, Visible, Activo)
values ('Baja',1,1);
go

-- ESTADOS
create table ESTADOS(
Id int identity(1,1) not null primary key,
Nombre varchar(30) not null unique,
EstadoFinal bit not null,
Activo bit not null)
go
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('Abierto', 0, 1);
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('Asignado', 0, 1);
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('En Analisis', 0, 1);
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('Resuelto', 1, 1);
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('Cerrado', 1, 1);
insert into ESTADOS (Nombre, EstadoFinal, Activo)
values ('Reabierto', 0, 1);
go

-- PERSONAS
create table PERSONAS(
Id bigint identity(1,1) not null primary key,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Email varchar(80) not null)
go
insert into PERSONAS values 
('Bart','Simpson','bartsimpson@gmail.com'),
('Homero','Thompson','homerothompson@hotmail.com'),
('Jony','Bocacerrada','jonybocacerrada@yahoo.com.ar'),
('Juan', 'Pérez', 'juan.perez@email.com'),
('María', 'González', 'maria.gonzalez@email.com'),
('Carlos', 'Rodríguez', 'carlos.rodriguez@email.com'),
('Ana', 'Martínez', 'ana.martinez@email.com'),
('Pedro', 'López', 'pedro.lopez@email.com'),
('Sofía', 'Gómez', 'sofia.gomez@email.com'),
('Martín', 'Fernández', 'martin.fernandez@email.com'),
('Laura', 'Sánchez', 'laura.sanchez@email.com'),
('Luis', 'Ramírez', 'luis.ramirez@email.com'),
('Carla', 'Torres', 'carla.torres@email.com'),
('Javier', 'Álvarez', 'javier.alvarez@email.com'),
('Paula', 'Romero', 'paula.romero@email.com'),
('Daniel', 'Moreno', 'daniel.moreno@email.com'),
('Gabriela', 'Ortiz', 'gabriela.ortiz@email.com'),
('Miguel', 'Silva', 'miguel.silva@email.com'),
('Camila', 'Gutiérrez', 'camila.gutierrez@email.com'),
('Fernando', 'Castro', 'fernando.castro@email.com'),
('Valeria', 'Reyes', 'valeria.reyes@email.com'),
('Diego', 'Molina', 'diego.molina@email.com'),
('Elena', 'Cruz', 'elena.cruz@email.com'),
('Alberto', 'Herrera', 'alberto.herrera@email.com'),
('Verónica', 'Ríos', 'veronica.rios@email.com'),
('Ricardo', 'Vega', 'ricardo.vega@email.com'),
('Claudia', 'Pardo', 'claudia.pardo@email.com'),
('Pablo', 'Navarro', 'pablo.navarro@email.com'),
('Natalia', 'Fuentes', 'natalia.fuentes@email.com'),
('Andrés', 'Suárez', 'andres.suarez@email.com'),
('Florencia', 'Escobar', 'florencia.escobar@email.com'),
('Ramiro', 'Peña', 'ramiro.pena@email.com'),
('Carolina', 'Carrillo', 'carolina.carrillo@email.com'),
('Sebastián', 'Rojas', 'sebastian.rojas@email.com'),
('Julia', 'Villanueva', 'julia.villanueva@email.com'),
('Mauricio', 'Aguilar', 'mauricio.aguilar@email.com'),
('Lucía', 'Correa', 'lucia.correa@email.com'),
('Esteban', 'Paredes', 'esteban.paredes@email.com'),
('Isabel', 'Mendoza', 'isabel.mendoza@email.com'),
('Santiago', 'Campos', 'santiago.campos@email.com'),
('Clara', 'Luna', 'clara.luna@email.com'),
('Emiliano', 'Bravo', 'emiliano.bravo@email.com'),
('Victoria', 'Solano', 'victoria.solano@email.com'),
('Cristian', 'Delgado', 'cristian.delgado@email.com'),
('Marina', 'Ibáñez', 'marina.ibanez@email.com'),
('Óscar', 'Espinoza', 'oscar.espinoza@email.com'),
('Daniela', 'Cabrera', 'daniela.cabrera@email.com'),
('Hernán', 'Guerrero', 'hernan.guerrero@email.com'),
('Alicia', 'Paz', 'alicia.paz@email.com'),
('Rafael', 'Benítez', 'rafael.benitez@email.com'),
('Mónica', 'Montes', 'monica.montes@email.com'),
('Agustín', 'Campos', 'agustin.campos@email.com'),
('Cecilia', 'Villalobos', 'cecilia.villalobos@email.com'),
('Guillermo', 'Estrada', 'guillermo.estrada@email.com'),
('Roxana', 'Salinas', 'roxana.salinas@email.com'),
('Fabián', 'Tapia', 'fabian.tapia@email.com'),
('Amelia', 'Godoy', 'amelia.godoy@email.com'),
('Enrique', 'Maldonado', 'enrique.maldonado@email.com'),
('Gloria', 'Araya', 'gloria.araya@email.com'),
('Hugo', 'Lara', 'hugo.lara@email.com'),
('Teresa', 'Vargas', 'teresa.vargas@email.com'),
('Marcelo', 'León', 'marcelo.leon@email.com'),
('Rosa', 'Medina', 'rosa.medina@email.com'),
('Iván', 'Cordero', 'ivan.cordero@email.com'),
('Estela', 'Núñez', 'estela.nunez@email.com'),
('Rodrigo', 'Sandoval', 'rodrigo.sandoval@email.com'),
('Silvia', 'Cortés', 'silvia.cortes@email.com'),
('Tomás', 'Quiroga', 'tomas.quiroga@email.com');
go

--TIPOS DE USUARIOS
create table TIPOS_USUARIOS(
IdTipoUsuario tinyint primary key,
Tipo varchar(50) not null
)
go
insert into TIPOS_USUARIOS(IdTipoUsuario,Tipo)
values (1,'Administrador'), (2,'Supervisor'),(3,'Operador');

-- EMPLEADOS
create table EMPLEADOS(
Legajo bigint identity(100001,1) not null primary key,
IdPersona bigint not null,
UserPassword varchar(20) not null,
TipoUsuario tinyint not null,
FechaIngreso date not null check(FechaIngreso <= getdate()),
ImagenPerfil varchar(100),
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id),
foreign key (TipoUsuario) references TIPOS_USUARIOS(IdTipoUsuario)
)
GO
set dateformat dmy
INSERT INTO EMPLEADOS (IdPersona, UserPassword, TipoUsuario, FechaIngreso, ImagenPerfil, Activo) VALUES
(1,'Milhouse1',3,'26-10-2024', NULL, 1),
(2,'Springfield1',2,'26-10-2023', NULL, 1),
(3,'Nodirenada1',1,'10-10-2020', NULL, 1),
(9, 'Clave123', 1, '2022-02-15', NULL, 1), 
(15, 'Pass456', 3, '2023-03-10', NULL, 1), 
(21, 'Segur789', 2, '2020-06-01', NULL, 1), 
(30, 'Admin321', 3, '2019-12-11', NULL, 1), 
(42, 'Clave654', 1, '2021-08-25', NULL, 1), 
(10, 'Secure12', 3, '2020-10-20', NULL, 1), 
(19, 'Pass890', 2, '2021-03-13', NULL, 1), 
(34, 'Clave111', 3, '2022-05-05', NULL, 1), 
(27, 'Admin222', 1, '2021-12-19', NULL, 1), 
(8, 'Super333', 2, '2022-09-10', NULL, 1), 
(50, 'Inact123', 3, '2020-04-07', NULL, 0),
(63, 'Clave999', 1, '2019-11-15', NULL, 0),
(6, 'Secure34', 2, '2020-01-23', NULL, 0), 
(40, 'Admin345', 3, '2021-07-30', NULL, 0),
(56, 'Pass678', 3, '2023-01-03', NULL, 0), 
(22, 'Clave432', 2, '2022-06-09', NULL, 1),
(11, 'Secure56', 3, '2023-02-14', NULL, 1); 
GO


-- PAIS
CREATE TABLE PAISES(
Id bigint identity(1,1) not null primary key,
Nombre varchar(50) not null unique,
Activo bit not null
)
GO
INSERT INTO PAISES (Nombre, Activo) VALUES ('Argentina', 1);
INSERT INTO PAISES (Nombre, Activo) VALUES ('Uruguay', 1);
INSERT INTO PAISES (Nombre, Activo) VALUES ('Peru', 0);
GO

-- PROVINCIAS
CREATE TABLE PROVINCIAS(
Id bigint identity(1,1) not null primary key,
Nombre varchar(50) not null unique,
IdPais bigint not null,
Visible bit not null,
Activo bit not null,
FOREIGN KEY (IdPais) REFERENCES PAISES (Id)
)
go
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Buenos Aires', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('CABA', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Catamarca', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Chaco', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Chubut', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Córdoba', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Corrientes', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Entre Ríos', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Formosa', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Jujuy', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('La Pampa', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('La Rioja', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Mendoza', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Misiones', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Neuquén', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Río Negro', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Salta', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('San Juan', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('San Luis', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Santa Cruz', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Santa Fe', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Santiago del Estero', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Tierra del Fuego', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Tucumán', 1, 1, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Montevideo', 1, 2, 1);
INSERT INTO PROVINCIAS (Nombre, Visible, IdPais, Activo) VALUES ('Salto', 1, 2, 0);

GO

-- DIRECCIONES
CREATE TABLE DIRECCIONES(
Id bigint identity(1,1) not null primary key,
Calle varchar(70) not null,
Numero bigint not null,
Localidad varchar(70) not null,
CodPostal varchar(20) not null,
IdProvincia bigint not null FOREIGN KEY REFERENCES PROVINCIAS (Id))
go
INSERT INTO CALLCENTER.dbo.DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia) VALUES
('Av. Rivadavia', 1234, 'Buenos Aires', 'C1033AAC', 1),
('Calle Corrientes', 567, 'CABA', 'C1043AAE', 2),
('San Martín', 890, 'Catamarca', 'K4700AAD', 3),
('Av. 25 de Mayo', 432, 'Resistencia', 'H3500AAD', 4),
('Alberdi', 765, 'Rawson', 'U9103AAC', 5),
('Av. Colón', 234, 'Córdoba', 'X5000AAE', 6),
('Belgrano', 678, 'Corrientes', 'W3400AAB', 7),
('Urquiza', 345, 'Paraná', 'E3100AAB', 8),
('Mitre', 890, 'Formosa', 'P3600AAC', 9),
('Av. Bolivia', 456, 'San Salvador', 'Y4600AAD', 10),
('9 de Julio', 567, 'Santa Rosa', 'L6300AAB', 11),
('Avenida Perón', 123, 'La Rioja', 'F5300AAC', 12),
('San Juan', 234, 'Mendoza', 'M5500AAB', 13),
('Independencia', 678, 'Posadas', 'N3300AAC', 14),
('Neuquén Capital', 345, 'Neuquén', 'Q8300AAD', 15),
('Las Flores', 567, 'Bariloche', 'R8400AAB', 16),
('San Martín', 123, 'Salta', 'A4400AAC', 17),
('Mitre', 890, 'San Juan', 'J5400AAD', 18),
('España', 456, 'San Luis', 'D5700AAC', 19),
('Pueyrredón', 567, 'Río Gallegos', 'Z9400AAB', 20),
('Santa Fe', 890, 'Santa Fe', 'S3000AAC', 21),
('Libertad', 123, 'Santiago del Estero', 'G4200AAD', 22),
('Belgrano', 456, 'Río Grande', 'V9410AAC', 23),
('Tucumán', 234, 'San Miguel', 'T4000AAC', 24),
('Av. Artigas', 567, 'Montevideo', '11000', 25),
('18 de Julio', 345, 'Montevideo', '11200', 25),
('Gral. Rivera', 890, 'Montevideo', '11300', 25),
('Camino Maldonado', 456, 'Montevideo', '11400', 25),
('Bulevar España', 123, 'Montevideo', '11500', 25),
('Luis Alberto Herrera', 234, 'Montevideo', '11600', 25);
go


-- CLIENTES
create table CLIENTES(
IdPersona bigint not null primary key,
Dni bigint not null unique,
FechaNacimiento date not null check(FechaNacimiento <= dateadd(year,-18, getdate())),
IdDireccion bigint not null,
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id),
foreign key (IdDireccion) references DIRECCIONES(Id)
)
go
set dateformat dmy
INSERT INTO CLIENTES (IdPersona, Dni, FechaNacimiento, IdDireccion, Activo) VALUES
(4, 1234567849, '1995-05-14', 1, 1),
(5, 9876543421, '1994-03-22', 2, 1),
(7, 1112234344, '1992-07-01', 3, 1),
(12, 5566477889, '1993-11-11', 4, 1),
(13, 223344656, '1991-01-15', 5, 1),
(14, 3344565467, '1990-12-30', 6, 1),
(16, 445566778, '1992-09-10', 7, 1),
(17, 5544336541, '1990-10-01', 8, 1),
(18, 6677889540, '1991-06-17', 9, 1),
(20, 123987654, '1989-02-25', 10, 1),
(23, 456786523, '1990-05-30', 11, 1),
(24, 678901234, '1992-08-05', 12, 1),
(25, 789012345, '1994-04-11', 13, 1),
(26, 8901234456, '1991-12-17', 14, 1),
(28, 9012345467, '1990-03-20', 15, 1),
(29, 1029384745, '1989-11-13', 16, 1),
(31, 1114444444, '1992-07-15', 17, 1),
(32, 223344556, '1991-01-05', 18, 1),
(33, 3344455667, '1990-12-03', 19, 1),
(35, 4455466778, '1994-02-28', 20, 1),
(36, 5566747889, '1993-10-12', 21, 1),
(37, 6677884990, '1991-06-15', 22, 1),
(38, 7788990401, '1990-09-05', 23, 1),
(39, 8899001142, '1992-05-22', 24, 1),
(41, 998877665, '1991-04-13', 25, 1),
(43, 556677889, '1993-07-28', 26, 0),
(44, 2233445456, '1992-08-14', 27, 0),
(45, 334455667, '1991-11-02', 28, 0),
(46, 4455667478, '1992-09-10', 29, 0),
(47, 5544332241, '1990-06-17', 30, 0);
go

-- TELEFONOS
create table TELEFONOS(
IdTelefono int identity(1,1) primary key,
IdPersona bigint not null,
NumeroTelefono bigint not null,
foreign key (IdPersona) references CLIENTES(IdPersona)
)
go
INSERT INTO TELEFONOS (IdPersona, NumeroTelefono) VALUES
(4, 1122334455),
(5, 22334458756),
(7, 3344556677),
(12, 4455667788),
(13, 5566778899),
(14, 6677889900),
(16, 7788990011),
(17, 8899001122),
(18, 9900112233),
(20, 1012233445),
(23, 2023344556),
(24, 3034455667),
(25, 4045566778),
(26, 5056677889),
(28, 6067788990),
(29, 7078899001),
(31, 8089900112),
(32, 9091001123),
(33, 1012122233),
(35, 2023233344),
(36, 3034344455),
(37, 4045455566),
(38, 5056566677),
(39, 6067677788),
(41, 7078788899),
(43, 8089899000),
(44, 9091000111),
(45, 1012111222),
(46, 2023222333),
(47, 3034333444);
go

-- INCIDENCIAS
create table INCIDENCIAS(
Codigo int identity(1000,1) not null primary key,
DniCliente bigint not null,
LegajoEmpleado bigint not null,
Descripcion varchar(1000) not null,
Estado int not null,
Prioridad int not null,
IdTipoIncidencia int not null,
FechaAlta smalldatetime,
FechaCierre smalldatetime,
Resolucion Varchar(200),
FOREIGN KEY (DniCliente) REFERENCES Clientes(Dni),
foreign key (LegajoEmpleado) references EMPLEADOS(Legajo))

go
set dateformat ymd
go
INSERT INTO INCIDENCIAS (DniCliente, LegajoEmpleado, Descripcion, Estado, Prioridad, IdTipoIncidencia, FechaAlta, FechaCierre, Resolucion) VALUES
(1234567849, 100001, 'Producto defectuoso, no enciende correctamente', 4, 3, 2, '2023-04-10', '2023-04-12', 'Producto reemplazado por uno nuevo'),
(9876543421, 100001, 'Demora en la entrega del pedido', 1, 2, 1, '2024-02-15', NULL, NULL),
(1112234344, 100002, 'Error en el pedido, se recibió artículo equivocado', 2, 4, 5, '2023-05-20', NULL, NULL),
(556677889, 100003, 'Falta un artículo en el paquete', 3, 2, 5, '2024-03-10', NULL, NULL),
(223344556, 100004, 'Producto dañado, caja rota al recibirlo', 4, 3, 2, '2023-11-05', '2023-11-07', 'Producto retornado y se envió reemplazo'),
(334455667, 100005, 'Pedido equivocado en el sitio web', 5, 1, 5, '2024-01-25', '2024-01-28', 'Se realizó corrección y reenvío correcto'),
(445566778, 100006, 'Demora en la entrega', 3, 2, 1, '2023-08-09', NULL, NULL),
(123987654, 100009, 'Problema con el pago, no fue procesado correctamente', 2, 3, 6, '2023-07-10', NULL, NULL),
(678901234, 100011, 'El paquete llegó con retraso', 1, 4, 9, '2023-11-01', NULL, NULL),
(789012345, 100012, 'No se pudo acceder al sitio para realizar compra', 3, 1, 8, '2024-04-10', NULL, NULL),
(1112234344, 100016, 'Falta artículo en la caja', 3, 1, 5, '2023-06-05', NULL, NULL),
(223344556, 100017, 'Devolución rechazada por política', 3, 2, 3, '2024-01-02', NULL, NULL),
(334455667, 100018, 'Problemas con la página al intentar comprar', 1, 4, 8, '2023-10-12', NULL, NULL),
(445566778, 100019, 'Paquete recibido con daño', 5, 2, 2, '2024-03-12', '2024-03-14', 'Producto reemplazado sin costo adicional'),
(556677889, 100020, 'Error en la compra, artículo no se refleja en carrito', 4, 3, 8, '2023-06-19', '2023-06-22', 'Error corregido y compra validada'),
(123987654, 100001, 'Problema con el pago de la compra', 2, 4, 6, '2023-09-11', NULL, NULL),
(678901234, 100003, 'No se puede acceder a la app desde celular', 3, 1, 8, '2023-11-22', NULL, NULL),
(789012345, 100004, 'Producto que no se corresponde con el pedido', 5, 2, 5, '2024-01-19', '2024-01-21', 'Pedido corregido y reenviado'),
(1112234344, 100008, 'Error con el código de descuento', 5, 3, 9, '2023-05-15', '2023-05-17', 'Descuento aplicado correctamente'),
(223344556, 100009, 'Problema con el envío, producto extraviado', 4, 2, 10, '2023-10-15', '2023-10-18', 'Producto reenviado sin costo adicional'),
(334455667, 100010, 'No llega el correo de confirmación', 3, 4, 8, '2024-01-05', NULL, NULL),
(445566778, 100011, 'Faltan productos en la entrega', 1, 2, 5, '2023-07-30', NULL, NULL),
(556677889, 100012, 'Producto con defecto de fabricación', 4, 1, 2, '2023-05-22', '2023-05-24', 'Producto retornado y reemplazado'),
(123987654, 100014, 'Devolución no registrada correctamente', 5, 2, 3, '2023-06-07', '2023-06-09', 'Devolución procesada y validada'),
(678901234, 100016, 'Falta confirmar el pago', 3, 3, 6, '2023-05-18', NULL, NULL),
(789012345, 100017, 'Problema con la dirección de entrega', 2, 2, 9, '2024-03-10', NULL, NULL),
(1112234344, 100001, 'Producto defectuoso, no arranca', 4, 3, 2, '2024-02-05', '2024-02-07', 'Producto reemplazado por uno nuevo'),
(223344556, 100001, 'Demora en la entrega, no llega a tiempo', 1, 2, 1, '2023-10-20', NULL, NULL),
(334455667, 100002, 'Error en el pago, transacción fallida', 3, 4, 6, '2024-02-07', NULL, NULL),
(445566778, 100003, 'No se puede acceder a la cuenta de usuario', 2, 1, 8, '2023-12-25', NULL, NULL),
(556677889, 100004, 'Devolución no procesada correctamente', 3, 2, 3, '2024-01-18', NULL, NULL),
(123987654, 100006, 'No se reflejan los descuentos aplicados', 1, 3, 9, '2024-01-25', NULL, NULL);

go

-- COMENTARIOS
create table COMENTARIOS(
id int not null identity(1,1),
Cod_Incidencia int not null,
Comentario varchar(200) not null,
Fecha smalldatetime not null,
LegajoUsuario bigint not null
)
go
set dateformat dmy
go
insert into COMENTARIOS
values (1001, 'Se verifica que no tiene deuda y se procede la baja', '13/12/2023', 100001)
insert into Comentarios
values (1000, 'Se solicta comprobante de pago correspondiente', '23/03/2023', 100001)
insert into Comentarios
values (1002, 'Plan dentaaaaal', '22/06/2024', 100002)
insert into Comentarios
values (1002, 'Lisa necesita frenos', '23/06/2024', 100003)
insert into Comentarios
values (1002, 'Plan dentaaaaal', GETDATE(), 100002)
go

--Store Procedure AgregarEmpleado
create procedure sp_AgregarEmpleado
@Nombre varchar(50),
@Apellido varchar(50),
@Email varchar(80),
@UserPassword varchar(20),
@TipoUsuario tinyint,
@FechaIngreso date,
@Activo bit
as begin
begin transaction;
begin try
	declare @IdPersona bigint;
	insert into PERSONAS(Nombre,Apellido,Email)
	values(@Nombre,@Apellido,@Email);
	set @IdPersona = SCOPE_IDENTITY();
	insert into EMPLEADOS(IdPersona,UserPassword,TipoUsuario,FechaIngreso,Activo)
	values(@IdPersona,@UserPassword,@TipoUsuario,@FechaIngreso,@Activo);
	commit transaction
end try
begin catch
rollback transaction;
throw;
end catch
end;
GO

--Store Procedure ModificarEmpleado
create procedure sp_ModificarEmpleado
@Legajo bigint,
@Nombre varchar(50),
@Apellido varchar(50),
@Email varchar(80),
@UserPassword varchar(20),
@TipoUsuario tinyint,
@FechaIngreso date,
@ImagenPerfil varchar(100),
@Activo bit
as
begin
    begin transaction;
    begin try
        update dbo.PERSONAS
        set Nombre = @Nombre, Apellido = @Apellido, Email = @Email
        where Id = (select IdPersona from dbo.EMPLEADOS where Legajo = @Legajo);
        update dbo.EMPLEADOS
        set UserPassword = @UserPassword, TipoUsuario = @TipoUsuario, FechaIngreso = @FechaIngreso, ImagenPerfil=@ImagenPerfil,
            Activo = @Activo
        where Legajo = @Legajo;
        commit transaction;
    end try
    begin catch
        rollback transaction;
        throw;
    end catch
end;
GO

--Store Procedure EliminarEmpleado
create procedure sp_EliminarEmpleado
@Legajo bigint
as
begin
    begin transaction;
    begin try
        declare @IdPersona bigint;
        select @IdPersona = IdPersona from EMPLEADOS where Legajo = @Legajo;
        if @IdPersona is not null
        begin
            delete from EMPLEADOS where Legajo = @Legajo;
            delete from PERSONAS where Id = @IdPersona;
            commit transaction;
        end
		else
		begin
            rollback transaction;
        end
    end try
    begin catch
        rollback transaction;
        throw;
    end catch
end;
GO

-- Procedure para Creacion de Cliente
CREATE PROCEDURE sp_RegistrarCliente
@Nombre varchar(50),
@Apellido varchar(50),
@Email varchar(80),
@Dni bigint,
@FechaNac date,
@Calle varchar(70),
@Numero bigint,
@Localidad varchar(70),
@CodPostal varchar(20),
@IdProvincia bigint
as BEGIN
	BEGIN TRANSACTION 
	BEGIN TRY
		Declare @IdDireccion bigint
		INSERT INTO dbo.DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia) VALUES (@Calle, @Numero, @Localidad, @CodPostal, @IdProvincia);
		set @IdDireccion = SCOPE_IDENTITY();
	
		Declare @IdPersona bigint
		INSERT INTO dbo.PERSONAS (Nombre, Apellido, Email) Values (@Nombre, @Apellido, @Email);
		Set @IdPersona = SCOPE_IDENTITY();
	
		INSERT INTO dbo.Clientes (IdPersona, Dni, FechaNacimiento, IdDireccion, Activo)  VALUES(@IdPersona, @Dni, @FechaNac, @IdDireccion, 1)

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END;
GO

--Procedure Modificacion de Cliente
create procedure sp_ModificarCliente
@Nombre varchar(50),
@Apellido varchar(50),
@Email varchar(80),
@Dni bigint,
@FechaNac date,
@IdDireccion bigint,
@Activo bit,
@Calle varchar(70),
@Numero bigint,
@Localidad varchar(70),
@CodPostal varchar(20),
@IdProvincia bigint
as
begin
    begin transaction;
    begin try
        update dbo.PERSONAS set Nombre = @Nombre, Apellido = @Apellido, Email = @Email where Id = (select IdPersona from dbo.CLIENTES where Dni = @Dni);
        update dbo.CLIENTES set FechaNacimiento = @FechaNac, IdDireccion = @IdDireccion, Activo = @Activo where Dni = @Dni;
        update dbo.DIRECCIONES set Calle = @Calle, Numero = @Numero, Localidad = @Localidad, CodPostal= @CodPostal, IdProvincia = @IdProvincia WHERE Id = @IdDireccion; 
        commit transaction;
    end try
    begin catch
        rollback transaction;
        throw;
    end catch
end;
GO

-- VISTA DE PROVINCIAS Y PAISES
CREATE OR ALTER VIEW vw_ProvinciaYPais AS
SELECT p.Id AS IdProvincia, p.Nombre AS Provincia, p.Visible, p2.Id AS IdPais, p2.Nombre AS Pais, p2.Activo FROM PROVINCIAS p 
INNER JOIN Paises p2 ON p.IdPais = p2.Id WHERE p.Activo = 1;
go

--- VISTA LISTA DIRECCIONES
CREATE OR ALTER VIEW vw_listaDireccionYCliente AS
SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, d.IdProvincia, p2.Nombre as Provincia, p2.Visible as VisibleProvincia, p2.Activo as ActivoProvincia, p2.IdPais, p3.Nombre as Pais, p3.Activo as ActivoPais, p.Id AS IdPersona, p.Nombre + ' ' + p.Apellido AS NombreApellidoCliente FROM DIRECCIONES d
INNER JOIN CLIENTES c ON c.IdDireccion = d.Id
INNER JOIN PERSONAS p ON c.IdPersona = p.Id
INNER JOIN PROVINCIAS p2 on d.IdProvincia = p2.Id
INNER JOIN PAISES p3 ON p2.IdPais = p3.Id
go

