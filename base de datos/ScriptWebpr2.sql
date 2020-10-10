USE [master]
GO
/****** Object:  Database [webpr2]    Script Date: 10/10/2020 06:22:12 ******/
CREATE DATABASE [webpr2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webpr2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\webpr2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webpr2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\webpr2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [webpr2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webpr2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webpr2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webpr2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webpr2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webpr2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webpr2] SET ARITHABORT OFF 
GO
ALTER DATABASE [webpr2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [webpr2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webpr2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webpr2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webpr2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webpr2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webpr2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webpr2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webpr2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webpr2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [webpr2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webpr2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webpr2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webpr2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webpr2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webpr2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webpr2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webpr2] SET RECOVERY FULL 
GO
ALTER DATABASE [webpr2] SET  MULTI_USER 
GO
ALTER DATABASE [webpr2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webpr2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webpr2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webpr2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webpr2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'webpr2', N'ON'
GO
ALTER DATABASE [webpr2] SET QUERY_STORE = OFF
GO
USE [webpr2]
GO
/****** Object:  Table [dbo].[asignacion]    Script Date: 10/10/2020 06:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignacion](
	[id_curso] [int] NOT NULL,
	[cod_persona] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_persona] ASC,
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[curso]    Script Date: 10/10/2020 06:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[curso](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 10/10/2020 06:22:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[cod_persona] [varchar](50) NOT NULL,
	[nombre1] [varchar](50) NULL,
	[nombre2] [varchar](50) NULL,
	[apellido1] [varchar](50) NULL,
	[apellido2] [varchar](50) NULL,
	[fechan] [date] NULL,
	[tipo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[asignacion] ([id_curso], [cod_persona]) VALUES (6, N'15')
GO
INSERT [dbo].[asignacion] ([id_curso], [cod_persona]) VALUES (4, N'555')
GO
INSERT [dbo].[asignacion] ([id_curso], [cod_persona]) VALUES (7, N'555')
GO
INSERT [dbo].[asignacion] ([id_curso], [cod_persona]) VALUES (4, N'99')
GO
INSERT [dbo].[asignacion] ([id_curso], [cod_persona]) VALUES (5, N'99')
GO
SET IDENTITY_INSERT [dbo].[curso] ON 
GO
INSERT [dbo].[curso] ([id_curso], [nombre], [descripcion]) VALUES (4, N'electronica', N'este curso es sobre circuitos logicos')
GO
INSERT [dbo].[curso] ([id_curso], [nombre], [descripcion]) VALUES (5, N'administracion', N'gagagagag')
GO
INSERT [dbo].[curso] ([id_curso], [nombre], [descripcion]) VALUES (6, N'conta', N'ggggggggg')
GO
INSERT [dbo].[curso] ([id_curso], [nombre], [descripcion]) VALUES (7, N'ingenieria', N'wwwwwwwwwww')
GO
SET IDENTITY_INSERT [dbo].[curso] OFF
GO
INSERT [dbo].[persona] ([cod_persona], [nombre1], [nombre2], [apellido1], [apellido2], [fechan], [tipo]) VALUES (N'0', N'brandon', N'gaspar', N'caba', N'mendez', CAST(N'2019-04-04' AS Date), 0)
GO
INSERT [dbo].[persona] ([cod_persona], [nombre1], [nombre2], [apellido1], [apellido2], [fechan], [tipo]) VALUES (N'15', N'israel', N'chavez', N'chavez', N'chavez', CAST(N'2014-01-01' AS Date), 1)
GO
INSERT [dbo].[persona] ([cod_persona], [nombre1], [nombre2], [apellido1], [apellido2], [fechan], [tipo]) VALUES (N'555', N'maday', N'rosa', N'caba', N'mendez', CAST(N'2019-12-31' AS Date), 0)
GO
INSERT [dbo].[persona] ([cod_persona], [nombre1], [nombre2], [apellido1], [apellido2], [fechan], [tipo]) VALUES (N'99', N'ezequiel', N'gaspar', N'sanchez', N'ijom', CAST(N'2018-01-01' AS Date), 1)
GO
ALTER TABLE [dbo].[asignacion]  WITH CHECK ADD  CONSTRAINT [fk_codCurso] FOREIGN KEY([id_curso])
REFERENCES [dbo].[curso] ([id_curso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[asignacion] CHECK CONSTRAINT [fk_codCurso]
GO
ALTER TABLE [dbo].[asignacion]  WITH CHECK ADD  CONSTRAINT [fk_codpersona] FOREIGN KEY([cod_persona])
REFERENCES [dbo].[persona] ([cod_persona])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[asignacion] CHECK CONSTRAINT [fk_codpersona]
GO
USE [master]
GO
ALTER DATABASE [webpr2] SET  READ_WRITE 
GO
