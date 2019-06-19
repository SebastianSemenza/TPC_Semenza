create database TPC_SEMENZA
go
use TPC_SEMENZA
go
create table PRIORIDADES(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null
)
go
create table SISTEMAS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null
)
go
create table COMPAÑIAS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	CP smallint null,
	Pais varchar(50) not null,
	Provincia varchar(50) not null,
	Localidad varchar(50) not null,
)
go
create table USUARIOS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Documento varchar(50) not null,
	Contraseña varchar(50) not null,
	Mail varchar(50) null,
)
go
create table PERFILES(
	ID int not null identity(1,1) primary key,
	Descripcion varchar(50) not null,
	IDSistema int not null foreign key references SISTEMAS(ID)
)
go
create table GRUPOSCOMPAÑIAS(
	ID int not null primary key identity(1,1),
	Descripcion  varchar(50) not null
)
go
create table TESTS(
	ID int not null identity(1,1),
	IDVersion int not null,
	NTicket int null,
	IDSistema int not null foreign key references SISTEMAS(ID),
	IDUsuario int not null foreign key references USUARIOS(ID),
	IDPrioridad int not null foreign key references PRIORIDADES(ID),
	IDCompañia int not null foreign key references COMPAÑIAS(ID),
	IDGrupoCompañias int not null foreign key references GRUPOSCOMPAÑIAS(ID),
	Asunto varchar(50) null,
	Descripcion varchar (1000) null,
	Borrado bit not null,
	Finalizado bit not null,
	VersionFinal bit not null,
	Ultimo bit not null,
	FechaCarga datetime not null,
	fechaFinalizacion datetime null,
	primary key (ID,IDVersion)
)
go
create table DATOSPRUEBA(
	ID int not null identity(1,1) primary key,
	IDTest int not null ,
	IDVersionTest int not null,
	Dato varchar (50) not null,
	Patente varchar (15) null,
	IDCompañia int not null foreign key references COMPAÑIAS(ID),
	IDSistema int not null foreign key references SISTEMAS(ID),
	foreign key (IDTest,IDVersionTest) references TESTS (ID,IDVersion)
)
go
create table USUARIOSPRUEBA(
	ID int not null identity(1,1) primary key,
	IDTest int not null,
	IDVersionTest int not null,
	Nombre varchar (50) not null,
	Apellido varchar (50) not null,
	Documento varchar (20) not null,
	Contraseña varchar (50) not null,
	IDPerfil int foreign key references PERFILES(ID),
	Compañia int foreign key references COMPAÑIAS(ID),
	foreign key (IDTest,IDVersionTest)references TESTS(ID,IDVersion)
)
go
create table CASOSPRUEBA(
	ID int not null identity(1,1),
	IDVersionTest int not null,
	IDTest int not null,
	Descripcion varchar(80) not null,
	Resultado bit null,
	Observaciones varchar(500) not null,
	DetalleFalla varchar(500) null,
	IDUsuario int not null foreign key references USUARIOSPRUEBA(ID),
	IDDatoPrueba int not null foreign key references DATOSPRUEBA(ID),
	foreign key (IDTest,IDVersionTest)references TESTS(ID,IDVersion),
	Automatico bit null
)
go
create table ESTADOSTICKET(
	ID int not null primary key identity(1,1),
	Descripcion varchar(30)
)
select * from ESTADOSTICKET
go
create table ESTADOSPLANILLA(
	ID int not null primary key identity(1,1),
	Descripcion varchar(30)
)
go
create table CATEGORIAS(
	ID int not null primary key identity(1,1),
	Descripcion varchar(30)
)
go
create table TICKETS(
	NTicket int not null identity(1,1) primary key,
	Asunto varchar(50) not null,
	Descripcion varchar (1000)not null,
	IDUsuario int not null foreign key references USUARIOS(ID),
	IDPrioridad int not null foreign key references PRIORIDADES(ID),
	IDSistema int not null foreign key references SISTEMAS(ID),
	IDEstadoPlanilla int null foreign key references ESTADOSPLANILLA(ID),
	FechaCarga datetime not null,
	ER varchar(100) null,
	Categoria int not null foreign key references CATEGORIAS(ID),
	PosicionPlanilla int null
)
go
create table ESTADOS_X_TICKETS(
	IDEstado int not null foreign key references ESTADOSTICKET(ID),
	IDTicket int not null foreign key references TICKETS(NTicket),
	FechaEstado datetime not null
	--ver si generar primary
)
go
-------------------------------SP PARA CONTAR LOS ERRORES----------------------------------------------
create procedure sp_contar_errores(
	@NTicket int
)
as
begin
select
(select COUNT(*) from CASOSPRUEBA as cp
inner join TESTS as t on t.ID=cp.IDTest and t.IDVersion=cp.IDVersionTest
where NTicket=@NTicket and Resultado=1)+
(select COUNT(*) from CASOSPRUEBA as cp
inner join TESTS as t on t.ID=cp.IDTest and t.IDVersion=cp.IDVersionTest
where NTicket=@NTicket and Resultado=0 and Ultimo=1)
end
--------------------------------------------------------------------------------------------------
go
--------------------------------------------DATOS---------------------------------------------------------


