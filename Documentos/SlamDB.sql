USE [SlamDB]
GO
/****** Object:  Table [dbo].[Inscripciones]    Script Date: 10/07/2011 21:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripciones](
	[IdInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[IdTorneo] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_Inscripciones] PRIMARY KEY CLUSTERED 
(
	[IdInscripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[LimpiarBase]    Script Date: 10/07/2011 21:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brogin Eric, Nicolas Giovi
-- Create date: 07/10/2011
-- Description:	Limpia todos los datos de todas las tablas
-- =============================================
CREATE PROCEDURE [dbo].[LimpiarBase]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TABLE_NAME
	INTO #TEMP_TABLE
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_TYPE = 'BASE TABLE'
	AND TABLE_CATALOG='SlamDB'
	DECLARE @NombreTabla NVARCHAR(30)
	WHILE (SELECT Count(*) FROM #TEMP_TABLE) > 0
	BEGIN
	SELECT TOP 1 @NombreTabla = TABLE_NAME FROM #TEMP_TABLE
	EXEC ('DELETE ' + @NombreTabla)
	DELETE #TEMP_TABLE WHERE TABLE_NAME = @NombreTabla
	END
	PRINT 'Proceso de borrado completado…';
	DROP TABLE #TEMP_TABLE
END
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Clubes]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  StoredProcedure [dbo].[ReestablecerIndices]    Script Date: 10/07/2011 21:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brogin Eric
-- Create date: 07/10/2011
-- Description:	Reestablecer Indices BDD
-- =============================================
CREATE PROCEDURE [dbo].[ReestablecerIndices]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    SET QUOTED_IDENTIFIER ON  
      
    DECLARE @Table VARCHAR(255)   
    DECLARE @DataBase VARCHAR(255) = 'SlamDB'
    DECLARE @cmd NVARCHAR(500)   
    DECLARE @fillfactor INT  
      
    SET @fillfactor = 90  
      
    OPEN DatabaseCursor   
      
    FETCH NEXT FROM DatabaseCursor INTO @Database   
    WHILE @@FETCH_STATUS = 0   
    BEGIN   
      
       SET @cmd = 'DECLARE TableCursor CURSOR FOR SELECT table_catalog + ''.'' + table_schema + ''.'' + table_name as tableName    
                        FROM ' + @Database + '.INFORMATION_SCHEMA.TABLES WHERE table_type = ''BASE TABLE'''    
      
       -- create table cursor   
       EXEC (@cmd)   
       OPEN TableCursor    
      
       FETCH NEXT FROM TableCursor INTO @Table    
       WHILE @@FETCH_STATUS = 0    
       BEGIN    
      
           -- SQL 2000 command   
           --DBCC DBREINDEX(@Table,' ',@fillfactor)    
              
           -- SQL 2005 command   
           SET @cmd = 'ALTER INDEX ALL ON ' + @Table + ' REBUILD WITH (FILLFACTOR = ' + CONVERT(VARCHAR(3),@fillfactor) + ')'   
           EXEC (@cmd)   
      
           FETCH NEXT FROM TableCursor INTO @Table    
       END    
      
       PRINT @Database + ' indexes were rebuilt'  
      
       CLOSE TableCursor    
       DEALLOCATE TableCursor   
      
       FETCH NEXT FROM DatabaseCursor INTO @Database   
    END   
    CLOSE DatabaseCursor    
    DEALLOCATE DatabaseCursor  

END
GO
/****** Object:  StoredProcedure [dbo].[ReducirLog]    Script Date: 10/07/2011 21:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brogin Eric
-- Create date: 07/10/2011
-- Description:	Reducir Log de Transacciones
-- =============================================
CREATE PROCEDURE [dbo].[ReducirLog]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    DECLARE @dbName AS VARCHAR(100)  = 'SlamDB'
    DECLARE @cmd AS VARCHAR(MAX)  

    OPEN c1  
      
    FETCH NEXT FROM c1  
    INTO @dbName  
      
    WHILE @@FETCH_STATUS = 0  
    BEGIN  
        --Establecer la base de datos en uso  
        SET @cmd = 'USE ' + @dbName  
      
        --Si se establece el modo de restauración a simple, las partes inactivas del log de transacción deben ser borradas  
        --Este comando reducirá el archivo de log un poco  
        SET @cmd = @cmd + ' ALTER DATABASE ' + @dbName + ' SET RECOVERY SIMPLE'  
      
        --Obtener el nombre de log de la base de datos  
        SET @cmd = @cmd + ' DECLARE @logFile AS NVARCHAR(1000)'  
        SET @cmd = @cmd + ' SELECT @logFile = name FROM ' + @dbName + '.sys.database_files WHERE type_desc = ''LOG'''  
        --Cambiar el modo de restauración a Simple no es suficiente, esto reduce el log a 1 MB  
        SET @cmd = @cmd + ' DBCC SHRINKFILE (@logFile , 1)'  
      
        EXEC(@cmd)  
      
        FETCH NEXT FROM c1  
        INTO @dbName  
    END  
      
    CLOSE c1  
    DEALLOCATE c1  

END
GO
/****** Object:  StoredProcedure [dbo].[RealizarBackUp]    Script Date: 10/07/2011 21:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brogin Eric
-- Create date: 07/10/2011
-- Description:	Crea un BackUp de la Base de datos en C:\BackUpSlam\
-- =============================================
CREATE PROCEDURE [dbo].[RealizarBackUp]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @backupPath AS VARCHAR(MAX)  
    SET @backupPath = N'C:\BackUpSlam\'  
      
    DECLARE @dbName AS VARCHAR(10) = 'SlamDB'
    DECLARE @file AS VARCHAR(MAX)  
      
    OPEN c1  
      
    FETCH NEXT FROM c1  
    INTO @dbName  
      
    WHILE @@FETCH_STATUS = 0  
    BEGIN  
        SET @file = @backupPath + @dbName + '.BAK'  
      
        BACKUP DATABASE @dbName  
        TO  DISK = @file WITH NOFORMAT, INIT,  NAME = @dbName, SKIP, NOREWIND, NOUNLOAD,  STATS = 10  
      
        FETCH NEXT FROM c1  
        INTO @dbName  
    END  
      
    CLOSE c1  
    DEALLOCATE c1  

END
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Torneos]    Script Date: 10/07/2011 21:33:09 ******/
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
	[FecFin] [date] NULL,
	[FecInicInsc] [date] NOT NULL,
	[FecFinInsc] [date] NULL,
	[Cupo] [int] NULL,
	[Sexo] [varchar](9) NOT NULL,
	[Tipo] [int] NOT NULL,
	[IdClub] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[TipoInscripcion] [bit] NOT NULL,
	[Superficie] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Torneos] PRIMARY KEY CLUSTERED 
