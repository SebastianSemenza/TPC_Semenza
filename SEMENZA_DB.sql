create database TPC_SEMENZA
go
use TPC_SEMENZA
go
create table PRIORIDADES(
	ID smallint not null identity(1,1) primary key,
	Nombre varchar(50) not null
)

create table SISTEMAS(
	ID smallint not null identity(1,1) primary key,
	Nombre varchar(50) not null
)

create table COMPAÑIAS(
	ID smallint not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	CP smallint null,
	Pais varchar(50) not null,
	Provincia varchar(50) not null,
	Localidad varchar(50) not null,
)

create table USUARIOS(
	ID smallint not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Documento varchar(50) not null,
	Contraseña varchar(50) not null,
	Mail varchar(50) null,
)

create table PERFILES(
	ID smallint not null identity(1,1) primary key,
	Descripcion varchar(50) not null,
	IDSistema smallint not null foreign key references SISTEMAS(ID)
)

create table GRUPOSCOMPAÑIAS(
	ID smallint not null primary key identity(1,1),
	Descripcion  varchar(50) not null
)

create table TESTS(
	ID smallint not null identity(1,1),
	IDVersion smallint not null,
	NTicket smallint null,
	IDSistema smallint not null foreign key references SISTEMAS(ID),
	IDUsuario smallint not null foreign key references USUARIOS(ID),
	IDPrioridad smallint not null foreign key references PRIORIDADES(ID),
	IDCompañia smallint not null foreign key references COMPAÑIAS(ID),
	IDGrupoCompañias smallint not null foreign key references GRUPOSCOMPAÑIAS(ID),
	Asunto varchar(50) null,
	Descripcion varchar (1000) null,
	--primary key (ID,IDVersion)
	CONSTRAINT [PK_TESTS]PRIMARY KEY CLUSTERED
	(
		[ID]ASC,
		[IDVersion]ASC
	)
)

create table DATOSPRUEBA(
	ID smallint not null identity(1,1),
	IDTest smallint not null ,
	IDVersionTest smallint not null,
	Dato varchar (50) not null,
	Patente varchar (15) null,
	IDCompañia smallint not null foreign key references COMPAÑIAS(ID),
	IDSistema smallint not null foreign key references SISTEMAS(ID),
	foreign key (IDTest,IDVersionTest) references TESTS (ID,IDVersion)
)


create table USUARIOSPRUEBA(
	ID smallint not null identity(1,1),
	IDTest smallint not null,
	IDVersionTest smallint not null,
	Nombre varchar (50) not null,
	Apellido varchar (50) not null,
	Documento varchar (20) not null,
	Contraseña varchar (50) not null,
	IDPerfil smallint foreign key references PERFILES(ID),
	Compañia smallint foreign key references COMPAÑIAS(ID),
	Grabado bit not null,
	foreign key (IDTest,IDVersionTest)references TESTS(ID,IDVersion)
)

/*create table CASOSPRUEBA(
	ID smallint not null identity(1,1),
	IDTest smallint not null references TESTS(ID),
	Descripcion varchar(80) not null,
	Resultado bit null,
	Observaciones varchar(500) not null,
	DetalleFalla varchar(500) not null,
	IDUsuario smallint not null foreign key references USUARIOS(ID),
	IDDatoPrueba smallint not null foreign key references DATOSPRUEBA(ID),
	Automatico bit null
)*/

/*create table ADJUNTOSFALLAS(
	ID smallint not null identity(1,1),
	URL varchar(100) not null,
	IDCasoPrueba smallint not null foreign key references CASOSPRUEBA(ID)
)*/

/*create table TICKETS(
	ID smallint not null identity(1,1),
	Asunto varchar(50) not null,
	Descripcion varchar (1000)not null,
	Operario varchar(50) not null,
	ER varchar(100) null,
	Categoria varchar(50) not null,
	IDPrioridad varchar(50) not null,
	IDSistema 
	EstadoPlanilla
	PosicionPlanilla
)*/

/*create table ESTADOSTICKET(

)*/


/*create table SISTEMAS_X_COMPAÑIAS(
	IDCompañia smallint not null foreign key references COMPAÑIAS(ID),
	IDSistema smallint not null foreign key references SISTEMAS(ID),
	primary key(IDCompañia,IDSistema)
)

create table USUARIOS_X_COMPAÑIAS(
	IDCompañia smallint not null foreign key references COMPAÑIAS(ID),
	IDUsuario smallint not null foreign key references USUARIOS(ID),
	primary key(IDCompañia,IDUsuario)
)*/

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


insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('23434',2,2,2,3,2,1,'Agregar Campos en pantalla INFO','Se solocita modificar el campo INFO para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('23267',1,2,2,3,2,1,'Agregar imagenes de autos','Se solocita Agregar imagenes de autos a las compañias del exterior')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('21124',1,2,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',1,2,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',2,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',3,3,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',3,4,2,3,2,1,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',3,5,3,2,4,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',3,2,4,4,5,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')
insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)
values('25604',3,3,4,4,3,2,'Agregar Campos en pantalla General','Se solocita modificar el campo de patente para las compañias del exterior para que permita ingresar valores alfanumericos')


insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (1,2,'Jose','Sanchez','34235654','cesvi123',2,3,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (1,2,'Ramon','Olivera','27899654','cesvi345',1,2,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (1,2,'Carlos','tevez','28293244','cesvi111',1,2,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (1,2,'Ramon','Diaz','34235654','cesvi345',1,2,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (6,3,'Ramon','Diaz','32938422','cesvi345',1,2,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (6,3,'Hugo','Moyano','18983232','cesvi345',1,2,1)
insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado)
values (6,3,'Mauro','Zarate','43234354','cesvi345',1,2,1)


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









----------------------------------------------------CONSULTAS-----------------------------------------------------------

select t.ID,t.IDVersion,t.NTicket,s.Nombre,u.Nombre+' '+u.Apellido as nya,p.Nombre,c.Nombre,gc.Descripcion,t.Asunto,t.Descripcion,s.ID,u.ID,c.ID,gc.ID from TESTS t
inner join SISTEMAS s on t.IDSistema=s.ID
inner join USUARIOS u on t.IDUsuario=u.ID
inner join PRIORIDADES p on p.ID=t.IDPrioridad
inner join COMPAÑIAS c on c.ID=t.IDCompañia
inner join GRUPOSCOMPAÑIAS gc on gc.ID=t.IDGrupoCompañias
where u.Nombre+' '+u.Apellido = 'Sebastian Semenza'
where t.NTicket = 1 and t.ID=1 and s.Nombre = 'nada' and u.Nombre = 'nada' and t.Asunto = 'nada' and p.Nombre = 'nada' and t.IDVersion = 'nada'



select up.ID,up.IDTest,up.IDVersionTest,up.Nombre,up.Apellido,up.Documento,up.Contraseña,p.Descripcion,c.Nombre,up.Grabado from USUARIOSPRUEBA up 
inner join PERFILES p on p.ID=up.IDPerfil 
inner join COMPAÑIAS c on c.ID=up.Compañia


Select * from USUARIOSPRUEBA