insert into PRIORIDADES (Nombre) values('Todas')
insert into PRIORIDADES (Nombre) values('Alta')
insert into PRIORIDADES (Nombre) values('Media')
insert into PRIORIDADES (Nombre) values('Baja')


insert into SISTEMAS (Nombre) values('Todos')
insert into SISTEMAS (Nombre) values('Orión Cesvicom')
insert into SISTEMAS (Nombre) values('Orión Previas')
insert into SISTEMAS (Nombre) values('Orión Repuestos')
insert into SISTEMAS (Nombre) values('Orión Talleres')
insert into SISTEMAS (Nombre) values('Orión Tramitador')
insert into SISTEMAS (Nombre) values('Orión Desktop')
insert into SISTEMAS (Nombre) values('Orión Restos')
insert into SISTEMAS (Nombre) values('ITDT')
insert into SISTEMAS (Nombre) values('Sofia')
insert into SISTEMAS (Nombre) values('Cleas')
insert into SISTEMAS (Nombre) values('Cesvimed')
insert into SISTEMAS (Nombre) values('Siara')


insert into USUARIOS (Nombre,Apellido,Documento,Contraseña,Mail) 
values ('Todos','',00000000,'','')
insert into USUARIOS (Nombre,Apellido,Documento,Contraseña,Mail) 
values ('Sebastian','Semenza',37552665,'cesvi123','sebastiansemenza@gmail.com')
insert into USUARIOS (Nombre,Apellido,Documento,Contraseña,Mail) 
values ('Diego','Garcia',11223344,'cesvi123','diego@gmail.com')
insert into USUARIOS (Nombre,Apellido,Documento,Contraseña,Mail) 
values ('Luciano','Iuso',11111111,'cesvi123','luciano@gmail.com')


insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('',1,'','','')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('CESVI Argentina',1629,'Argentina','Buenos Aires','Pilar')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('Mapfre Argentina',2435,'Argentina','Buenos Aires','San Isidro')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('Mapfre Paraguay',655,'Paraguay','Asuncion','Ciudad del este')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('Mapfre Chile',766,'Chile','Araucania','Santiago')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('Mapfre Uruguay',567,'Uruguay','Montevideo','Uraguey')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('SURA Argentina',678,'Argentina','Buenos Aires','Puerto Madero')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('La Segunda Argentina',8897,'Argentina','Rosario','Rosario')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('San Cristobal Argentina',1789,'Argentina','Buenos Aires','La Plata')
insert into COMPAÑIAS(Nombre,CP,Pais,Provincia,Localidad) values('ZURICH Argentina',129,'Argentina','Buenos Aires','CABA')

insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Todos')
insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Solo Cia Solicitante')
insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Grupo CESVI')
insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Grupo CESVI + Latam')
insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Latinoamerica')
insert into GRUPOSCOMPAÑIAS (Descripcion) values ('Cias. Socias')

insert into PERFILES(Descripcion,IDSistema) values ('',1)
insert into PERFILES(Descripcion,IDSistema) values ('Perito',1)
insert into PERFILES(Descripcion,IDSistema) values ('Jefe de Peritos',1)
insert into PERFILES(Descripcion,IDSistema) values ('Perito',1)
insert into PERFILES(Descripcion,IDSistema) values ('Tramitador Simple',1)
insert into PERFILES(Descripcion,IDSistema) values ('Tramitador de Repuestos',1)
insert into PERFILES(Descripcion,IDSistema) values ('Jefe de Tramitadores',1)
insert into PERFILES(Descripcion,IDSistema) values ('Consultas',1)
select * from tests

insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('23434',1,2,2,3,2,1,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2019-02-23 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('23267',1,2,2,3,2,1,'Agregar imagenes de autos','Se solocita Agregar imagenes de autos a las compañias del exterior',0,0,0,1,convert(datetime, '2016-10-23 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',1,2,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2018-10-23 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('28990',1,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2017-04-12 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('90293',1,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2018-11-30 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('77777',1,4,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2018-07-21 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('99222',1,5,3,2,4,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,convert(datetime, '2018-09-09 20:44:11.500', 121),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('29999',1,2,4,4,5,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',1,0,0,1,convert(datetime, '2018-02-21 20:44:11.500', 121),null)
SET IDENTITY_INSERT TESTS ON
insert into TESTS(ID,NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values(12,'25605',1,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,1,0,0,convert(datetime, '2019-01-23 20:44:11.500', 121),null)
insert into TESTS(ID,NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values(12,'25605',2,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,1,0,0,convert(datetime, '2019-02-23 20:44:11.500', 121),null)
insert into TESTS(ID,NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values(12,'25605',3,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,1,1,1,convert(datetime, '2019-03-23 20:44:11.500', 121),null)
SET IDENTITY_INSERT TESTS OFF



insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,1,'Jose','Sanchez','34235654','cesvi123',2,3)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,1,'Ramon','Olivera','27899654','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,1,'Carlos','tevez','28293244','cesvi111',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,1,'Ramon','Diaz','34235654','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,1,'Ramon','Diaz','32938422','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,1,'Hugo','Moyano','18983232','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,1,'Mauro','Zarate','43234354','cesvi345',1,2)

insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,1,'23111230001','FCZ-567',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,1,'23111230002','GEP-357',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,1,'23111230003','PSO-865',2,3)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,1,'stroPrueba1','THM-113',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,1,'stroPrueba2','EGK-554',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,1,'stroPrueba3','SFU-654',2,3)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,1,'stroPrueba4','RRT-998',2,3)

insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (1,1,'Envio de Orden de Compra',0,'Se realizo el envio de la Orden de Compra con cristales, 
enviando a cotizar a la provincia de buenos aires','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (1,1,'Envio de Orden de Trabajo',0,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,1,'Envio de Orden de Trabajo',0,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,1,'Envio de Orden de Trabajo',0,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,1,'Envio de Orden de Trabajo',1,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,2,'Envio de Orden de Trabajo',1,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,2,'Envio de Orden de Trabajo',0,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (12,3,'Envio de Orden de Trabajo',1,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)


insert into ESTADOSTICKET(Descripcion) values ('Pendiente de Analisis')
insert into ESTADOSTICKET(Descripcion) values ('En Analisis')
insert into ESTADOSTICKET(Descripcion) values ('En Proceso')
insert into ESTADOSTICKET(Descripcion) values ('En Testing')
insert into ESTADOSTICKET(Descripcion) values ('Testing con Problemas')
insert into ESTADOSTICKET(Descripcion) values ('Testing OK')
insert into ESTADOSTICKET(Descripcion) values ('En Correccion')
insert into ESTADOSTICKET(Descripcion) values ('Finalizado')
insert into ESTADOSTICKET(Descripcion) values ('Detenido')
insert into ESTADOSTICKET(Descripcion) values ('Inviable')
insert into ESTADOSTICKET(Descripcion) values ('En Produccion')
insert into ESTADOSTICKET(Descripcion) values ('Anulado por Solicitante')

insert into ESTADOSPLANILLA(Descripcion) values ('En Curso')
insert into ESTADOSPLANILLA(Descripcion) values ('Priorizadas')
insert into ESTADOSPLANILLA(Descripcion) values ('Finalizadas')

insert into CATEGORIAS(Descripcion) values ('')
insert into CATEGORIAS(Descripcion) values ('Contingencia')
insert into CATEGORIAS(Descripcion) values ('Modificacion')
insert into CATEGORIAS(Descripcion) values ('Nuevo Desarrollo')
insert into CATEGORIAS(Descripcion) values ('Trabajo Especial')

SET IDENTITY_INSERT TICKETS ON
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (23434,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar 
valores alfanumericos',2,3,2,2,convert(datetime, '2016-10-23 20:44:11.500', 121),'url',3,1)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (23267,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar 
valores alfanumericos',2,1,2,2,convert(datetime, '2016-10-23 20:44:11.500', 121),'url',3,2)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (21124,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar 
valores alfanumericos',2,1,2,2,convert(datetime, '2016-10-23 20:44:11.500', 121),'url',3,3)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (25604,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar 
valores alfanumericos',2,3,2,2,convert(datetime, '2016-10-23 20:44:11.500', 121),'url',3,4)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (55660,'nuevo ticket 1','nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo 
nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo
 nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvonuevo nuevo nuenvonuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo 
 nuevo nuenvo dificar el campo INFO para las compañias del exterior para 
que permita ingresar valores alfanumericos',2,1,2,2,convert(datetime, '2018-10-23 20:44:11.500', 121),'url',3,6)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (77889,'nuevo ticket 1','nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo Se solocita 
modificar el campo INFO para las compañias del exterior para que permita ingresar valores
 alfanumericos',2,3,2,2,convert(datetime, '2018-05-23 20:44:11.500', 121),'url',3,5)
 insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,FechaCarga,ER,Categoria,PosicionPlanilla)
values (54342,'nuevo ticket 1','nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo nuevo nuevo nuenvo Se solocita 
modificar el campo INFO para las compañias del exterior para que permita ingresar valores
 alfanumericos',2,3,2,3,convert(datetime, '2018-05-23 20:44:11.500', 121),'url',3,null)
SET IDENTITY_INSERT TICKETS OFF


insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (1,23434,convert(datetime, '2016-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (2,23434,convert(datetime, '2016-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,23434,convert(datetime, '2017-11-13 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (1,25604,convert(datetime, '2016-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (4,25604,convert(datetime, '2017-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (5,25604,convert(datetime, '2016-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (5,23267,convert(datetime, '2016-10-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,21124,convert(datetime, '2018-06-19 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,25604,convert(datetime, '2017-01-20 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,23267,convert(datetime, '2016-11-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,55660,convert(datetime, '2018-12-03 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (4,55660,convert(datetime, '2018-12-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (6,55660,convert(datetime, '2019-01-13 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (11,55660,convert(datetime, '2019-03-11 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,77889,convert(datetime, '2018-11-01 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (4,77889,convert(datetime, '2019-02-09 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (6,77889,convert(datetime, '2019-02-23 20:44:11.500', 121))
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (11,77889,convert(datetime, '2019-04-11 20:44:11.500', 121))

--_____________________________PRUEBAS_______________________________

/*

------------------------------Select para PLANILLA DE PRIORIDADES-------------------------------------------
select (select top 1 IDVersion from TESTS where NTicket=t.NTicket order by IDVersion desc), ep.Descripcion as Estado,t.PosicionPlanilla,p.Nombre as Prioridad,t.NTicket,t.Asunto,t.Descripcion,t.FechaCarga,
cat.Descripcion as Categoria,s.Nombre as Sistema,u.Nombre+' '+u.Apellido as Nombre,
ts.FechaCarga as InicioTest,ts.fechaFinalizacion as FinTest,com.Nombre as Compañia,gc.Descripcion as GrupoAplica 
from TICKETS as t
inner join USUARIOS as u on u.ID=t.IDUsuario
inner join PRIORIDADES as p on p.ID=t.IDPrioridad
inner join SISTEMAS as s on s.ID=t.IDSistema
inner join ESTADOSPLANILLA as ep on ep.ID=t.IDEstadoPlanilla
inner join CATEGORIAS as cat on cat.ID=t.IDPrioridad
left join TESTS as ts on ts.NTicket=t.NTicket
--left join ( select TOP 1 IDVersion, NTicket, FechaCarga, fechaFinalizacion, IDCompañia, IDGrupoCompañias from TESTS group by NTicket, FechaCarga, fechaFinalizacion, IDCompañia, IDGrupoCompañias ) as ts ON ts.NTicket =  t.NTicket
--left join ( select top 1 IDVersion from TESTS where NTicket=t.NTicket order by IDVersion desc ) as ts ON ts.NTicket =  t.NTicket
left join COMPAÑIAS as com on com.ID=ts.IDCompañia
left join GRUPOSCOMPAÑIAS as gc on gc.ID=ts.IDGrupoCompañias
order by PosicionPlanilla asc

------------------------------PROVISORIA PLANILLA DE PRIORIDADES-------------------------------------------
select ep.Descripcion as Estado,t.PosicionPlanilla,p.Nombre as Prioridad,t.NTicket,t.Asunto,t.Descripcion,t.FechaCarga,
cat.Descripcion as Categoria,s.Nombre as Sistema,u.Nombre,u.Apellido from TICKETS as t
inner join USUARIOS as u on u.ID=t.IDUsuario
inner join PRIORIDADES as p on p.ID=t.IDPrioridad
inner join SISTEMAS as s on s.ID=t.IDSistema
inner join ESTADOSPLANILLA as ep on ep.ID=t.IDEstadoPlanilla
inner join CATEGORIAS as cat on cat.ID=t.IDPrioridad
order by PosicionPlanilla asc
------------------------------------------------------------------------------------------------------------

*/