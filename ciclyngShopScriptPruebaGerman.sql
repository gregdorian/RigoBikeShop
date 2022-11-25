USE master
--cyclingbikeshop
GO

IF exists (select * from sysdatabases where name='cyclingbikeshop')
BEGIN
  DROP database cyclingbikeshop
END
ELSE
BEGIN
  CREATE DATABASE cyclingbikeshop
ON
( NAME = Factura_dat,
    FILENAME = 'C:\MSSQL\DATA\cyclingbikeshop.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5 )
LOG ON
( NAME = Sales_log,
    FILENAME = 'C:\MSSQL\DATA\cyclingbikeshop.ldf',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB ) ;
END
GO


USE [cyclingbikeshop]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCliente] [nvarchar](5) NOT NULL,
	[NombreCliente] [nvarchar](80) NULL,
	[DireccionCliente] [nvarchar](60) NULL,
	[TelefonoCliente] [nvarchar](10) NULL
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[IdFacturaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFacturaEncabezado] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacturaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaEncabezado]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaEncabezado](
	[IdFacturaEncabezado] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NumeroFactura] [nvarchar](6) NOT NULL,
	[Total] [Decimal] NULL,
	[FechaFactura] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacturaEncabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [nvarchar](5) NOT NULL,
	[NombreProducto] [nvarchar](30) NULL,
	[PrecioUnitario] [Decimal] NULL
	PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nchar](20) NULL,
	[Clave] [nchar](20) NULL,
	[LogIngresos] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD FOREIGN KEY([IdFacturaEncabezado])
REFERENCES [dbo].[FacturaEncabezado] ([IdFacturaEncabezado])
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

SET IDENTITY_INSERT Clientes ON
GO
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (1, '28246', 'Ame Hembery', '0 Dottie Way', '6890617');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (2, 'V7388', 'Anni Shillaker', '4 Bunting Trail', '85208827');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (3, '2832', 'Franky Sivil', '8141 Pankratz Street', '4424827');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (4, '01130', 'Arly Novakovic', '4054 Stuart Junction', '3562114');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (5, '95890', 'Quinton Cock', '1934 Pepper Wood Pass', '6282634');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (6, '20084', 'Allayne Legon', '90775 Cody Alley', '9098406');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (7, '27952', 'Rickie Swinden', '8163 Londonderry Center', '7142276');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (8, '3525', 'Viki Fowgies', '66 Carioca Drive', '5571078');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (9, '7946', 'Robyn Hayler', '857 Onsgard Pass', '20842427');
insert into Clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente) values (10, '71895', 'Gavan Troy', '7 Corscot Park', '9946090');
GO
SET IDENTITY_INSERT Clientes OFF

GO

SET IDENTITY_INSERT Productos ON

GO

insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (1, '67183', 'Toyota', 9583.98);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (2, '8820', 'Pontiac', 22632.00);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (3, '3349', 'GMC', 11693.78);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (4, '87374', 'Saab', 22198.43);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (5, '62579', 'Volkswagen', 26026.42);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (6, '67313', 'Dodge', 25853.35);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (7, '25040', 'Nissan', 16107.03);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (8, '82531', 'Mercury', 17381.15);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (9, '83901', 'Chevrolet', 17924.95);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (10, '78902', 'BMW', 1230.25);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (11, 'E8704', 'Chevrolet', 18913.83);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (12, '94204', 'Chevrolet', 16057.69);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (13, '17371', 'Chevrolet', 10084.99);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (14, '31289', 'Dodge', 16827.95);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (15, '9155', 'Toyota', 15348.87);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (16, '37403', 'Ford', 15376.49);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (17, 'V7652', 'Buick', 12637.51);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (18, '7390', 'Toyota', 27155.36);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (19, '36000', 'Bentley', 19728.57);
insert into Productos (IdProducto, CodigoProducto, NombreProducto, PrecioUnitario) values (20, '80628', 'Lincoln', 17684.81);
GO

SET IDENTITY_INSERT Productos OFF

GO

CREATE PROCEDURE [dbo].[GetAllClientes]

AS
	SELECT
	      IdCliente,
		  CodigoCliente, 
		   NombreCliente, 
		   DireccionCliente, 
		   TelefonoCliente
		   FROM Clientes
RETURN 0

GO

CREATE PROCEDURE [dbo].[ClientesInsert]
	@P_CodigoCliente NVARCHAR (5), 
	@P_NombreCliente nvarchar(20),
	@P_DireccionCliente nvarchar(60), 
	@P_TelefonoCliente nvarchar(10)
	--@Identity INT OUT
