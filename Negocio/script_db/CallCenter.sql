create database CALLCENTER
go
use CALLCENTER
go
create table INCIDENCIAS(
codigo int identity(1000,1) not null,
Tipo int not null,
Descripcion varchar(200),
Estado int not null,
FechaAlta smalldatetime,
FechaBaja smalldatetime,
Resolucion Varchar(200)) 
go
set dateformat dmy
go
insert into Incidencias
values (1, 'No se acredito el pago', 1, '17-09-2024', null, null);
insert into Incidencias
values (2, 'Solicito baja de servicio', 3, '17-09-2024', '23-09-2024', 'Se ha realizado la baja correspondiente')
insert into Incidencias
values (4, 'Lisa necesita frenos', 1, '22-03-2023', null, null)


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

insert into PERSONAS
values ('Bart','Simpson','bartsimpson@gmail.com');
insert into PERSONAS
values('Homero','Thompson','homerothompson@hotmail.com');
insert into PERSONAS
values('Jony','Bocacerrada','jonybocacerrada@yahoo.com.ar');

-- Esto un cambio que va a traer conflicto...