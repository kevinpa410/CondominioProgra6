Create database Condominio
Go
use Condominio
Go

Create Table Usuario(
ID int IDENTITY (1,1) not null,
correo varchar(50),
contrasenna varchar(20),
nombre varchar(20),
apellido varchar(20),
IDRol int,
activo int
);
Go
Alter Table Usuario add constraint PK_Usuario primary key (ID);
Go
ALTER TABLE Usuario ADD CONSTRAINT FKUsuario_Rol FOREIGN KEY(IDRol)REFERENCES Rol(ID)
Go

--------------------------------------------------------------------------------------
Create Table Rol(
ID int IDENTITY (1,1) not null,
descripcion varchar(20)
);
Go
alter table Rol add constraint PK_Rol primary key (ID);
Go

--------------------------------------------------------------------------------------
Create Table Residencias(
ID int IDENTITY (1,1) not null,
IDUsuario int not null,
IDEstado int,
CantPersonas int,
AnnoInicio date,
CantCarros int
);

Go
alter table Residencias add constraint PK_Residencias primary key (ID);
Go
ALTER TABLE Residencias ADD CONSTRAINT FKResidencias_Usuario FOREIGN KEY(IDUsuario)REFERENCES Usuario(ID)
Go
ALTER TABLE Residencias ADD CONSTRAINT FKResidencias_EstadoResidencias FOREIGN KEY(IDEstado)REFERENCES EstadoResidencias(ID)
Go


--------------------------------------------------------------------------------------

Create Table EstadoResidencias(
ID int IDENTITY (1,1) not null,
Descripcion varchar(50),
);
Go
alter table EstadoResidencias add constraint PK_EstadoResidencias primary key (ID);
Go

--------------------------------------------------------------------------------------

Create Table Incidencias(
ID int IDENTITY (1,1) not null,
IDEstado int,
IDResidencias int,
Descripcion varchar(50),
);
Go
alter table Incidencias add constraint PK_Incidencias primary key (ID);
Go
ALTER TABLE Incidencias ADD CONSTRAINT FKIncidencias_Estado FOREIGN KEY(IDEstado)REFERENCES EstadoIncidencia(ID)
Go
ALTER TABLE Incidencias ADD CONSTRAINT FKIncidencias_Residencias FOREIGN KEY(IDResidencias)REFERENCES Residencias(ID)
Go


--------------------------------------------------------------------------------------

Create Table EstadoIncidencia(
ID int IDENTITY (1,1) not null,
Descripcion varchar(50),
);
Go
alter table EstadoIncidencia add constraint PK_EstadoIncidencia primary key (ID);
Go
--------------------------------------------------------------------------------------

Create Table Reservaciones(
ID int IDENTITY (1,1) not null,
IDUsuario int,
IDAreaComunal int,
Fecha date,
);
Go
alter table Reservaciones add constraint PK_Reservaciones primary key (ID);
Go
ALTER TABLE Reservaciones ADD CONSTRAINT FKReservaciones_Usuario FOREIGN KEY(IDUsuario)REFERENCES Usuario(ID)
Go
ALTER TABLE Reservaciones ADD CONSTRAINT FKReservaciones_AreaComunal FOREIGN KEY(IDAreaComunal)REFERENCES AreaComunal(ID)
Go

--------------------------------------------------------------------------------------

Create Table AreaComunal(
ID int IDENTITY (1,1) not null,
Descripcion varchar (100)
);
Go
alter table AreaComunal add constraint PK_AreaComunal primary key (ID);
Go

--------------------------------------------------------------------------------------

Create Table RubroCobro(
ID int IDENTITY (1,1) not null,
Monto numeric,
Descripcion varchar (100),

);
Go
alter table RubroCobro add constraint PK_RubroCobro primary key (ID);
Go
--------------------------------------------------------------------------------------

Create Table PlanesCobro(
ID int IDENTITY (1,1) not null,
Total numeric,

);
Go
alter table PlanesCobro add constraint PK_PlanesCobro primary key (ID);
Go


--------------------------------------------------------------------------------------

Create Table Estado_EstadoCuenta(
ID int IDENTITY (1,1) not null,
Descripcion varchar(50),
);
Go
alter table Estado_EstadoCuenta add constraint PK_EstadoCuenta primary key (ID);
Go
--------------------------------------------------------------------------------------

Create Table RubroPlanes(
IDRubro int not null,
IDPlanes int not null,
);
Go
alter table RubroPlanes add constraint PK_RubroPlanes primary key (IDRubro,IDPlanes);
Go
ALTER TABLE RubroPlanes ADD CONSTRAINT FKRubroPlanes_Rubro FOREIGN KEY(IDRubro)REFERENCES RubroCobro(ID)
Go
ALTER TABLE RubroPlanes ADD CONSTRAINT FKRubroPlanes_Planes FOREIGN KEY(IDPlanes)REFERENCES PlanesCobro(ID)
Go

--------------------------------------------------------------------------------------

Create Table Informacion(
ID int IDENTITY (1,1) not null,
Descripcion varchar(100),
Imagen varbinary (max),

);

alter table Informacion add constraint PK_Informacion primary key (ID);
Go

--------------------------------------------------------------------------------------

Create Table EstadoCuenta(
ID int IDENTITY (1,1) not null,
IDPlanCobro int,
IDUsuario int,
IDResidencia int,
IDEstado int,
Mes date
);

alter table EstadoCuenta add constraint PK_EstadoCuenta primary key (ID);
Go
ALTER TABLE EstadoCuenta ADD CONSTRAINT FKEstadoCuenta_PlanesCobro FOREIGN KEY(IDPlanCobro)REFERENCES PlanesCobro(ID)
Go
ALTER TABLE EstadoCuenta ADD CONSTRAINT FKEstadoCuenta_Usuario FOREIGN KEY(IDUsuario)REFERENCES Usuario(ID)
Go
ALTER TABLE EstadoCuenta ADD CONSTRAINT FKEstadoCuenta_Residencia FOREIGN KEY(IDResidencia)REFERENCES Residencias(ID)
Go
ALTER TABLE EstadoCuenta ADD CONSTRAINT FKEstadoCuenta_Estado_EstadoCuenta FOREIGN KEY(IDEstado)REFERENCES Estado_EstadoCuenta(ID)
Go

--------------------------------------------------------------------------------------