(
	[IdTorneo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sedes]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Canchas]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Localidades]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Partidos]    Script Date: 10/07/2011 21:33:09 ******/
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
	[Fecha] [datetime] NOT NULL,
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
/****** Object:  Table [dbo].[PartidoInscripcion]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Personas]    Script Date: 10/07/2011 21:33:09 ******/
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
	[Foto] [image] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Afiliaciones]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Jugadores]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[InscripcionesJugador]    Script Date: 10/07/2011 21:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InscripcionesJugador](
	[Dni] [int] NOT NULL,
	[IdInscripcion] [int] NOT NULL,
 CONSTRAINT [PK_InsripcionesJugador] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC,
	[IdInscripcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[Arbitros]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  Table [dbo].[ArbitroPartido]    Script Date: 10/07/2011 21:33:09 ******/
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
/****** Object:  ForeignKey [FK_PersonaClub_Clubes]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Afiliaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonaClub_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Afiliaciones] CHECK CONSTRAINT [FK_PersonaClub_Clubes]
GO
/****** Object:  ForeignKey [FK_PersonaClub_Personas]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Afiliaciones]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonaClub_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Afiliaciones] CHECK CONSTRAINT [FK_PersonaClub_Personas]
GO
/****** Object:  ForeignKey [FK_ArbitroPartido_Arbitros]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[ArbitroPartido]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroPartido_Arbitros] FOREIGN KEY([DniArbitro])
REFERENCES [dbo].[Arbitros] ([Dni])
GO
ALTER TABLE [dbo].[ArbitroPartido] CHECK CONSTRAINT [FK_ArbitroPartido_Arbitros]
GO
/****** Object:  ForeignKey [FK_ArbitroPartido_Partidos]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[ArbitroPartido]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroPartido_Partidos] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[ArbitroPartido] CHECK CONSTRAINT [FK_ArbitroPartido_Partidos]
GO
/****** Object:  ForeignKey [FK_Arbitros_Personas]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Arbitros]  WITH NOCHECK ADD  CONSTRAINT [FK_Arbitros_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Arbitros] CHECK CONSTRAINT [FK_Arbitros_Personas]
GO
/****** Object:  ForeignKey [FK_Canchas_Sedes]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Canchas]  WITH NOCHECK ADD  CONSTRAINT [FK_Canchas_Sedes] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sedes] ([IdSede])
GO
ALTER TABLE [dbo].[Canchas] CHECK CONSTRAINT [FK_Canchas_Sedes]
GO
/****** Object:  ForeignKey [FK_Empleados_Personas]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Empleados]  WITH NOCHECK ADD  CONSTRAINT [FK_Empleados_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Personas]
GO
/****** Object:  ForeignKey [FK_InsripcionesJugador_Personas]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[InscripcionesJugador]  WITH NOCHECK ADD  CONSTRAINT [FK_InsripcionesJugador_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[InscripcionesJugador] CHECK CONSTRAINT [FK_InsripcionesJugador_Personas]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Categorias]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Jugadores]  WITH NOCHECK ADD  CONSTRAINT [FK_JugadorCategoria_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_JugadorCategoria_Categorias]
GO
/****** Object:  ForeignKey [FK_JugadorCategoria_Personas]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Jugadores]  WITH NOCHECK ADD  CONSTRAINT [FK_JugadorCategoria_Personas] FOREIGN KEY([Dni])
REFERENCES [dbo].[Personas] ([Dni])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_JugadorCategoria_Personas]
GO
/****** Object:  ForeignKey [FK_Localidades_Provincias]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Localidades]  WITH NOCHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
/****** Object:  ForeignKey [FK_PartidoInscripcion_Inscripciones]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[PartidoInscripcion]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoInscripcion_Inscripciones] FOREIGN KEY([IdInscripcion])
REFERENCES [dbo].[Inscripciones] ([IdInscripcion])
GO
ALTER TABLE [dbo].[PartidoInscripcion] CHECK CONSTRAINT [FK_PartidoInscripcion_Inscripciones]
GO
/****** Object:  ForeignKey [FK_PartidoInscripcion_Partidos]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[PartidoInscripcion]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoInscripcion_Partidos] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partidos] ([IdPartido])
GO
ALTER TABLE [dbo].[PartidoInscripcion] CHECK CONSTRAINT [FK_PartidoInscripcion_Partidos]
GO
/****** Object:  ForeignKey [FK_Partidos_Torneos]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Partidos]  WITH NOCHECK ADD  CONSTRAINT [FK_Partidos_Torneos] FOREIGN KEY([IdTorneo])
REFERENCES [dbo].[Torneos] ([IdTorneo])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Torneos]
GO
/****** Object:  ForeignKey [FK_Personas_Localidades]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Personas]  WITH NOCHECK ADD  CONSTRAINT [FK_Personas_Localidades] FOREIGN KEY([Localidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Localidades]
GO
/****** Object:  ForeignKey [FK_Personas_Login]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Personas]  WITH NOCHECK ADD  CONSTRAINT [FK_Personas_Login] FOREIGN KEY([Dni])
REFERENCES [dbo].[Login] ([Dni])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Login]
GO
/****** Object:  ForeignKey [FK_Provincias_Paises]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Provincias]  WITH NOCHECK ADD  CONSTRAINT [FK_Provincias_Paises] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Paises] ([IdPais])
GO
ALTER TABLE [dbo].[Provincias] CHECK CONSTRAINT [FK_Provincias_Paises]
GO
/****** Object:  ForeignKey [FK_Sedes_Clubes]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Sedes]  WITH NOCHECK ADD  CONSTRAINT [FK_Sedes_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Sedes] CHECK CONSTRAINT [FK_Sedes_Clubes]
GO
/****** Object:  ForeignKey [FK_Torneos_Categorias]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Torneos]  WITH NOCHECK ADD  CONSTRAINT [FK_Torneos_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Torneos] CHECK CONSTRAINT [FK_Torneos_Categorias]
GO
/****** Object:  ForeignKey [FK_Torneos_Clubes]    Script Date: 10/07/2011 21:33:09 ******/
ALTER TABLE [dbo].[Torneos]  WITH NOCHECK ADD  CONSTRAINT [FK_Torneos_Clubes] FOREIGN KEY([IdClub])
REFERENCES [dbo].[Clubes] ([IdClub])
GO
ALTER TABLE [dbo].[Torneos] CHECK CONSTRAINT [FK_Torneos_Clubes]
GO
