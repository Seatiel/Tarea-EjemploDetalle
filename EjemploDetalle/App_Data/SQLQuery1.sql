create table Clientes(
ClienteId int identity(1,1) primary key,
Nombres varchar(100)
);

create table Cotizaciones(
CotizacionId int identity(1,1) primary key,
Fecha date,
Monto decimal,
ClienteId int
);

create table CotizacionesDetalles(
DetalleId int identity(1,1) primary key,
CotizacionId int, 
productoId int,
Cantidad decimal,
Precio decimal
);

create table Productos(
ProductoId int identity(1,1) primary key,
Descripcion varchar(100),
Costo decimal,
Precio decimal
);