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
)
