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
insert into PERSONAS
values ('Bart','Simpson','bartsimpson@gmail.com');
insert into PERSONAS
values('Homero','Thompson','homerothompson@hotmail.com');
insert into PERSONAS
values('Jony','Bocacerrada','jonybocacerrada@yahoo.com.ar');
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
insert into EMPLEADOS(IdPersona,UserPassword,TipoUsuario,FechaIngreso,Activo)
values(1,'Milhouse',3,'26-10-2024',1),
(2,'Springfield',2,'26-10-2023',0),
(3,'Nodirenada',1,'10-10-2020',1);

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
INSERT INTO DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia) VALUES ('Calle', 1234, 'Rosario', 'B1646' , 20);
INSERT INTO DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia) VALUES ('Callecita', 4321, 'Viñedo', 'C1818' , 12);
INSERT INTO DIRECCIONES (Calle, Numero, Localidad, CodPostal, IdProvincia) VALUES ('Callezota', 41, 'Retiro', 'C2218' , 1);
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
insert into PERSONAS
values ('Ned','Flanders','Nedflanders@gmail.com');
insert into PERSONAS
values ('Abraham','Simpsons','Abrahamsimpson@yahoo.com.ar');
insert into PERSONAS
values('Milhouse','Vanhouten','Milhouse2024@hotmail.com.ar');

set dateformat dmy
insert into CLIENTES
(IdPersona, Dni, FechaNacimiento, IdDireccion, Activo) values 
(4,12345678,'27-10-1964',1,1),
(5,87654321,'27-10-1927',2,0),
(6,12312312,'27-10-2000',3,1);
go

-- TELEFONOS
create table TELEFONOS(
IdTelefono int identity(1,1) primary key,
IdPersona bigint not null,
NumeroTelefono bigint not null,
foreign key (IdPersona) references CLIENTES(IdPersona)
)
go
insert into TELEFONOS (IdPersona, NumeroTelefono) VALUES
(4,10101010),
(4,20202020),
(5,30303030);
go

-- INCIDENCIAS
create table INCIDENCIAS(
Codigo int identity(1000,1) not null primary key,
DniCliente bigint not null,
Usuario int not null,
Descripcion varchar(1000) not null,
Estado int not null,
Prioridad int not null,
IdTipoIncidencia int not null,
FechaAlta smalldatetime,
FechaCierre smalldatetime,
Resolucion Varchar(200)
FOREIGN KEY (DniCliente) REFERENCES Clientes(Dni)) 
go
set dateformat dmy
go
insert into INCIDENCIAS (DniCliente, Usuario, Descripcion , Estado, Prioridad, IdTipoIncidencia, FechaAlta, FechaCierre, Resolucion) 
values (12345678,2,'No se acredito el pago',1,3,1,'17-03-2023',null,null);
insert into INCIDENCIAS (DniCliente, Usuario, Descripcion , Estado, Prioridad, IdTipoIncidencia, FechaAlta, FechaCierre, Resolucion) 
values (87654321,2,'Solicito baja de servicio',4,3,2,'17-03-2023','23-09-2024','Se ha realizado la baja correspondiente');
insert into INCIDENCIAS (DniCliente, Usuario, Descripcion , Estado, Prioridad, IdTipoIncidencia, FechaAlta, FechaCierre, Resolucion) 
values (12312312,1,'Lisa necesita frenos',3,2,1,'22-03-2023',null,null);
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
@Activo bit
as
begin
    begin transaction;
    begin try
        update dbo.PERSONAS
        set Nombre = @Nombre, Apellido = @Apellido, Email = @Email
        where Id = (select IdPersona from dbo.EMPLEADOS where Legajo = @Legajo);
        update dbo.EMPLEADOS
        set UserPassword = @UserPassword, TipoUsuario = @TipoUsuario, FechaIngreso = @FechaIngreso, 
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