AS
	INSERT INTO Clientes(
		    CodigoCliente, 
		    NombreCliente, 
		    DireccionCliente, 
		    TelefonoCliente)
	values(
		@P_CodigoCliente,
		@P_NombreCliente,
		@P_DireccionCliente, 
		@P_TelefonoCliente
	);
	--SET @Identity = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[ClientesUpdate]
	@P_CodigoCliente NVARCHAR (5), 
	@P_NombreCliente nvarchar(20),
	@P_DireccionCliente nvarchar(60), 
	@P_TelefonoCliente nvarchar(10),
	@P_IdCliente int
AS

	UPDATE Clientes 
	SET
		   CodigoCliente    = @P_CodigoCliente,
		    NombreCliente	= @P_NombreCliente,
		    DireccionCliente = @P_DireccionCliente,
		    TelefonoCliente  =  @P_TelefonoCliente
 WHERE 			  
		IdCliente = @P_IdCliente;

--SET @Identity = SCOPE_IDENTITY();
GO
CREATE PROCEDURE [dbo].[ClientesDelete]
	@P_IdCliente int
	
AS
	DELETE FROM Clientes WHERE IdCliente = @P_IdCliente
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdClientes]
	@P_IdCliente int
AS
	SELECT CodigoCliente, 
		   NombreCliente, 
		   DireccionCliente, 
		   TelefonoCliente
		   FROM Clientes
		   WHERE IdCliente = @P_IdCliente

RETURN 0

GO
CREATE PROCEDURE [dbo].[GetAllFacturaDetalle]

AS
	SELECT IdFacturaDetalle,   
           IdFacturaEncabezado,
           IdProducto         ,
           Cantidad          
	FROM FacturaDetalle
RETURN 0

GO

CREATE PROCEDURE [dbo].[FacturaDetalleInsert]
    @P_IdFacturaEncabezado  int,
    @P_IdProducto           int,
    @P_Cantidad             SMALLINT,
	@Identity int OUT

AS
	INSERT INTO FacturaDetalle(
            IdFacturaEncabezado,
            IdProducto,
            Cantidad           
            )
	values(
		@P_IdFacturaEncabezado,
        @P_IdProducto         ,
        @P_Cantidad           
	);
	--SELECT SCOPE_IDENTITY()
	SET @Identity = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[FacturaDetalleUpdate]
    @P_IdFacturaDetalle		int,
	@P_IdFacturaEncabezado  int,
    @P_IdProducto           int,
    @P_Cantidad             SMALLINT
AS

	UPDATE FacturaDetalle 
	SET
		    IdFacturaEncabezado = @P_IdFacturaEncabezado,
            IdProducto          = @P_IdProducto,
            Cantidad            = @P_Cantidad   
 WHERE 			  
		IdFacturaDetalle = @P_IdFacturaDetalle

RETURN 0
GO
CREATE PROCEDURE [dbo].[FacturaDetalleDelete]
	@P_IdFacturaDetalle int
	
AS
	DELETE FROM FacturaDetalle WHERE IdFacturaDetalle = @P_IdFacturaDetalle
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdFacturaDetalle]
	@P_IdFacturaDetalle int
AS
	SELECT IdFacturaDetalle    , 
           IdFacturaEncabezado ,
           IdProducto          ,
           Cantidad           
	FROM FacturaDetalle
	WHERE IdFacturaDetalle = @P_IdFacturaDetalle

RETURN 0

GO

CREATE PROCEDURE [dbo].[GetAllFacturaEncabezado]

AS
	SELECT IdFacturaEncabezado,
        IdCliente,          
        NumeroFactura, 
        Total,      
        FechaFactura
	FROM FacturaEncabezado
RETURN 0

GO

CREATE PROCEDURE [dbo].[FacturaEncabezadoInsert]
    @P_IdCliente          INT           ,
    @P_NumeroFactura      NVARCHAR (6)  ,
    @P_Total              DECIMAL (18)  ,
    @P_fechaFactura       SMALLDATETIME,
	@Identity INT OUT

AS
	INSERT INTO FacturaEncabezado(
            IdCliente,          
            NumeroFactura, 
            Total,      
            FechaFactura         
            )
	values(
		@P_IdCliente ,    
        @P_NumeroFactura,
        @P_Total,
        @P_fechaFactura         
	);
	--SELECT SCOPE_IDENTITY();
	SET @Identity = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[FacturaEncabezadoUpdate]
    @P_IdFacturaEncabezado INT			,
	@P_IdCliente          INT           ,
    @P_NumeroFactura      NVARCHAR (6)  ,
    @P_Total              DECIMAL (18)  ,
    @P_fechaFactura       SMALLDATETIME 
AS

	UPDATE FacturaEncabezado 
	SET
		    IdCliente     = @P_IdCliente,          
            NumeroFactura = @P_NumeroFactura, 
            Total         = @P_Total,      
            FechaFactura  = @P_fechaFactura
 WHERE 			  
		IdFacturaEncabezado = @P_IdFacturaEncabezado

