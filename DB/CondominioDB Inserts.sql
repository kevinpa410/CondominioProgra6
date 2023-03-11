--------------------------------------------------------------------------------------
--INSERTS
--------------------------------------------------------------------------------------

insert into Rol values('Administrador');
insert into Rol values('Residente');

insert into Usuario values('kevinpaniagua@gmail.com','123456','Kevin','Paniagua',1,1);
insert into Usuario values('johndoe@gmail.com','123456','John','Doe',2,1);
insert into Usuario values('janedoe@gmail.com','123456','Jane','Doe',2,1);
insert into Usuario values('johnnydoe@gmail.com','123456','Johnny','Doe',2,1);

insert into EstadoResidencias values('En Construcción');--ID 1
insert into EstadoResidencias values('Habitada');--ID 2

insert into Estado_EstadoCuenta values('Pendiente'); --ID 1
insert into Estado_EstadoCuenta values('Pagado');--ID 2

insert into RubroCobro values(10000,'Agua');
insert into RubroCobro values(15000,'Luz');
insert into RubroCobro values(5000,'Basura');

insert into PlanesCobro values(1); --Pendiente
insert into PlanesCobro values(2); --Pagado
insert into PlanesCobro values(1); --Pendiente
insert into PlanesCobro values(2); --Pagado

insert into RubroPlanes values(1,1);
insert into RubroPlanes values(2,1);
insert into RubroPlanes values(3,1);

insert into RubroPlanes values(1,2);
insert into RubroPlanes values(2,2);
insert into RubroPlanes values(3,2);

insert into RubroPlanes values(1,3);
insert into RubroPlanes values(2,3);
insert into RubroPlanes values(3,3);

insert into Residencias values(1,1,3,'1-1-2020',1);
insert into Residencias values(2,2,5,'4-16-2021',2);
insert into Residencias values(3,1,4,'7-20-2019',1);

insert into EstadoCuenta values(1,1,1,1,'2-1-2023');
insert into EstadoCuenta values(2,2,2,1,'2-1-2023');
insert into EstadoCuenta values(3,3,3,2,'2-1-2023');

delete from RubroPlanes where IDRubro = 3
select * from EstadoResidencias




