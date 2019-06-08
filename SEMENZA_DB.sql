create database TPC_SEMENZA
go
use TPC_SEMENZA
go
create table PRIORIDADES(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null
)

create table SISTEMAS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null
)

create table COMPAÑIAS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	CP smallint null,
	Pais varchar(50) not null,
	Provincia varchar(50) not null,
	Localidad varchar(50) not null,
)

create table USUARIOS(
	ID int not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Documento varchar(50) not null,
	Contraseña varchar(50) not null,
	Mail varchar(50) null,
)

create table PERFILES(
	ID int not null identity(1,1) primary key,
	Descripcion varchar(50) not null,
	IDSistema int not null foreign key references SISTEMAS(ID)
)

create table GRUPOSCOMPAÑIAS(
	ID int not null primary key identity(1,1),
	Descripcion  varchar(50) not null
)

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

--ULTIMAS TABLAS

create table ESTADOSTICKET(
	ID int not null primary key identity(1,1),
	Descricion varchar(30)
)

create table ESTADOSPLANILLA(
	ID int not null primary key identity(1,1),
	Descricion varchar(30)
)

create table CATEGORIAS(
	ID int not null primary key identity(1,1),
	Descricion varchar(30)
)

create table TICKETS(
	NTicket int not null identity(1,1) primary key,
	Asunto varchar(50) not null,
	Descripcion varchar (1000)not null,
	IDUsuario int not null foreign key references USUARIOS(ID),
	IDPrioridad int not null foreign key references PRIORIDADES(ID),
	IDSistema int not null foreign key references SISTEMAS(ID),
	IDEstadoPlanilla int null foreign key references ESTADOSPLANILLA(ID),
	IDEstado int not null foreign key references ESTADOSTICKET(ID),
	ER varchar(100) null,
	Categoria int not null foreign key references CATEGORIAS(ID),
	PosicionPlanilla int null
)

create table ESTADOS_X_TICKETS(
	IDEstado int not null foreign key references ESTADOSTICKET(ID),
	IDTicket int not null foreign key references TICKETS(NTicket),
	FechaEstado datetime not null
)


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


insert into PERFILES(Descripcion,IDSistema) values ('Perito',1)
insert into PERFILES(Descripcion,IDSistema) values ('Jefe de Peritos',1)
insert into PERFILES(Descripcion,IDSistema) values ('Perito',1)
insert into PERFILES(Descripcion,IDSistema) values ('Tramitador Simple',1)
insert into PERFILES(Descripcion,IDSistema) values ('Tramitador de Repuestos',1)
insert into PERFILES(Descripcion,IDSistema) values ('Jefe de Tramitadores',1)
insert into PERFILES(Descripcion,IDSistema) values ('Consultas',1)

insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('23434',2,2,2,3,2,1,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,GETDATE(),null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('23267',1,2,2,3,2,1,'Agregar imagenes de autos','Se solocita Agregar imagenes de autos a las compañias del exterior',0,0,0,1,2019-03-26,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('21124',1,2,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2018-12-15,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',1,2,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2017-03-08,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',2,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2019-04-24,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2019-07-22,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,4,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2018-06-11,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,5,3,2,4,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2019-12-21,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,2,4,4,5,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2019-11-12,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,2019-08-06,null)
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('25604',3,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos',0,1,0,1,2019-08-06,null)

insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,2,'Jose','Sanchez','34235654','cesvi123',2,3)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,2,'Ramon','Olivera','27899654','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,2,'Carlos','tevez','28293244','cesvi111',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (1,2,'Ramon','Diaz','34235654','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,3,'Ramon','Diaz','32938422','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,3,'Hugo','Moyano','18983232','cesvi345',1,2)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia)
values (6,3,'Mauro','Zarate','43234354','cesvi345',1,2)

insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,2,'23111230001','FCZ-567',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,2,'23111230002','GEP-357',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (1,2,'23111230003','PSO-865',2,3)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,3,'stroPrueba1','THM-113',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,3,'stroPrueba2','EGK-554',3,2)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,3,'stroPrueba3','SFU-654',2,3)
insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema)
values (6,3,'stroPrueba4','RRT-998',2,3)

insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (1,2,'Envio de Orden de Compra',0,'Se realizo el envio de la Orden de Compra con cristales, 
enviando a cotizar a la provincia de buenos aires','Fallo el envio, arroja mensaje de error',1,1,1)
insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico)
values (1,2,'Envio de Orden de Trabajo',0,'Se realizo el envio de la Orden de Trabajo al taller KAPPA, 
15 piezas a reparacion con daño leve','Fallo el envio, arroja mensaje de error',1,1,1)

insert into ESTADOSTICKET(Descricion) values ('Pendiente de Analisis')
insert into ESTADOSTICKET(Descricion) values ('En Analisis')
insert into ESTADOSTICKET(Descricion) values ('En Proceso')
insert into ESTADOSTICKET(Descricion) values ('En Testing')
insert into ESTADOSTICKET(Descricion) values ('Testing con Problemas')
insert into ESTADOSTICKET(Descricion) values ('Testing OK')
insert into ESTADOSTICKET(Descricion) values ('En Correccion')
insert into ESTADOSTICKET(Descricion) values ('Finalizado')
insert into ESTADOSTICKET(Descricion) values ('Detenido')
insert into ESTADOSTICKET(Descricion) values ('Inviable')
insert into ESTADOSTICKET(Descricion) values ('En Produccion')
insert into ESTADOSTICKET(Descricion) values ('Anulado por Solicitante')

insert into ESTADOSPLANILLA(Descricion) values ('En Curso')
insert into ESTADOSPLANILLA(Descricion) values ('Priorizadas')
insert into ESTADOSPLANILLA(Descricion) values ('Finalizadas')

insert into CATEGORIAS(Descricion) values ('')
insert into CATEGORIAS(Descricion) values ('Contingencia')
insert into CATEGORIAS(Descricion) values ('Modificacion')
insert into CATEGORIAS(Descricion) values ('Nuevo Desarrollo')
insert into CATEGORIAS(Descricion) values ('Trabajo Especial')

SET IDENTITY_INSERT TICKETS ON
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,IDEstado,ER,Categoria,PosicionPlanilla)
values (23434,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',2,3,2,3,1,'url',4,3)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,IDEstado,ER,Categoria,PosicionPlanilla)
values (23267,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',2,1,2,3,1,'url',3,1)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,IDEstado,ER,Categoria,PosicionPlanilla)
values (21124,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',2,1,2,3,1,'url',3,2)
insert into TICKETS(NTicket,Asunto,Descripcion,IDUsuario,IDPrioridad,IDSistema,IDEstadoPlanilla,IDEstado,ER,Categoria,PosicionPlanilla)
values (25604,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',2,3,2,3,1,'url',3,4)
SET IDENTITY_INSERT TICKETS OFF


insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (1,23434,2019-11-12)
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (2,23434,2019-11-13)
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (3,23434,2019-11-14)
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (1,25604,2019-11-13)
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (4,25604,2019-11-15)
insert into ESTADOS_X_TICKETS(IDEstado,IDTicket,FechaEstado)
values (5,25604,2019-11-19)



--_____________________________PRUEBAS_______________________________

select t.NTicket,t.Asunto,t.Descripcion,t.ER,t.PosicionPlanilla,u.Nombre+' '+u.Apellido as nombre,p.Nombre,s.Nombre,ep.Descripcion,c.Descripcion from TICKETS as t
inner join USUARIOS as u on u.ID=t.IDUsuario
inner join PRIORIDADES as p on p.ID=t.IDPrioridad
inner join SISTEMAS as s on s.ID=t.IDSistema
inner join ESTADOSPLANILLA as ep on ep.ID=t.IDEstadoPlanilla
inner join CATEGORIAS as c on c.ID=t.Categoria




select * from tests

SET IDENTITY_INSERT TESTS ON
insert into TESTS(NTicket,ID,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion)
values('23434',1,1,2,2,3,2,1,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos',0,0,0,1,GETDATE(),null)
SET IDENTITY_INSERT TESTS OFF
