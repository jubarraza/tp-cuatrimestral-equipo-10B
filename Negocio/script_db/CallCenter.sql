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
