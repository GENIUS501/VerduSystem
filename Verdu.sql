CREATE DATABASE Diamond
GO
Use Diamond
go
create table Tab_Roles(
	Id_Rol int IDENTITY(1,1) primary key,
	Nombre_Rol varchar(25)
);
CREATE TABLE Tab_Permisos(
    ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	Modulo VARCHAR(20) NOT NULL,
    Accion VARCHAR(27) NULL,
    Id_Rol INT NOT NULL,
	CONSTRAINT Fk_PERMISOS_ROLES FOREIGN KEY(Id_Rol) REFERENCES Tab_Roles(Id_Rol)
);
CREATE TABLE Tab_Usuarios(
	ID_Usuario INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Cedula VARCHAR(12) NOT NULL UNIQUE,
	Nombre VARCHAR(25) NOT NULL,
	Primer_Apellido VARCHAR(25) NOT NULL,
	Segundo_Apellido VARCHAR(25) NOT NULL,
	Nombre_Usuario VARCHAR(25) NOT NULL,
	Id_Rol int NOT NULL,
	Contrasena VARCHAR(MAX) NOT NULL,
	Estado INT NOT NULL,
	Telefono VARCHAR(8) NULL,
	Correo VARCHAR(30) NOT NULL,
	CONSTRAINT Fk_USUARIOS_ROLES FOREIGN KEY(Id_Rol) REFERENCES Tab_Roles(Id_Rol),
);
CREATE TABLE Tab_Clientes(
	Numero_Cliente INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Cedula VARCHAR(25) NOT NULL UNIQUE,
	Nombre VARCHAR(25) NOT NULL,
	Primer_Apellido VARCHAR(25) NOT NULL,
	Segundo_Apellido VARCHAR(25) NOT NULL,
	Direccion VARCHAR(255) NOT NULL,
	Telefono INT NULL,
	Correo VARCHAR(30) NOT NULL
);
CREATE TABLE Tab_Tipo_Productos(
	ID_Tipo_Producto INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(25)NOT NULL,
	Descripcion TEXT NOT NULL
);
CREATE TABLE Tab_Productos(
	ID_Producto INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(25)NOT NULL,
	Descripcion TEXT NOT NULL,
	ID_Tipo_Producto INT NOT NULL,
	Precio DECIMAL NOT NULL,
	Cantidad INT NOT NULL,
	Imagen varbinary(MAX) NULL,
	CONSTRAINT Fk_PRODUCTOS_TIPO FOREIGN KEY(ID_Tipo_Producto) REFERENCES Tab_Tipo_Productos(ID_Tipo_Producto),
);
CREATE TABLE Tab_Venta(
	ID_Usuario INT NOT NULL,
	ID_Cliente INT NOT NULL,
	Tipo_pago VARCHAR(8) NOT NULL,
	Numero_factura INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	CantidadProducto FLOAT NOT NULL,
	Fecha_venta DATETIME NOT NULL,
	Total FLOAT NOT NULL,
	CONSTRAINT Fk_VENTAS_USUARIOS FOREIGN KEY(Id_Usuario) REFERENCES Tab_Usuarios(Id_Usuario),
	CONSTRAINT Fk_VENTAS_CLIENTES FOREIGN KEY(ID_Cliente) REFERENCES Tab_Clientes(Numero_Cliente)
);

CREATE TABLE Tab_Venta_detallada(
	Numero_factura INT NOT NULL,
	ID_Producto INT NOT NULL,
	Linea INT NOT NULL,
	PRIMARY KEY(Numero_factura,ID_Producto,Linea),
	CONSTRAINT Fk_DETALLE_VENTAS FOREIGN KEY(Numero_factura) REFERENCES Tab_Venta(Numero_factura),
	CONSTRAINT Fk_DETALLE_PRODUCTOS FOREIGN KEY(ID_Producto) REFERENCES Tab_Productos(ID_Producto),
);

CREATE TABLE Tab_Bitacora_Sesiones(
    codigo_ingreso_salida int IDENTITY(1,1) primary key, 
    fecha_hora_ingreso DATETIME NOT NULL,
    fecha_hora_salida DATETIME NULL,
    Id_Usuario INT,
	CONSTRAINT Fk_SESIONES_USUARIOS FOREIGN KEY(Id_Usuario) REFERENCES Tab_Usuarios(Id_Usuario)
);

CREATE TABLE Tab_Bitacora_Movimientos(
   codigo_movimiento_usuario int IDENTITY(1,1) primary key, 
   fecha_hora_movimiento DATETIME NOT NULL,
   tipo_movimiento varchar(50),
   modulo VARCHAR(20),
   Id_Usuario INT,
   CONSTRAINT Fk_MOVIMIENTOS_USUARIOS FOREIGN KEY(Id_Usuario) REFERENCES Tab_Usuarios(Id_Usuario)
);

CREATE TABLE Tab_Devoluciones(
	IdDevolucion	INT PRIMARY KEY IDENTITY(1,1)NOT NULL,
	IdVenta	INT NOT NULL,
	IDCliente	INT NOT NULL,
	FechaDevolucion	DATETIME NOT NULL,
	CantidadProducto	FLOAT NOT NULL,
	IdUsuario	INT NOT NULL,
	CONSTRAINT Fk_Devoluciones_Venta FOREIGN KEY(IdVenta) REFERENCES Tab_Venta(Numero_Factura),
	CONSTRAINT Fk_Devoluciones_Cliente FOREIGN KEY(IdCliente) REFERENCES Tab_Clientes(Numero_Cliente),
	CONSTRAINT Fk_Devoluciones_Usuario FOREIGN KEY(IdUsuario) REFERENCES Tab_Usuarios(ID_Usuario)
);

INSERT INTO Tab_Roles(Nombre_Rol)VALUES('Administrador')

INSERT INTO Tab_Permisos (Modulo, Accion, Id_Rol) VALUES
('Roles', 'Roles', 1),
('Roles', 'Agregar', 1),
('Roles', 'Modificar', 1),
('Roles', 'Eliminar', 1),
('Roles', 'Consultar', 1),
('Usuarios', 'Usuarios', 1),
('Usuarios', 'Agregar', 1),
('Usuarios', 'Modificar', 1),
('Usuarios', 'Eliminar', 1),
('Usuarios', 'Consultar', 1),
('Clientes', 'Clientes', 1),
('Clientes', 'Agregar', 1),
('Clientes', 'Modificar', 1),
('Clientes', 'Eliminar', 1),
('Clientes', 'Consultar', 1),
('Productos', 'Estudiantes', 1),
('Productos', 'Agregar', 1),
('Productos', 'Modificar', 1),
('Productos', 'Eliminar', 1),
('Productos', 'Consultar', 1)

INSERT INTO Tab_Usuarios (Cedula,Nombre,Primer_Apellido,Segundo_Apellido, Nombre_Usuario, Contrasena,Telefono,Correo,Id_Rol, Estado)
VALUES ('123456789', 'Stephanie','Oviedo','Jiménez', 'Administrador1', 'HVEvEz0I1wRgOshEmHhas82xZwI=',12345678,'1@1.com',1,1)