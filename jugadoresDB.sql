USE [master]
GO
/****** Object:  Database [JugadoresTruco]    Script Date: 25/11/2022 16:24:59 ******/
CREATE DATABASE [JugadoresTruco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JugadoresTruco', FILENAME = N'E:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\JugadoresTruco.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JugadoresTruco_log', FILENAME = N'E:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\JugadoresTruco_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JugadoresTruco] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JugadoresTruco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JugadoresTruco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JugadoresTruco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JugadoresTruco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JugadoresTruco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JugadoresTruco] SET ARITHABORT OFF 
GO
ALTER DATABASE [JugadoresTruco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JugadoresTruco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JugadoresTruco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JugadoresTruco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JugadoresTruco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JugadoresTruco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JugadoresTruco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JugadoresTruco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JugadoresTruco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JugadoresTruco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JugadoresTruco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JugadoresTruco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JugadoresTruco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JugadoresTruco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JugadoresTruco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JugadoresTruco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JugadoresTruco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JugadoresTruco] SET RECOVERY FULL 
GO
ALTER DATABASE [JugadoresTruco] SET  MULTI_USER 
GO
ALTER DATABASE [JugadoresTruco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JugadoresTruco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JugadoresTruco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JugadoresTruco] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JugadoresTruco] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JugadoresTruco] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JugadoresTruco', N'ON'
GO
ALTER DATABASE [JugadoresTruco] SET QUERY_STORE = OFF
GO
USE [JugadoresTruco]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 25/11/2022 16:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Victorias] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JugadoresTruco]    Script Date: 25/11/2022 16:25:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JugadoresTruco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[victorias] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (1, N'Mauro', 21)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (2, N'Lucas', 1)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (3, N'Gladys', 9)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (4, N'Ulises', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (5, N'Marcos', 3)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (6, N'Franco', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (7, N'Nahuel', 1)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (8, N'Sofia', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (9, N'Aylen', 1)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (10, N'Micaela', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (11, N'Jennifer', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (12, N'Elon', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (13, N'Jeff', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (14, N'Bill', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (15, N'Goku', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (16, N'Messi', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (17, N'Paredes', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (18, N'Dibu', 0)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (19, N'Lukaku', 9)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Victorias]) VALUES (20, N'Hazard', 0)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[JugadoresTruco] ON 

INSERT [dbo].[JugadoresTruco] ([id], [nombre], [victorias]) VALUES (1, N'Rojo', 20)
INSERT [dbo].[JugadoresTruco] ([id], [nombre], [victorias]) VALUES (2, N'Azul', 0)
SET IDENTITY_INSERT [dbo].[JugadoresTruco] OFF
GO
USE [master]
GO
ALTER DATABASE [JugadoresTruco] SET  READ_WRITE 
GO
