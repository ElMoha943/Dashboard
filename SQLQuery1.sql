use base1;
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
    productos int,
);

create table ventas_productos(
	id int IDENTITY(1,1) PRIMARY KEY,
    producto_id int,
)