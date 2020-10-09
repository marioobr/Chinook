Create database Chinook;
go
Use Chinook;

create table Artista(
ArtistaId int identity(1,1) not null,
Nombre nvarchar(150),
constraint PK_Artista Primary key (ArtistaId)
);

create table Album(
AlbumId int identity(1,1) NOT NULl,
Titulo nvarchar(250),
ArtistaId int,
CONSTRAINT PK_album Primary key (AlbumId),
CONSTRAINT FK_album Foreign key (ArtistaId) references Artista(ArtistaId),
);

create table Genero(
GeneroId int identity(1,1) not null,
Nombre nvarchar(150) not null,
constraint PK_Genero primary key (GeneroId)
);

create table Cancion(
CancionId int identity(1,1) not null,
Nombre nvarchar(150) not null,
AlbumId int not null,
GeneroId int not null,
constraint PK_Cancion primary key (CancionId),
constraint FK_Cancion_Album foreign key (AlbumId) references Album(AlbumId),
constraint FK_Cancion_Genero foreign key (GeneroId) references Genero(GeneroId)
);

create table Empleado(
EmpleadoId int identity(1,1) not null,
Nombres nvarchar(250)not null,
Apellidos nvarchar(250) not null,
Cargo nvarchar(150) not null,
JefeDirecto int,
Telefono int not null,
Email nvarchar(150),
constraint PK_Empleado Primary key (EmpleadoId),
constraint FK_Empleado Foreign key (JefeDirecto) references Empleado(EmpleadoId)
);

create table Cliente(
ClienteId int identity(1,1) not null,
Nombres nvarchar(250)not null,
Apellidos nvarchar(250) not null,
Telefono int not null,
Email nvarchar(150),
SoporteId int,
constraint PK_Cliente Primary key (ClienteId),
constraint FK_Cliente Foreign key (SoporteId) references Empleado(EmpleadoId)
);

create table Factura(
FacturaId int identity(1,1) not null,
ClienteId int not null,
FechaFactura datetime not null,
Total float not null,
constraint PK_Factura Primary key (FacturaId),
constraint FK_Factura Foreign key (ClienteId) REFERENCES Cliente(ClienteId)
);

create table DetalleFactura(
DetFacturaId int identity(1,1) not null,
FacturaID int not null,
CancionID int not null,
PrecioUnidad float not null,
Cantidad int not null,
constraint PK_Detalle_Factura primary key (DetFacturaId),
constraint FK_Detalle_Factura foreign key (FacturaId) references Factura(FacturaId),
constraint FK_Detalle_Factura_Cancion foreign key (CancionId) references Cancion(CancionId)
);

CREATE LOGIN AdminChinook with password = '123';
CREATE USER Admin for login AdminChinook;
Grant insert, select, update, delete, create table, create procedure, 
create view on database::Chinook to Admin;

