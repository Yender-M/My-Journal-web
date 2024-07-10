USE [master]
GO
DROP DATABASE [CBN_IGLESIA]
GO
/****** Object:  Database [CBN_IGLESIA]    Script Date: 10/7/2024 02:47:17 ******/
CREATE DATABASE [CBN_IGLESIA]
GO
USE [CBN_IGLESIA]
GO
/****** Object:  Schema [ADM]    Script Date: 10/7/2024 02:47:17 ******/
CREATE SCHEMA [ADM]
GO
/****** Object:  Schema [IGLESIA]    Script Date: 10/7/2024 02:47:17 ******/
CREATE SCHEMA [IGLESIA]
GO
/****** Object:  Table [ADM].[Divisas]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Divisas](
	[IdDivisa] [int] IDENTITY(1,1) NOT NULL,
	[CodDivisa] [nvarchar](20) NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Simbolo] [nvarchar](5) NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDivisa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[EgresosCategoria]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[EgresosCategoria](
	[IdCatEgreso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCatEgreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[Iglesia]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Iglesia](
	[IdIglesia] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](200) NOT NULL,
	[Telefono] [nvarchar](20) NULL,
	[Logo] [varbinary](max) NULL,
	[Esquema] [nvarchar](20) NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIglesia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [ADM].[IngresosCategoria]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[IngresosCategoria](
	[IdCatIngreso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCatIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[Ministerios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Ministerios](
	[IdMinisterio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMinisterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[MinisteriosDetalle]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[MinisteriosDetalle](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdMinisterio] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Ver] [int] NULL,
	[Crear] [int] NULL,
	[Editar] [int] NULL,
	[Anular] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[OfrendasCategoria]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[OfrendasCategoria](
	[IdCatOfrenda] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCatOfrenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[Permisos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[NombreVista] [nvarchar](50) NOT NULL,
	[Ver] [int] NULL,
	[Crear] [int] NULL,
	[Editar] [int] NULL,
	[Eliminar] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[Roles]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[CodRol] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[Usuarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Clave] [nvarchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[UsuariosCregoriasOfrenda]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[UsuariosCregoriasOfrenda](
	[IdUserCat] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCatOfrenda] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUserCat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ADM].[UsuariosMinisterio]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ADM].[UsuariosMinisterio](
	[IdUserMinisterio] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdMinisterio] [int] NOT NULL,
	[Leer] [int] NULL,
	[Crear] [int] NULL,
	[Anular] [int] NULL,
	[Editar] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUserMinisterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[Diezmo]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[Diezmo](
	[IdDiezmo] [int] IDENTITY(1,1) NOT NULL,
	[IdMiembro] [int] NULL,
	[Cantidad] [float] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[FechaDiezmo] [datetime] NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Alias] [nvarchar](50) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAnula] [int] NULL,
	[FechaAnulacin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDiezmo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[EgresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[EgresosVarios](
	[IdEgreVarios] [int] IDENTITY(1,1) NOT NULL,
	[IdCatEgreso] [int] NULL,
	[IdMinisterio] [int] NULL,
	[Cantidad] [float] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[FechaEgreso] [datetime] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAnula] [int] NULL,
	[FechaAnulacion] [datetime] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEgreVarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[IngresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[IngresosVarios](
	[IdIngreVarios] [int] IDENTITY(1,1) NOT NULL,
	[IdCatIngreso] [int] NULL,
	[IdMinisterio] [int] NULL,
	[Cantidad] [float] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAnula] [int] NULL,
	[FechaAnulacion] [datetime] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIngreVarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[Miembros]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[Miembros](
	[IdMiembro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Telefono] [nvarchar](20) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaBautismo] [datetime] NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMiembro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[OfrendaPatoral]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[OfrendaPatoral](
	[IdOfrePasto] [int] IDENTITY(1,1) NOT NULL,
	[IdMiembro] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Cantidad] [float] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOfrePasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[Ofrendas]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[Ofrendas](
	[IdOfrenda] [int] IDENTITY(1,1) NOT NULL,
	[IdCatOfrenda] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Fecha] [datetime] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [int] NULL,
	[UsuarioAnula] [int] NULL,
	[FechaAnulacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOfrenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[Pagos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[Pagos](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Cantidad] [float] NOT NULL,
	[Divisa] [int] NULL,
	[TasaCambio] [float] NULL,
	[FechaPago] [datetime] NOT NULL,
	[Estado] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioAnula] [int] NULL,
	[FechaAnulacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[PagosCategorias]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[PagosCategorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [IGLESIA].[Proyecto]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [IGLESIA].[Proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Estado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [ADM].[EgresosCategoria]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [ADM].[IngresosCategoria]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [ADM].[Ministerios]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [ADM].[OfrendasCategoria]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [ADM].[UsuariosCregoriasOfrenda]  WITH CHECK ADD FOREIGN KEY([IdCatOfrenda])
REFERENCES [ADM].[OfrendasCategoria] ([IdCatOfrenda])
GO
ALTER TABLE [ADM].[UsuariosCregoriasOfrenda]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [ADM].[UsuariosMinisterio]  WITH CHECK ADD FOREIGN KEY([IdMinisterio])
REFERENCES [ADM].[Ministerios] ([IdMinisterio])
GO
ALTER TABLE [ADM].[UsuariosMinisterio]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[Diezmo]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[Diezmo]  WITH CHECK ADD FOREIGN KEY([IdDiezmo])
REFERENCES [IGLESIA].[Diezmo] ([IdDiezmo])
GO
ALTER TABLE [IGLESIA].[Diezmo]  WITH CHECK ADD FOREIGN KEY([IdMiembro])
REFERENCES [IGLESIA].[Miembros] ([IdMiembro])
GO
ALTER TABLE [IGLESIA].[Diezmo]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[EgresosVarios]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[EgresosVarios]  WITH CHECK ADD FOREIGN KEY([IdCatEgreso])
REFERENCES [ADM].[EgresosCategoria] ([IdCatEgreso])
GO
ALTER TABLE [IGLESIA].[EgresosVarios]  WITH CHECK ADD FOREIGN KEY([IdMinisterio])
REFERENCES [ADM].[Ministerios] ([IdMinisterio])
GO
ALTER TABLE [IGLESIA].[EgresosVarios]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[IngresosVarios]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[IngresosVarios]  WITH CHECK ADD FOREIGN KEY([IdCatIngreso])
REFERENCES [ADM].[IngresosCategoria] ([IdCatIngreso])
GO
ALTER TABLE [IGLESIA].[IngresosVarios]  WITH CHECK ADD FOREIGN KEY([IdMinisterio])
REFERENCES [ADM].[Ministerios] ([IdMinisterio])
GO
ALTER TABLE [IGLESIA].[IngresosVarios]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[Miembros]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[OfrendaPatoral]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[OfrendaPatoral]  WITH CHECK ADD FOREIGN KEY([IdMiembro])
REFERENCES [IGLESIA].[Miembros] ([IdMiembro])
GO
ALTER TABLE [IGLESIA].[OfrendaPatoral]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[Ofrendas]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[Ofrendas]  WITH CHECK ADD FOREIGN KEY([IdCatOfrenda])
REFERENCES [ADM].[OfrendasCategoria] ([IdCatOfrenda])
GO
ALTER TABLE [IGLESIA].[Ofrendas]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[Pagos]  WITH CHECK ADD FOREIGN KEY([Divisa])
REFERENCES [ADM].[Divisas] ([IdDivisa])
GO
ALTER TABLE [IGLESIA].[Pagos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [IGLESIA].[PagosCategorias] ([IdCategoria])
GO
ALTER TABLE [IGLESIA].[Pagos]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[PagosCategorias]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [IGLESIA].[Proyecto]  WITH CHECK ADD FOREIGN KEY([UsuarioCreacion])
REFERENCES [ADM].[Usuarios] ([IdUsuario])
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetAnularDiezmo]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetAnularDiezmo]
(
	@IdDiezmo INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Diezmo
		SET Estado = 0, UsuarioAnula = @IdUsuario, FechaAnulacin = GETDATE() WHERE IdDiezmo = @IdDiezmo
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetAnularEgreVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [IGLESIA].[pcdGetAnularEgreVarios]
(
	@IdEgreVarios INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].EgresosVarios
		SET Estado = 0, UsuarioAnula = @IdUsuario, FechaAnulacion = GETDATE() WHERE IdEgreVarios = @IdEgreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetAnularIngreVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetAnularIngreVarios]
(
	@IdIngreVarios INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].IngresosVarios
		SET Estado = 0, UsuarioAnula = @IdUsuario, FechaAnulacion = GETDATE() WHERE IdIngreVarios = @IdIngreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetAnularOfrenda]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetAnularOfrenda]
(
	@IdOfrenda INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Ofrendas
		SET Estado = 0, UsuarioAnula = @IdUsuario, FechaAnulacion = GETDATE() WHERE IdOfrenda = @IdOfrenda
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetAnularPago]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetAnularPago]
(
	@IdPago INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Pagos SET Estado = 0, UsuarioAnula = @IdUsuario, FechaAnulacion = GETDATE()
		WHERE IdPago = @IdPago
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetCategoriaEgreso]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdGetCategoriaEgreso]
AS
BEGIN
	SELECT ec.IdCatEgreso, ec.Nombre, ec.Descripcion, ec.Estado FROM [ADM].EgresosCategoria ec
END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetCategoriaIngreso]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdGetCategoriaIngreso]
AS
BEGIN
	SELECT ic.IdCatIngreso, ic.Nombre, ic.Descripcion, ic.Estado FROM [ADM].IngresosCategoria ic
END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetCategoriaOfrenda]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [IGLESIA].[pcdGetCategoriaOfrenda]
AS
BEGIN
	SELECT oc.IdCatOfrenda, oc.Nombre, oc.Descripcion, oc.Estado FROM [ADM].OfrendasCategoria oc
END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetCategoriaPagos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [IGLESIA].[pcdGetCategoriaPagos]
AS
BEGIN
	SELECT IdCategoria, Nombre, Descripcion, Estado FROM IGLESIA.PagosCategorias
END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetDiezmo]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetDiezmo]
(
	@IdDiezmo INT
)
AS
BEGIN
    SELECT 
        di.IdDiezmo,di.IdMiembro,di.Cantidad,di.Divisa,di.TasaCambio,di.FechaDiezmo,di.Descripcion,di.Alias,di.Estado,
        m.IdMiembro, m.Nombre,
        d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
    FROM [IGLESIA].Diezmo di
    LEFT JOIN [IGLESIA].Miembros m ON di.IdMiembro = m.IdMiembro
    LEFT JOIN [ADM].Divisas d ON di.Divisa = d.IdDivisa
	WHERE di.IdDiezmo = @IdDiezmo
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetDivisas]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [IGLESIA].[pcdGetDivisas]
AS
BEGIN
	SELECT d.IdDivisa, d.CodDivisa, d.Descripcion, d.Simbolo FROM [ADM].Divisas d
END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetEgreso]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE       PROCEDURE [IGLESIA].[pcdGetEgreso] 
(
	@IdEgreVarios int
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			i.IdEgreVarios, i.IdCatEgreso, i.IdMinisterio, i.Cantidad, i.Descripcion,
			convert (date, i.FechaEgreso) FechaEgreso,i.Divisa,i.TasaCambio, i.Estado,
			ic.IdCatEgreso, ic.Nombre CategoriaNombre, ic.Descripcion CategoriaDescripcion,
			m.IdMinisterio,m.Nombre MinisterioNombre,m.Descripcion MinisterioDescripcion,
		    d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
		FROM [IGLESIA].EgresosVarios i
		LEFT JOIN [ADM].EgresosCategoria ic ON i.IdCatEgreso = ic.IdCatEgreso
		LEFT JOIN [ADM].Divisas d ON i.Divisa = d.IdDivisa
		LEFT JOIN [ADM].Ministerios m ON i.IdMinisterio = m.IdMinisterio
		WHERE i.IdEgreVarios = @IdEgreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetEgresoCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [IGLESIA].[pcdGetEgresoCat] 
(
	@IdEgresoCat int
)
AS
	BEGIN
		SELECT ec.IdCatEgreso,ec.Nombre,ec.Descripcion,ec.Estado
		FROM [ADM].EgresosCategoria ec
		WHERE ec.IdCatEgreso = @IdEgresoCat
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetIngreso]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetIngreso] 
(
	@IdIngreVarios int
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			i.IdIngreVarios, i.IdCatIngreso, i.IdMinisterio, i.Cantidad, i.Descripcion,
			convert (date, i.FechaIngreso) FechaIngreso,i.Divisa,i.TasaCambio, i.Estado,
			ic.IdCatIngreso, ic.Nombre CategoriaNombre, ic.Descripcion CategoriaDescripcion,
			m.IdMinisterio,m.Nombre MinisterioNombre,m.Descripcion MinisterioDescripcion,
		    d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
		FROM [IGLESIA].IngresosVarios i
		LEFT JOIN [ADM].IngresosCategoria ic ON i.IdCatIngreso = ic.IdCatIngreso
		LEFT JOIN [ADM].Divisas d ON i.Divisa = d.IdDivisa
		LEFT JOIN [ADM].Ministerios m ON i.IdMinisterio = m.IdMinisterio
		WHERE i.IdIngreVarios = @IdIngreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetIngresoCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [IGLESIA].[pcdGetIngresoCat] 
(
	@IdIngresoCat int
)
AS
	BEGIN
		SELECT ic.IdCatIngreso,ic.Nombre,ic.Descripcion,ic.Estado
		FROM [ADM].IngresosCategoria ic
		WHERE ic.IdCatIngreso = @IdIngresoCat
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoDiezmo]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetListadoDiezmo]
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
BEGIN
    SELECT 
        di.IdDiezmo,di.IdMiembro,di.Cantidad,di.Divisa,di.TasaCambio,di.FechaDiezmo,di.Descripcion,di.Alias,di.Estado,
        m.IdMiembro, CASE WHEN di.Alias IS NULL OR di.Alias = '' THEN  m.Nombre ELSE di.Alias END Nombre,
        d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
    FROM [IGLESIA].Diezmo di
    LEFT JOIN [IGLESIA].Miembros m ON di.IdMiembro = m.IdMiembro
    LEFT JOIN [ADM].Divisas d ON di.Divisa = d.IdDivisa
	WHERE di.FechaDiezmo >= @FechaIni and di.FechaDiezmo <= @FechaFin
    ORDER BY di.FechaDiezmo DESC
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoEgresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE    PROCEDURE [IGLESIA].[pcdGetListadoEgresosVarios] 
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			i.IdEgreVarios, i.IdCatEgreso, i.IdMinisterio, i.Cantidad, i.Descripcion,
			convert (date, i.FechaEgreso) FechaEgreso,i.Divisa,i.TasaCambio, i.Estado,
			ic.IdCatEgreso, ic.Nombre CategoriaNombre, ic.Descripcion CategoriaDescripcion,
			m.IdMinisterio,m.Nombre MinisterioNombre,m.Descripcion MinisterioDescripcion,
		    d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
		FROM [IGLESIA].EgresosVarios i
		LEFT JOIN [ADM].EgresosCategoria ic ON i.IdCatEgreso = ic.IdCatEgreso
		LEFT JOIN [ADM].Divisas d ON i.Divisa = d.IdDivisa
		LEFT JOIN [ADM].Ministerios m ON i.IdMinisterio = m.IdMinisterio
		WHERE i.FechaEgreso >= @FechaIni AND i.FechaEgreso <= @FechaFin
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoIngresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [IGLESIA].[pcdGetListadoIngresosVarios] 
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			i.IdIngreVarios, i.IdCatIngreso, i.IdMinisterio, i.Cantidad, i.Descripcion,
			convert (date, i.FechaIngreso) FechaIngreso,i.Divisa,i.TasaCambio, i.Estado,
			ic.IdCatIngreso, ic.Nombre CategoriaNombre, ic.Descripcion CategoriaDescripcion,
			m.IdMinisterio,m.Nombre MinisterioNombre,m.Descripcion MinisterioDescripcion,
		    d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa
		FROM [IGLESIA].IngresosVarios i
		LEFT JOIN [ADM].IngresosCategoria ic ON i.IdCatIngreso = ic.IdCatIngreso
		LEFT JOIN [ADM].Divisas d ON i.Divisa = d.IdDivisa
		LEFT JOIN [ADM].Ministerios m ON i.IdMinisterio = m.IdMinisterio
		WHERE i.FechaIngreso >= @FechaIni AND i.FechaIngreso <= @FechaFin
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoMiembros]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetListadoMiembros] --20240622,20240622
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
	BEGIN
		SELECT m.IdMiembro, m.Nombre, m.Apellido, m.Direccion, m.Telefono, m.FechaNacimiento, m.FechaBautismo, m.Estado
		FROM [IGLESIA].Miembros m
		where FORMAT(m.FechaCreacion,'yyyyMMdd') >= @FechaIni AND FORMAT(m.FechaCreacion,'yyyyMMdd') <= @FechaFin
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoMinisterios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetListadoMinisterios] --20240101,20240606
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			m.IdMinisterio, m.Nombre, m.Descripcion, m.Estado, m.FechaCreacion, m.UsuarioCreacion, u.Usuario, md.Ver, md.Crear, md.Editar, md.Anular
		FROM ADM.Ministerios m
		LEFT JOIN [ADM].MinisteriosDetalle md ON m.IdMinisterio = md.IdMinisterio
		LEFT JOIN [ADM].Usuarios u ON md.IdUsuario = u.IdUsuario 
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadoOfrendas]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [IGLESIA].[pcdGetListadoOfrendas] --20240101,20240606
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        o.IdOfrenda, o.IdCatOfrenda, o.Cantidad,o.Descripcion, convert (date, o.Fecha) Fecha,o.Divisa,
        o.TasaCambio,o.UsuarioCreacion, o.FechaCreacion,o.UsuarioModifica, o.FechaModifica,
        c.IdCatOfrenda, c.Nombre CategoriaNombre, c.Descripcion CategoriaDescripcion,
        d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa, o.Estado
    FROM [IGLESIA].Ofrendas o
    LEFT JOIN [ADM].OfrendasCategoria c ON o.IdCatOfrenda = c.IdCatOfrenda
    LEFT JOIN [ADM].Divisas d ON o.Divisa = d.IdDivisa
	WHERE o.Fecha >= @FechaIni and o.Fecha <= @FechaFin
    ORDER BY o.Fecha DESC
END

GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetListadosPagos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetListadosPagos] 
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8)
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
		p.IdPago,p.IdCategoria,p.Cantidad,p.Descripcion,p.FechaPago,p.Divisa,p.TasaCambio,p.Estado,
		pc.IdCategoria, pc.Nombre CategoriaNombre, pc.Descripcion CategoriaDescripcion,
		d.IdDivisa,d.CodDivisa,d.Descripcion Divisa
		FROM IGLESIA.Pagos p
		INNER JOIN IGLESIA.PagosCategorias pc ON pc.IdCategoria = p.IdCategoria 
		INNER JOIN ADM.Divisas d ON p.Divisa = d.IdDivisa
		WHERE p.FechaPago >= @FechaIni and p.FechaPago <= @FechaFin
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetMiembro]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetMiembro] 
(
	@IdMiembro int
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
		m.IdMiembro,m.Nombre,m.Apellido,m.Direccion,m.Telefono,convert (date, m.FechaBautismo) FechaBautismo, convert (date, m.FechaNacimiento) FechaNacimiento, Estado
		FROM [IGLESIA].Miembros m
		WHERE m.IdMiembro = @IdMiembro
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetMiembros]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetMiembros]
	AS
	BEGIN
		SELECT m.IdMiembro,  m.Nombre,m.Apellido,m.Estado FROM [IGLESIA].Miembros m
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetMinisteriosLista]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdGetMinisteriosLista]
AS
	BEGIN
		SELECT IdMinisterio, Nombre, Descripcion, Estado FROM [ADM].Ministerios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetOfrenda]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [IGLESIA].[pcdGetOfrenda] 
(
	@IdOfrenda int
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
			o.IdOfrenda, o.IdCatOfrenda, o.Cantidad,o.Descripcion, convert (date, o.Fecha) Fecha,o.Divisa,
			o.TasaCambio,o.UsuarioCreacion, o.FechaCreacion,o.UsuarioModifica, o.FechaModifica,
			c.IdCatOfrenda, c.Nombre CategoriaNombre, c.Descripcion CategoriaDescripcion,
		    d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa, o.Estado
		FROM [IGLESIA].Ofrendas o
		LEFT JOIN [ADM].OfrendasCategoria c ON o.IdCatOfrenda = c.IdCatOfrenda
		LEFT JOIN [ADM].Divisas d ON o.Divisa = d.IdDivisa
		WHERE o.IdOfrenda = @IdOfrenda
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetOfrendaCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdGetOfrendaCat] 
(
	@IdOfrendaCat int
)
AS
	BEGIN
		SELECT oc.IdCatOfrenda,oc.Nombre,oc.Descripcion,oc.Estado
		FROM [ADM].OfrendasCategoria oc
		WHERE oc.IdCatOfrenda = @IdOfrendaCat
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdGetPagos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [IGLESIA].[pcdGetPagos] 
(
	@IdPago INT
)
AS
	BEGIN
		SET NOCOUNT ON;

		SELECT 
		p.IdPago,p.IdCategoria,p.Cantidad,p.Descripcion,p.FechaPago,p.Divisa,p.TasaCambio,p.Estado,
		pc.IdCategoria, pc.Nombre CategoriaNombre, pc.Descripcion CategoriaDescripcion,
		d.IdDivisa,d.CodDivisa,d.Descripcion Divisa
		FROM IGLESIA.Pagos p
		INNER JOIN IGLESIA.PagosCategorias pc ON pc.IdCategoria = p.IdCategoria 
		INNER JOIN ADM.Divisas d ON p.Divisa = d.IdDivisa
		WHERE P.IdPago = @IdPago
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetDiezmoEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     procedure [IGLESIA].[pcdSetDiezmoEdit]
(
	@IdDiezmo INT,
	@IdMiembro INT,
	@Alias NVARCHAR(200) = NULL,
	@Descripcion NVARCHAR(500) = NULL,
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Fecha DATETIME,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Diezmo
		SET IdMiembro = @IdMiembro,
			Cantidad = @Cantidad,
			Divisa = @IdDivisa,
			TasaCambio = @TasaCambio,
			FechaDiezmo = @Fecha,
			Descripcion = @Descripcion,
			Alias = @Alias,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdDiezmo = @IdDiezmo
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetDiezmos]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdSetDiezmos]
(
	@IdMiembro INT,
	@Alias NVARCHAR(200) = null,
	@Descripcion NVARCHAR(500) = null,
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Fecha DATETIME,
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [IGLESIA].Diezmo(IdMiembro,Cantidad,Divisa,TasaCambio,FechaDiezmo,Descripcion,Alias,Estado,UsuarioCreacion,FechaCreacion) 
							 VALUES (@IdMiembro,@Cantidad,@IdDivisa,@TasaCambio,@Fecha,@Descripcion,@Alias,1,@IdUsuario,GETDATE())
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetEgresoCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       procedure [IGLESIA].[pcdSetEgresoCat]
(
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [ADM].EgresosCategoria(Nombre,Descripcion,Estado,UsuarioCreacion,FechaCreacion) 
		VALUES (@Nombre,@Descripcion,1,@IdUsuario,GETDATE())
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetEgresoCatEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [IGLESIA].[pcdSetEgresoCatEdit]
(
	@IdCatEgreso INT,
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@Estado INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [ADM].EgresosCategoria
		SET Nombre = @nombre,
			Descripcion = @Descripcion,
			Estado = @Estado,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdCatEgreso = @IdCatEgreso
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetEgresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     procedure [IGLESIA].[pcdSetEgresosVarios]
(
	@IdCatEgreso INT,
	@IdMinisterio INT,
	@Descripcion NVARCHAR(500),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@FechaEgreso DATETIME,
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [IGLESIA].EgresosVarios (IdCatEgreso,IdMinisterio,Cantidad,Divisa,TasaCambio,Descripcion,FechaEgreso,UsuarioCreacion,FechaCreacion,Estado) 
		VALUES (@IdCatEgreso,@IdMinisterio,@Cantidad,@IdDivisa,@TasaCambio,@Descripcion,@FechaEgreso,@IdUsuario,GETDATE(),1)
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetEgresoVariosEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     procedure [IGLESIA].[pcdSetEgresoVariosEdit]
(
	@IdCatEgreso INT,
	@IdMinisterio INT,
	@Descripcion NVARCHAR(200),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@FechaEgreso DATETIME,
	@Estado INT,
	@IdUsuario INT,
	@IdEgreVarios INT
)
AS
	BEGIN
		UPDATE [IGLESIA].EgresosVarios
		SET IdCatEgreso = @IdCatEgreso,
			IdMinisterio = @IdMinisterio,
			Cantidad = @Cantidad,
			Descripcion = @Descripcion,
			FechaEgreso = @FechaEgreso,
			Divisa = @IdDivisa,
			TasaCambio = @TasaCambio,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdEgreVarios = @IdEgreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetIngresoCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     procedure [IGLESIA].[pcdSetIngresoCat]
(
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [ADM].IngresosCategoria(Nombre,Descripcion,Estado,UsuarioCreacion,FechaCreacion) 
		VALUES (@Nombre,@Descripcion,1,@IdUsuario,GETDATE())
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetIngresoCatEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdSetIngresoCatEdit]
(
	@IdCatIngreso INT,
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@Estado INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [ADM].IngresosCategoria
		SET Nombre = @nombre,
			Descripcion = @Descripcion,
			Estado = @Estado,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdCatIngreso = @IdCatIngreso
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetIngresosVarios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdSetIngresosVarios]
(
	@IdCatIngreso INT,
	@IdMinisterio INT,
	@Descripcion NVARCHAR(500),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@FechaIngreso DATETIME,
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [IGLESIA].IngresosVarios (IdCatIngreso,IdMinisterio,Cantidad,Divisa,TasaCambio,Descripcion,FechaIngreso,UsuarioCreacion,FechaCreacion,Estado) 
		VALUES (@IdCatIngreso,@IdMinisterio,@Cantidad,@IdDivisa,@TasaCambio,@Descripcion,@FechaIngreso,@IdUsuario,GETDATE(),1)
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetIngresoVariosEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdSetIngresoVariosEdit]
(
	@IdCatIngreso INT,
	@IdMinisterio INT,
	@Descripcion NVARCHAR(200),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@FechaIngreso DATETIME,
	@Estado INT,
	@IdUsuario INT,
	@IdIngreVarios INT
)
AS
	BEGIN
		UPDATE [IGLESIA].IngresosVarios
		SET IdCatIngreso = @IdCatIngreso,
			IdMinisterio = @IdMinisterio,
			Cantidad = @Cantidad,
			Descripcion = @Descripcion,
			FechaIngreso = @FechaIngreso,
			Divisa = @IdDivisa,
			TasaCambio = @TasaCambio,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdIngreVarios = @IdIngreVarios
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetMiembroEdit]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [IGLESIA].[pcdSetMiembroEdit]
(
	@IdMiembro INT,
	@nombre NVARCHAR(100),
	@apellido NVARCHAR(100),
	@direccion NVARCHAR(500),
	@telefono NVARCHAR(15),
	@FechaNaci DATETIME,
	@FechaBauti DATETIME,
	@Estado INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Miembros
		SET Nombre = @nombre,
			Apellido = @apellido,
			Direccion = @direccion,
			Telefono = @telefono,
			FechaNacimiento = @FechaNaci,
			FechaBautismo = @FechaBauti,
			Estado = @Estado,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdMiembro = @IdMiembro
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetMiembros]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [IGLESIA].[pcdSetMiembros]
(
	@nombre NVARCHAR(100),
	@apellido NVARCHAR(100),
	@direccion NVARCHAR(500),
	@telefono NVARCHAR(15),
	@FechaNaci DATETIME,
	@FechaBauti DATETIME,
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [IGLESIA].Miembros(Nombre,Apellido,Direccion,Telefono,FechaNacimiento,FechaBautismo,Estado,FechaCreacion,UsuarioCreacion) 
		VALUES (@nombre,@apellido,@direccion,@telefono,@FechaNaci,@FechaBauti,1,GETDATE(),@IdUsuario)
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetMinisterios]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [IGLESIA].[pcdSetMinisterios]
(
	@IdMinisterio INT,
	@Nombre NVARCHAR(200),
	@Descripcion NVARCHAR(200),
	@Estado INT,
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO ADM.Ministerios(IdMinisterio, Nombre, Descripcion, Estado, UsuarioCreacion, FechaCreacion) VALUES(@IdMinisterio, @Nombre,@Descripcion, @Estado, @IdUsuario, GETDATE())
		INSERT INTO ADM.MinisteriosDetalle(IdMinisterio,IdUsuario, Ver, Crear, Editar, Anular, UsuarioCreacion, FechaCreacion) VALUES(@IdMinisterio, @IdUsuario, 1, 1, 1, 1,@IdUsuario, GETDATE())
	end
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetOfrenda]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [IGLESIA].[pcdSetOfrenda]
(
	@IdCategoria INT,
	@Descripcion NVARCHAR(200),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Fecha DATETIME,
	@Estado INT,
	@IdUsuario INT
)
AS
BEGIN
	INSERT INTO [IGLESIA].Ofrendas(IdCatOfrenda,Cantidad,Descripcion,Fecha,Divisa,TasaCambio,UsuarioCreacion,FechaCreacion,Estado) VALUES (@IdCategoria,@Cantidad,@Descripcion,@Fecha,@IdDivisa,@TasaCambio,@IdUsuario,GETDATE(),@Estado)
END

GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetOfrendaCat]    Script Date: 10/7/2024 02:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdSetOfrendaCat]
(
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@IdUsuario INT
)
AS
	BEGIN
		INSERT INTO [ADM].OfrendasCategoria(Nombre,Descripcion,Estado,UsuarioCreacion,FechaCreacion) 
		VALUES (@Nombre,@Descripcion,1,@IdUsuario,GETDATE())
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetOfrendaCatEdit]    Script Date: 10/7/2024 02:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[pcdSetOfrendaCatEdit]
(
	@IdCatOfrenda INT,
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@Estado INT,
	@IdUsuario INT
)
AS
	BEGIN
		UPDATE [ADM].OfrendasCategoria
		SET Nombre = @nombre,
			Descripcion = @Descripcion,
			Estado = @Estado,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdCatOfrenda = @IdCatOfrenda
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetOfrendaEdit]    Script Date: 10/7/2024 02:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [IGLESIA].[pcdSetOfrendaEdit]
(
	@IdCategoria INT,
	@Descripcion NVARCHAR(200),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Fecha DATETIME,
	@Estado INT,
	@IdUsuario INT,
	@IdOfrenda INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Ofrendas
		SET IdCatOfrenda = @IdCategoria,
			Cantidad = @Cantidad,
			Descripcion = @Descripcion,
			Fecha = @Fecha,
			Divisa = @IdDivisa,
			TasaCambio = @TasaCambio,
			UsuarioModifica = @IdUsuario,
			FechaModifica = GETDATE()
			WHERE IdOfrenda = @IdOfrenda
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetPago]    Script Date: 10/7/2024 02:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [IGLESIA].[pcdSetPago]
(
	@IdCategoria INT,
	@Descripcion NVARCHAR(200),
	@Cantidad FLOAT,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Fecha DATETIME,
	@IdUsuario INT 
	)
AS
	BEGIN
		INSERT INTO [IGLESIA].Pagos(IdCategoria,Descripcion, Cantidad,Divisa,TasaCambio,FechaPago, UsuarioCreacion, FechaCreacion, Estado) 
		VALUES (@IdCategoria,@Descripcion,@Cantidad,@IdDivisa,@TasaCambio,@Fecha,@IdUsuario,GETDATE(),1);
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[pcdSetPagoEdit]    Script Date: 10/7/2024 02:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [IGLESIA].[pcdSetPagoEdit]
(
	@IdCategoria INT,
	@Descripcion NVARCHAR(500),
	@Cantidad FLOAT,
	@Fecha DATETIME,
	@IdDivisa INT,
	@TasaCambio FLOAT,
	@Estado INT,
	@IdUsuario INT,
	@IdPago INT
)
AS
	BEGIN
		UPDATE [IGLESIA].Pagos 
		SET IdCategoria = @IdCategoria,
			Descripcion = @Descripcion,
			Cantidad = @Cantidad,
			FechaPago = @Fecha,
			Divisa = @IdDivisa,
			TasaCambio = @TasaCambio,
			Estado = @Estado,
			UsuarioModifica = @IdUsuario
			where IdPago = @IdPago
	END
GO
/****** Object:  StoredProcedure [IGLESIA].[rptListadoOfrendas]    Script Date: 10/7/2024 02:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [IGLESIA].[rptListadoOfrendas] --20240101,20240707,3,1
(
	@FechaIni NVARCHAR(8),
	@FechaFin NVARCHAR(8),
	@IdCatOfrenda INT,
	@IdDivisa INT
)
AS
	BEGIN
		SELECT 
			o.IdOfrenda, o.IdCatOfrenda, o.Cantidad,o.Descripcion, convert (date, o.Fecha) Fecha,o.Divisa,
			o.TasaCambio,o.UsuarioCreacion, o.FechaCreacion,o.UsuarioModifica, o.FechaModifica,
			c.IdCatOfrenda, c.Nombre CategoriaNombre, c.Descripcion CategoriaDescripcion,
			d.IdDivisa, d.CodDivisa CodDivisa, d.Descripcion Divisa, o.Estado
		FROM [IGLESIA].Ofrendas o
		LEFT JOIN [ADM].OfrendasCategoria c ON o.IdCatOfrenda = c.IdCatOfrenda
		LEFT JOIN [ADM].Divisas d ON o.Divisa = d.IdDivisa
		WHERE CONVERT (VARCHAR, o.Fecha, 112) >= @FechaIni and CONVERT (VARCHAR, o.Fecha, 112) <= @FechaFin AND o.IdCatOfrenda = @IdCatOfrenda
		ORDER BY o.Fecha DESC
	END
GO