RETURN 0
GO
CREATE PROCEDURE [dbo].[FacturaEncabezadoDelete]
	@P_IdFacturaEncabezado int
	
AS
	DELETE FROM FacturaEncabezado WHERE IdFacturaEncabezado = @P_IdFacturaEncabezado
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdFacturaEncabezado]
	@P_IdFacturaEncabezado int
AS
	SELECT IdFacturaEncabezado,
        IdCliente,          
        NumeroFactura, 
        Total,      
        FechaFactura
	FROM FacturaEncabezado
	WHERE IdFacturaEncabezado = @P_IdFacturaEncabezado

RETURN 0

GO

CREATE PROCEDURE [dbo].[GetAllProducto]

AS
	SELECT 
    IdProducto    ,
    CodigoProducto,
    NombreProducto,
    PrecioUnitario
     
	FROM Productos
RETURN 0

GO

CREATE PROCEDURE [dbo].[ProductoInsert]
    @P_IdProducto    INT,
    @P_CodigoProducto NVARCHAR (5),
    @P_NombreProducto NVARCHAR (30) ,
    @P_PrecioUnitario    DECIMAL (18)  
	--@Identity INT OUT

AS
	INSERT INTO Productos(
            IdProducto    ,
            CodigoProducto,
            NombreProducto,
            PrecioUnitario
            )
	values(
		@P_IdProducto,
		@P_CodigoProducto,
		@P_NombreProducto ,
		@P_PrecioUnitario 
	);
RETURN 0

GO

CREATE PROCEDURE [dbo].[ProductoUpdate]
    @P_IdProducto    INT         ,
    @P_CodigoProducto NVARCHAR (5),
    @P_NombreProducto NVARCHAR (30) ,
    @P_PrecioUnitario    DECIMAL (18)  
AS

	UPDATE Productos
	SET
        CodigoProducto = @P_CodigoProducto,
        NombreProducto = @P_NombreProducto ,
        PrecioUnitario    = @P_PrecioUnitario     
 WHERE 			  	
 	IdProducto = @P_IdProducto

RETURN 0
GO
CREATE PROCEDURE [dbo].[ProductoDelete]
	@P_IdProducto int
	
AS
	DELETE FROM Productos WHERE IdProducto = @P_IdProducto
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdProducto]
	@P_IdProducto int
AS
	SELECT     
        IdProducto    ,
        CodigoProducto,
        NombreProducto,
        PrecioUnitario
        
	FROM Productos
	WHERE IdProducto = @P_IdProducto

RETURN 0

GO


CREATE PROCEDURE [dbo].[GetAllUsuario]

AS
	SELECT 
    UserId    ,
    NombreUsuario,
    Clave,
    LogIngresos
	FROM Usuario
RETURN 0

GO

CREATE PROCEDURE [dbo].[UsuarioInsert]
    @P_IdUsuario INT,
    @P_NombreUsuario NCHAR (20) NULL,
    @P_Clave         NCHAR (20) NULL,
    @P_LogIngresos   NCHAR (10) NULL,
	@Identity INT OUT

AS
	INSERT INTO Usuario(
                UserId,
                NombreUsuario,
                Clave,
                LogIngresos
            )
	values(
		@P_IdUsuario,
        @P_NombreUsuario,
        @P_Clave,
        @P_LogIngresos
    );
RETURN 0

GO

CREATE PROCEDURE [dbo].[UsuarioUpdate]
          @P_IdUsuario INT,
          @P_NombreUsuario NCHAR (20) NULL,
          @P_Clave         NCHAR (20) NULL,
          @P_LogIngresos   NCHAR (10) NULL
AS

	UPDATE Usuario 
	SET
        NombreUsuario = @P_NombreUsuario,
        Clave         = @P_Clave,
        LogIngresos   = @P_LogIngresos
 WHERE 			  	
 	UserId = @P_IdUsuario

RETURN 0
GO
CREATE PROCEDURE [dbo].[UsuarioDelete]
	@P_IdUsuario int
	
AS
	DELETE FROM Usuario WHERE UserId = @P_IdUsuario
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdUsuario]
	@P_IdUsuario int
AS
	SELECT 
        UserId    ,
        NombreUsuario,
        Clave,
        LogIngresos
	FROM Usuario
	WHERE UserId = @P_IdUsuario

RETURN 0

GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT INTO [dbo].[Usuario] ([userId], [NombreUsuario], [Clave], [LogIngresos]) VALUES (1, N'AAdmin', N'12345', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF

--DBCC CHECKIDENT ('Clientes', RESEED, 0);  
--GO  
--DBCC CHECKIDENT ('FacturaEncabezado', RESEED, 0);  
--GO  