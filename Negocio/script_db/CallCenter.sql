create database CALLCENTER
go
use CALLCENTER
go
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
--PRIORIDADES--
create table PRIORIDADES(
Id int identity(1,1) not null primary key,
Nombre varchar(30) not null unique,
Activa bit not null)
go
insert into PRIORIDADES (Nombre, Activa)
values ('Urgente',1);
insert into PRIORIDADES (Nombre, Activa)
values ('Alta',1);
insert into PRIORIDADES (Nombre, Activa)
values ('Media',1);
insert into PRIORIDADES (Nombre, Activa)
values ('Baja',1);
go
--ESTADOS--
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
--PERSONAS
create table PERSONAS(
Id int identity(1,1) not null primary key,
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
create table Comentarios(
id int not null identity(1,1),
Cod_Incidencia int not null,
Comentario varchar(200) not null,
Fecha smalldatetime not null,
IdUsuario int not null
)
go
set dateformat dmy
go
insert into Comentarios
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
--EMPLEADOS
create table EMPLEADOS(
Legajo int identity(100001,1) not null primary key,
IdPersona int not null,
Contraseņa varchar(20) not null,
TipoUsuario tinyint not null,
FechaIngreso date not null check(FechaIngreso <= getdate()),
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id)
)

set dateformat dmy
insert into EMPLEADOS(IdPersona,Contraseņa,TipoUsuario,FechaIngreso,Activo)
values(1,'Milhouse',3,'26-10-2024',1),
(2,'Springfield',2,'26-10-2023',0),
(3,'Nodirenada',1,'10-10-2020',1);

--CLIENTES
create table CLIENTES(
IdPersona int not null,
Dni int not null,
Contraseņa varchar(20) not null,
FechaNacimiento date not null check(FechaNacimiento <= dateadd(year,-18, getdate())),
Telefono bigint,
Direccion varchar(50) not null,
Activo bit not null,
foreign key (IdPersona) references PERSONAS(Id)
)

insert into PERSONAS
values ('Ned','Flanders','Nedflanders@gmail.com');
insert into PERSONAS
values ('Abraham','Simpsons','Abrahamsimpson@yahoo.com.ar');
insert into PERSONAS
values('Milhouse','Vanhouten','Milhouse2024@hotmail.com.ar');

set dateformat dmy
insert into CLIENTES
(IdPersona, Dni, Contraseņa, FechaNacimiento, Telefono, Direccion, Activo) values 
(4,12345678,'Perfectirijillo','27-10-1964',2604123412,'Avenida siempre viva 741',1),
(5,87654321,'Abuelo','27-10-1927',0800123412,'Casa de Jubilados Springfield',0),
(6,12312312,'Bart','27-10-2000',1127272727,'Con sus padres',1);

--Eliminacion Columna Telefono de Clase Clientes
alter table CLIENTES
drop column Telefono

--Se Agrega Restriccion Unique a IdPersona
alter table CLIENTES
add constraint uq_IdPersona unique (IdPersona)

--Telefonos
create table TELEFONOS(
IdTelefono int identity(1,1) primary key,
IdPersona int not null,
NumeroTelefono bigint not null,
foreign key (IdPersona) references CLIENTES(IdPersona)
)

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
@Contraseņa varchar(20),
@TipoUsuario tinyint,
@FechaIngreso date,
@Activo bit
as begin
begin transaction;
begin try
	declare @IdPersona int;
	insert into PERSONAS(Nombre,Apellido,Email)
	values(@Nombre,@Apellido,@Email);
	set @IdPersona = SCOPE_IDENTITY();
	insert into EMPLEADOS(IdPersona,Contraseņa,TipoUsuario,FechaIngreso,Activo)
	values(@IdPersona,@Contraseņa,@TipoUsuario,@FechaIngreso,@Activo);
	commit transaction
end try
begin catch
rollback transaction;
throw;
end catch
end;