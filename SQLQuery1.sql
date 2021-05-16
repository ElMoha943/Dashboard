create table productos(
    id int IDENTITY(1,1) PRIMARY KEY,
    nombre text NOT NULL,
    descripcion text,
    marca text,
    precio float NOT NULL,
    stock int NOT NULL DEFAULT 0,
);

create table ventas(
    id int IDENTITY(1,1) PRIMARY KEY,
    monto float NOT NULL,
    fecha datetime NOT NULL,
);

create table ventas_productos(
    id int IDENTITY(1,1) PRIMARY KEY,
    venta_id int NOT NULL,
    producto_id int NOT NULL,
);

create table usuarios(
	id int identity(1,1) not null primary key,
	username text not null,
	password text not null,
	rol text not null,
);

create table agenda(
	id int identity(1,1) not null primary key,
	nombre text,
	descripcion text,
	telefono text,
	email text,
);
