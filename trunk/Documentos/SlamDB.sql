USE [SlamDB]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Paises]    Script Date: 08/24/2011 20:33:30 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 08/24/2011 20:33:30 ******/
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
/****** Object:  Table [dbo].[Tipos]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos](
	[IdTipo] [int] NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 08/24/2011 20:33:30 ******/
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
SET IDENTITY_INSERT [dbo].[Provincias] OFF
/****** Object:  Table [dbo].[Localidades]    Script Date: 08/24/2011 20:33:30 ******/
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
SET IDENTITY_INSERT [dbo].[Localidades] OFF
/****** Object:  Table [dbo].[Personas]    Script Date: 08/24/2011 20:33:30 ******/
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
	[Sexo] [varchar](8) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Localidad] [int] NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[DniTutor] [varchar](15) NULL,
	[Relacion] [varchar](50) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JugadorCategoria]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadorCategoria](
	[Dni] [int] NOT NULL,
	[PartidosJugados] [int] NOT NULL,
	[PartidosGanados] [int] NOT NULL,
	[PartidosPerdidos] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clubes]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clubes](
	[IdClub] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DniPresidente] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Clubes] PRIMARY KEY CLUSTERED 
(
	[IdClub] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonaTipo]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonaTipo](
	[IdTipo] [int] NOT NULL,
	[Dni] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_PersonaTipo] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC,
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonaClub]    Script Date: 08/24/2011 20:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonaClub](
	[Dni] [int] NOT NULL,
	[IdClub] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_PersonaClub] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdClub] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Clubes_Personas]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[Clubes]  WITH CHECK ADD  CONSTRAINT [FK_Clubes_Personas] FOREIGN KEY([DniPresidente])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Clubes] CHECK CONSTRAINT [FK_Clubes_Personas]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Categorias]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[JugadorCategoria]  WITH CHECK ADD  CONSTRAINT [FK_JugadorCategoria_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[JugadorCategoria] CHECK CONSTRAINT [FK_JugadorCategoria_Categorias]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Personas]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[JugadorCategoria]  WITH CHECK ADD  CONSTRAINT [FK_JugadorCategoria_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[JugadorCategoria] CHECK CONSTRAINT [FK_JugadorCategoria_Personas]
GO
/****** Object:  ForeignKey [FK_Localidades_Provincias]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
/****** Object:  ForeignKey [FK_PersonaClub_Clubes]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[PersonaClub]  WITH CHECK ADD  CONSTRAINT [FK_PersonaClub_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[PersonaClub] CHECK CONSTRAINT [FK_PersonaClub_Clubes]
GO
/****** Object:  ForeignKey [FK_PersonaClub_Personas]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[PersonaClub]  WITH CHECK ADD  CONSTRAINT [FK_PersonaClub_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[PersonaClub] CHECK CONSTRAINT [FK_PersonaClub_Personas]
GO
/****** Object:  ForeignKey [FK_Personas_Localidades]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Localidades] FOREIGN KEY([Localidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Localidades]
GO
/****** Object:  ForeignKey [FK_Personas_Login]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Login] FOREIGN KEY([Dni])
REFERENCES [dbo].[Login] ([Dni])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Login]
GO
/****** Object:  ForeignKey [FK_PersonaTipo_Personas]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[PersonaTipo]  WITH CHECK ADD  CONSTRAINT [FK_PersonaTipo_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[PersonaTipo] CHECK CONSTRAINT [FK_PersonaTipo_Personas]
GO
/****** Object:  ForeignKey [FK_PersonaTipo_Tipos]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[PersonaTipo]  WITH CHECK ADD  CONSTRAINT [FK_PersonaTipo_Tipos] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[Tipos] ([IdTipo])
GO
ALTER TABLE [dbo].[PersonaTipo] CHECK CONSTRAINT [FK_PersonaTipo_Tipos]
GO
/****** Object:  ForeignKey [FK_Provincias_Paises]    Script Date: 08/24/2011 20:33:30 ******/
ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD  CONSTRAINT [FK_Provincias_Paises] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Paises] ([IdPais])
GO
ALTER TABLE [dbo].[Provincias] CHECK CONSTRAINT [FK_Provincias_Paises]
GO
