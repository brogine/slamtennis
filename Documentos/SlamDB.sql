USE [SlamDB]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paises](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON
INSERT [dbo].[Paises] ([IdPais], [Nombre], [Estado]) VALUES (1, N'Argentina', 1)
INSERT [dbo].[Paises] ([IdPais], [Nombre], [Estado]) VALUES (2, N'Chile', 1)
SET IDENTITY_INSERT [dbo].[Paises] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Dni] [int] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (11111111, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (15458655, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (32132123, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (32284788, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (33333333, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (35164709, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (55456454, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (77777777, N'', N'asd', 1)
INSERT [dbo].[Login] ([Dni], [Usuario], [Password], [Estado]) VALUES (99999999, N'', N'asd', 1)
/****** Object:  Table [dbo].[Clubes]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clubes](
	[IdClub] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Presidente] [varchar](50) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Clubes] PRIMARY KEY CLUSTERED 
(
	[IdClub] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clubes] ON
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (1, N'Neuquen Tenis Club', N'Nicolas Giovi se la come toda', 1)
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (2, N'Cipolletti Tenis Club', N'Eric Brogin', 1)
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (7, N'Plottier Tenis Club', N'Fede Comilon', 1)
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (8, N'Allen Tenis Club', N'Maxi El Pollerudo', 0)
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (9, N'Club Modificada', N'Fede basta de comer', 1)
INSERT [dbo].[Clubes] ([IdClub], [Nombre], [Presidente], [Estado]) VALUES (10, N'Cinco Saltos Tenis Club', N'Nicolas Vergara Papa', 0)
SET IDENTITY_INSERT [dbo].[Clubes] OFF
/****** Object:  Table [dbo].[Categorias]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[EdadMinima] [int] NOT NULL,
	[EdadMaxima] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [EdadMinima], [EdadMaxima], [Estado]) VALUES (1, N'Petes barbaros', 1, 100, 1)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [EdadMinima], [EdadMaxima], [Estado]) VALUES (2, N'Novatos de los buenos', 1, 15, 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
/****** Object:  Table [dbo].[Inscripciones]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripciones](
	[IdInscripciones] [int] IDENTITY(1,1) NOT NULL,
	[IdTorneo] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Inscripciones] PRIMARY KEY CLUSTERED 
(
	[IdInscripciones] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Torneos]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Torneos](
	[IdTorneo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FecInicio] [date] NOT NULL,
	[FecFin] [date] NOT NULL,
	[FecInicInsc] [date] NOT NULL,
	[FecFinInsc] [date] NOT NULL,
	[Cupo] [int] NOT NULL,
	[Sexo] [varchar](9) NOT NULL,
	[Tipo] [int] NOT NULL,
	[IdClub] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[TipoInscripcion] [bit] NOT NULL,
	[Superficie] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Torneos] PRIMARY KEY CLUSTERED 
(
	[IdTorneo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sedes]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sedes](
	[IdSede] [int] IDENTITY(1,1) NOT NULL,
	[IdClub] [int] NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Sedes] PRIMARY KEY CLUSTERED 
(
	[IdSede] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sedes] ON
INSERT [dbo].[Sedes] ([IdSede], [IdClub], [Direccion], [IdLocalidad], [Telefono], [Celular], [Email]) VALUES (1, 1, N'Av. Tal 123', 1, N'123123', N'1547025', N'asdfasdf')
INSERT [dbo].[Sedes] ([IdSede], [IdClub], [Direccion], [IdLocalidad], [Telefono], [Celular], [Email]) VALUES (2, 2, N'lala 123', 3, N'123123', N'12312', N'asdfasd@algo.com')
INSERT [dbo].[Sedes] ([IdSede], [IdClub], [Direccion], [IdLocalidad], [Telefono], [Celular], [Email]) VALUES (3, 2, N'Alem 544', 3, N'4426578', N'15564799', N'sedectro@cipotenis.com.ar')
SET IDENTITY_INSERT [dbo].[Sedes] OFF
/****** Object:  Table [dbo].[Provincias]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[IdProvincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estado] [int] NOT NULL,
	[IdPais] [int] NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[IdProvincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Provincias] ON
INSERT [dbo].[Provincias] ([IdProvincia], [Nombre], [Estado], [IdPais]) VALUES (1, N'Neuquen', 1, 1)
INSERT [dbo].[Provincias] ([IdProvincia], [Nombre], [Estado], [IdPais]) VALUES (2, N'Rio Negro', 1, 1)
INSERT [dbo].[Provincias] ([IdProvincia], [Nombre], [Estado], [IdPais]) VALUES (3, N'La Pampa', 1, 1)
INSERT [dbo].[Provincias] ([IdProvincia], [Nombre], [Estado], [IdPais]) VALUES (4, N'Buenos Aires', 1, 1)
SET IDENTITY_INSERT [dbo].[Provincias] OFF
/****** Object:  Table [dbo].[Canchas]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canchas](
	[IdCanchas] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Superficie] [int] NOT NULL,
	[IdSede] [int] NOT NULL,
	[Luz] [bit] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Canchas] PRIMARY KEY CLUSTERED 
(
	[IdCanchas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Canchas] ON
INSERT [dbo].[Canchas] ([IdCanchas], [Tipo], [Superficie], [IdSede], [Luz], [Cantidad]) VALUES (1, 0, 3, 1, 0, 1)
INSERT [dbo].[Canchas] ([IdCanchas], [Tipo], [Superficie], [IdSede], [Luz], [Cantidad]) VALUES (2, 1, 0, 1, 1, 123)
INSERT [dbo].[Canchas] ([IdCanchas], [Tipo], [Superficie], [IdSede], [Luz], [Cantidad]) VALUES (3, 0, 2, 3, 1, 6)
SET IDENTITY_INSERT [dbo].[Canchas] OFF
/****** Object:  Table [dbo].[Localidades]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidades](
	[IdLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdProvincia] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [IdProvincia], [Estado]) VALUES (1, N'Neuquen', 1, 1)
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [IdProvincia], [Estado]) VALUES (2, N'Plottier', 1, 1)
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [IdProvincia], [Estado]) VALUES (3, N'Cipolletti', 2, 1)
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [IdProvincia], [Estado]) VALUES (4, N'Santa Rosa', 3, 1)
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [IdProvincia], [Estado]) VALUES (5, N'Capital Federal', 4, 1)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
/****** Object:  Table [dbo].[Partidos]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partidos](
	[IdPartido] [int] IDENTITY(1,1) NOT NULL,
	[IdTorneo] [int] NOT NULL,
	[Resultado] [varchar](50) NOT NULL,
	[Ronda] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personas](
	[Dni] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Nacionalidad] [int] NOT NULL,
	[Sexo] [varchar](9) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Localidad] [int] NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[Tutor] [varchar](50) NULL,
	[Relacion] [varchar](50) NULL,
	[Foto] [varchar](50) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Personas] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Nacionalidad], [Sexo], [Telefono], [Celular], [Email], [Localidad], [Domicilio], [Tutor], [Relacion], [Foto]) VALUES (11111111, N'Nicolas', N'Giovi', CAST(0x9D070B00 AS Date), 1, N'Masculino', N'4474722', N'154168772', N'ngiovi@hotmail.com', 1, N'Alberdi 33', NULL, NULL, NULL)
INSERT [dbo].[Personas] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Nacionalidad], [Sexo], [Telefono], [Celular], [Email], [Localidad], [Domicilio], [Tutor], [Relacion], [Foto]) VALUES (35164709, N'Eric Damián', N'Brogin', CAST(0x39160B00 AS Date), 1, N'Masculino', N'4330333', N'154702534', N'ericbrogin@gmail.com', 1, N'Amador 546', NULL, NULL, NULL)
INSERT [dbo].[Personas] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Nacionalidad], [Sexo], [Telefono], [Celular], [Email], [Localidad], [Domicilio], [Tutor], [Relacion], [Foto]) VALUES (77777777, N'carlitos', N'brogin', CAST(0x4F140B00 AS Date), 1, N'Masculino', N'123', N'44', N'asdf@algo.com', 1, N'adsf', NULL, NULL, NULL)
INSERT [dbo].[Personas] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Nacionalidad], [Sexo], [Telefono], [Celular], [Email], [Localidad], [Domicilio], [Tutor], [Relacion], [Foto]) VALUES (99999999, N'Fede', N'Mehring', CAST(0x57140B00 AS Date), 2, N'Femenino', N'123', N'123', N'fede@lal.com', 4, N'lalala', NULL, NULL, NULL)
/****** Object:  Table [dbo].[PartidoInscripcion]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidoInscripcion](
	[IdPartido] [int] NOT NULL,
	[IdInscripcion] [int] NOT NULL,
 CONSTRAINT [PK_PartidoInscripcion] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC,
	[IdInscripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Afiliaciones]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afiliaciones](
	[Dni] [int] NOT NULL,
	[IdClub] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaAlta] [date] NULL,
	[FechaBaja] [date] NULL,
 CONSTRAINT [PK_PersonaClub] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdClub] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Afiliaciones] ([Dni], [IdClub], [Estado], [FechaAlta], [FechaBaja]) VALUES (11111111, 1, 1, CAST(0xC0340B00 AS Date), CAST(0xC0340B00 AS Date))
INSERT [dbo].[Afiliaciones] ([Dni], [IdClub], [Estado], [FechaAlta], [FechaBaja]) VALUES (35164709, 1, 1, CAST(0xC0340B00 AS Date), NULL)
INSERT [dbo].[Afiliaciones] ([Dni], [IdClub], [Estado], [FechaAlta], [FechaBaja]) VALUES (77777777, 8, 1, CAST(0xC0340B00 AS Date), NULL)
INSERT [dbo].[Afiliaciones] ([Dni], [IdClub], [Estado], [FechaAlta], [FechaBaja]) VALUES (99999999, 10, 1, CAST(0xC0340B00 AS Date), NULL)
/****** Object:  Table [dbo].[Empleados]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[Dni] [int] NOT NULL,
	[Puesto] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[Dni] [int] NOT NULL,
	[PartidosGanados] [int] NOT NULL,
	[PartidosPerdidos] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[TorneosJugados] [int] NULL,
	[TorneosCompletados] [int] NULL,
 CONSTRAINT [PK_Jugadores_1] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Jugadores] ([Dni], [PartidosGanados], [PartidosPerdidos], [IdCategoria], [Puntos], [Estado], [TorneosJugados], [TorneosCompletados]) VALUES (11111111, 0, 0, 1, 0, 1, NULL, NULL)
INSERT [dbo].[Jugadores] ([Dni], [PartidosGanados], [PartidosPerdidos], [IdCategoria], [Puntos], [Estado], [TorneosJugados], [TorneosCompletados]) VALUES (11111111, 1, 1, 2, 1, 1, 1, 1)
INSERT [dbo].[Jugadores] ([Dni], [PartidosGanados], [PartidosPerdidos], [IdCategoria], [Puntos], [Estado], [TorneosJugados], [TorneosCompletados]) VALUES (35164709, 0, 0, 1, 0, 1, NULL, NULL)
INSERT [dbo].[Jugadores] ([Dni], [PartidosGanados], [PartidosPerdidos], [IdCategoria], [Puntos], [Estado], [TorneosJugados], [TorneosCompletados]) VALUES (77777777, 0, 0, 1, 0, 1, NULL, NULL)
INSERT [dbo].[Jugadores] ([Dni], [PartidosGanados], [PartidosPerdidos], [IdCategoria], [Puntos], [Estado], [TorneosJugados], [TorneosCompletados]) VALUES (99999999, 0, 0, 1, 0, 1, NULL, NULL)
/****** Object:  Table [dbo].[InsripcionesJugador]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsripcionesJugador](
	[Dni] [int] NOT NULL,
	[IdInscripciones] [int] NOT NULL,
 CONSTRAINT [PK_InsripcionesJugador] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdInscripciones] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arbitros]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Arbitros](
	[Dni] [int] NOT NULL,
	[NumeroInscripcion] [int] NULL,
	[Badge] [varchar](50) NULL,
	[Nivel] [int] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Arbitros] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArbitroPartido]    Script Date: 09/21/2011 20:06:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArbitroPartido](
	[IdPartido] [int] NOT NULL,
	[DniArbitro] [int] NOT NULL,
 CONSTRAINT [PK_ArbitroPartido] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC,
	[DniArbitro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_PersonaClub_Clubes]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Afiliaciones]  WITH CHECK ADD  CONSTRAINT [FK_PersonaClub_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Afiliaciones] CHECK CONSTRAINT [FK_PersonaClub_Clubes]
GO
/****** Object:  ForeignKey [FK_PersonaClub_Personas]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Afiliaciones]  WITH CHECK ADD  CONSTRAINT [FK_PersonaClub_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Afiliaciones] CHECK CONSTRAINT [FK_PersonaClub_Personas]
GO
/****** Object:  ForeignKey [FK_ArbitroPartido_Arbitros]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[ArbitroPartido]  WITH CHECK ADD  CONSTRAINT [FK_ArbitroPartido_Arbitros] FOREIGN KEY([DniArbitro])
REFERENCES [dbo].[Arbitros] ([Dni])
GO
ALTER TABLE [dbo].[ArbitroPartido] CHECK CONSTRAINT [FK_ArbitroPartido_Arbitros]
GO
/****** Object:  ForeignKey [FK_ArbitroPartido_Partidos]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[ArbitroPartido]  WITH CHECK ADD  CONSTRAINT [FK_ArbitroPartido_Partidos] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[ArbitroPartido] CHECK CONSTRAINT [FK_ArbitroPartido_Partidos]
GO
/****** Object:  ForeignKey [FK_Arbitros_Personas]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Arbitros]  WITH CHECK ADD  CONSTRAINT [FK_Arbitros_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Arbitros] CHECK CONSTRAINT [FK_Arbitros_Personas]
GO
/****** Object:  ForeignKey [FK_Canchas_Sedes]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Canchas]  WITH CHECK ADD  CONSTRAINT [FK_Canchas_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Canchas] CHECK CONSTRAINT [FK_Canchas_Sedes]
GO
/****** Object:  ForeignKey [FK_Empleados_Personas]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Personas]
GO
/****** Object:  ForeignKey [FK_InsripcionesJugador_Inscripciones]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[InsripcionesJugador]  WITH CHECK ADD  CONSTRAINT [FK_InsripcionesJugador_Inscripciones] FOREIGN KEY([IdInscripciones])
REFERENCES [dbo].[Inscripciones] ([IdInscripciones])
GO
ALTER TABLE [dbo].[InsripcionesJugador] CHECK CONSTRAINT [FK_InsripcionesJugador_Inscripciones]
GO
/****** Object:  ForeignKey [FK_InsripcionesJugador_Personas]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[InsripcionesJugador]  WITH CHECK ADD  CONSTRAINT [FK_InsripcionesJugador_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[InsripcionesJugador] CHECK CONSTRAINT [FK_InsripcionesJugador_Personas]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Categorias]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_JugadorCategoria_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_JugadorCategoria_Categorias]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Personas]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_JugadorCategoria_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_JugadorCategoria_Personas]
GO
/****** Object:  ForeignKey [FK_Localidades_Provincias]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
/****** Object:  ForeignKey [FK_PartidoInscripcion_Inscripciones]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[PartidoInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PartidoInscripcion_Inscripciones] FOREIGN KEY([IdInscripcion])
REFERENCES [dbo].[Inscripciones] ([IdInscripciones])
GO
ALTER TABLE [dbo].[PartidoInscripcion] CHECK CONSTRAINT [FK_PartidoInscripcion_Inscripciones]
GO
/****** Object:  ForeignKey [FK_PartidoInscripcion_Partidos]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[PartidoInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PartidoInscripcion_Partidos] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[PartidoInscripcion] CHECK CONSTRAINT [FK_PartidoInscripcion_Partidos]
GO
/****** Object:  ForeignKey [FK_Partidos_Torneos]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Torneos] FOREIGN KEY([IdTorneo])
REFERENCES [dbo].[Torneos] ([IdTorneo])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Torneos]
GO
/****** Object:  ForeignKey [FK_Personas_Localidades]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Localidades] FOREIGN KEY([Localidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Localidades]
GO
/****** Object:  ForeignKey [FK_Personas_Login]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Personas]  WITH NOCHECK ADD  CONSTRAINT [FK_Personas_Login] FOREIGN KEY([Dni])
REFERENCES [dbo].[Login] ([Dni])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Personas] NOCHECK CONSTRAINT [FK_Personas_Login]
GO
/****** Object:  ForeignKey [FK_Provincias_Paises]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD  CONSTRAINT [FK_Provincias_Paises] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Paises] ([IdPais])
GO
ALTER TABLE [dbo].[Provincias] CHECK CONSTRAINT [FK_Provincias_Paises]
GO
/****** Object:  ForeignKey [FK_Sedes_Clubes]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Sedes]  WITH CHECK ADD  CONSTRAINT [FK_Sedes_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Sedes] CHECK CONSTRAINT [FK_Sedes_Clubes]
GO
/****** Object:  ForeignKey [FK_Torneos_Categorias]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Torneos]  WITH CHECK ADD  CONSTRAINT [FK_Torneos_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Torneos] CHECK CONSTRAINT [FK_Torneos_Categorias]
GO
/****** Object:  ForeignKey [FK_Torneos_Clubes]    Script Date: 09/21/2011 20:06:32 ******/
ALTER TABLE [dbo].[Torneos]  WITH CHECK ADD  CONSTRAINT [FK_Torneos_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Torneos] CHECK CONSTRAINT [FK_Torneos_Clubes]
GO
