drop database CALLCENTER
go
create database CALLCENTER
go
use CALLCENTER
go

-- INCIDENCIAS
create table INCIDENCIAS(
codigo int identity(1000,1) not null,
Cliente int not null,
Usuario int not null,
Descripcion varchar(200) not null,
Estado int not null,
Prioridad int not null,
Tipo int not null,
FechaAlta smalldatetime,
FechaCierre smalldatetime,
Resolucion Varchar(200)) 
go
set dateformat dmy
go
insert into INCIDENCIAS (Cliente, Usuario, Descripcion , Estado, Prioridad,Tipo, FechaAlta, FechaCierre, Resolucion) 
values (2,2,'No se acredito el pago',1,3,1,'17-03-2023',null,null);
insert into INCIDENCIAS (Cliente, Usuario, Descripcion , Estado, Prioridad,Tipo, FechaAlta, FechaCierre, Resolucion) 
values (3,2,'Solicito baja de servicio',4,3,1,'17-03-2023','23-09-2024','Se ha realizado la baja correspondiente');
insert into INCIDENCIAS (Cliente, Usuario, Descripcion , Estado, Prioridad,Tipo, FechaAlta, FechaCierre, Resolucion) 
values (1,1,'Lisa necesita frenos',3,2,1,'22-03-2023',null,null);
go

-- COMENTARIOS
create table COMENTARIOS(
id int not null identity(1,1),
Cod_Incidencia int not null,
Comentario varchar(200) not null,
Fecha smalldatetime not null,
IdUsuario int not null
)
go
set dateformat dmy
go
insert into COMENTARIOS
values (1001, 'Se verifica que no tiene deuda y se procede la baja', '13/12/2023', 2)
insert into Comentarios
values (1000, 'Se solicta comprobante de pago correspondiente', '23/03/2023', 2)
insert into Comentarios
values (1002, 'Plan dentaaaaal', '22/06/2024', 1)
insert into Comentarios
values (1002, 'Lisa necesita frenos', '23/06/2024', 1)
insert into Comentarios
values (1002, 'Plan dentaaaaal', GETDATE(), 1)
go

-- TIPO INCIDENCIA
CREATE TABLE TIPO_INCIDENCIA(
Id int identity(1,1) not null primary key,
Nombre varchar(70) not null unique,
Activo bit not null)
go
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Producto Defectuoso o Da�ado', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Demoras en la Entrega', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Cambio o Devoluci�n', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Garant�as y Reparaciones', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Errores en el Pedido', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Problemas con Facturaci�n', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Atenci�n en Tienda F�sica', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Problemas en el Sitio Web/App', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Problemas con el Env�o', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Consulta o Reclamo por Promociones', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Soporte T�cnico para Electrodom�sticos/Electr�nica', 1);
INSERT INTO TIPO_INCIDENCIA (Nombre, Activo) VALUES ('Cobertura de Garant�a Extendida', 1);
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
Email varchar(80) not null unique)
go
insert into PERSONAS
values ('Bart','Simpson','bartsimpson@gmail.com');
insert into PERSONAS
values('Homero','Thompson','homerothompson@hotmail.com');
insert into PERSONAS
values('Jony','Bocacerrada','jonybocacerrada@yahoo.com.ar');
go

-- EMPLEADOS
create table EMPLEADOS(
Legajo bigint identity(100001,1) not null primary key,
IdPersona bigint not null,
UserPassword varchar(20) not null,
TipoUsuario tinyint not null,
FechaIngreso date not null check(FechaIngreso <= getdate()),
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id)
)
GO
set dateformat dmy
insert into EMPLEADOS(IdPersona,UserPassword,TipoUsuario,FechaIngreso,Activo)
values(1,'Milhouse',3,'26-10-2024',1),
(2,'Springfield',2,'26-10-2023',0),
(3,'Nodirenada',1,'10-10-2020',1);

-- CLIENTES
create table CLIENTES(
IdPersona bigint not null unique,
Dni bigint not null unique,
UserPassword varchar(20) not null,
FechaNacimiento date not null check(FechaNacimiento <= dateadd(year,-18, getdate())),
Direccion varchar(50) not null,
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id)
)
go
insert into PERSONAS
values ('Ned','Flanders','Nedflanders@gmail.com');
insert into PERSONAS
values ('Abraham','Simpsons','Abrahamsimpson@yahoo.com.ar');
insert into PERSONAS
values('Milhouse','Vanhouten','Milhouse2024@hotmail.com.ar');

set dateformat dmy
insert into CLIENTES
(IdPersona, Dni, UserPassword, FechaNacimiento, Direccion, Activo) values 
(4,12345678,'Perfectirijillo','27-10-1964','Avenida siempre viva 741',1),
(5,87654321,'Abuelo','27-10-1927','Casa de Jubilados Springfield',0),
(6,12312312,'Bart','27-10-2000','Con sus padres',1);


-- TELEFONOS
create table TELEFONOS(
IdTelefono int identity(1,1) primary key,
IdPersona bigint not null,
NumeroTelefono bigint not null,
foreign key (IdPersona) references CLIENTES(IdPersona)
)
go
insert into TELEFONOS
(IdPersona, NumeroTelefono)
VALUES
(4,10101010),
(4,20202020),
(5,30303030);
go

--Creacion de Store Procedure AgregarPersonaEmpleado
create procedure sp_AgregarPersonaEmpleado
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

-- PAIS
CREATE TABLE PAISES(
Id bigint identity(1,1) not null primary key,
Nombre varchar(50) not null unique,
Activo bit not null
)
GO
INSERT INTO PAISES (Nombre, Activo) VALUES ('Argentina', 1);
INSERT INTO PAISES (Nombre, Activo) VALUES ('Uruguay', 1);
GO

-- PROVINCIAS
CREATE TABLE PROVINCIAS(
Id bigint identity(1,1) not null primary key,
Nombre varchar(50) not null unique,
IdPais bigint not null,
Activo bit not null,
FOREIGN KEY (IdPais) REFERENCES PAISES (Id)
)
go
INSERT INTO PROVINCIAS (Nombre, IdPais, Activo) VALUES ('Buenos Aires', 1, 1);
INSERT INTO PROVINCIAS (Nombre, IdPais, Activo) VALUES ('Cordoba', 1, 1);
INSERT INTO PROVINCIAS (Nombre, IdPais, Activo) VALUES ('Santa Fe', 1, 1);
INSERT INTO PROVINCIAS (Nombre, IdPais, Activo) VALUES ('Mendoza', 1, 1);
go

-- DIRECCIONES
CREATE TABLE DIRECCIONES(
Id bigint identity(1,1) not null primary key,
Calle varchar(70) not null,
Numero bigint not null,
Localidad varchar(70) not null,
CodPostal varchar(20) not null,
IdProvincia bigint not null FOREIGN KEY REFERENCES PROVINCIAS (Id),
DniCliente bigint not null FOREIGN KEY REFERENCES CLIENTES (Dni),
Activo bit not null)
go
INSERT INTO DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia, DniCliente, Activo) VALUES ('Calle', 1234, 'Rosario', 'B1646' , 3, 12345678, 1);
go