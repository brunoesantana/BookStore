USE [master]
GO
/****** Object:  Database [bookstore]    Script Date: 27/09/2019 02:46:02 ******/
CREATE DATABASE [bookstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bokstore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bokstore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bokstore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bokstore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bookstore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bookstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bookstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bookstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bookstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bookstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bookstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [bookstore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bookstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bookstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bookstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bookstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bookstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bookstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bookstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bookstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bookstore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bookstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bookstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bookstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bookstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bookstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bookstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bookstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bookstore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bookstore] SET  MULTI_USER 
GO
ALTER DATABASE [bookstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bookstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bookstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bookstore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bookstore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bookstore] SET QUERY_STORE = OFF
GO
USE [bookstore]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 27/09/2019 02:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[Author] [varchar](100) NOT NULL,
	[UrlImage] [varchar](400) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Version] [int] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/09/2019 02:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Version] [int] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Book] ([Title], [Description], [Author], [UrlImage], [Id], [Date], [Version], [Active]) VALUES (N'Livro 1', N'Descrição livro 1 editado', N'Bruno Santana', N'https://awebic.com/wp-content/uploads/2017/04/a-menina-que-roubava-livros-markus-zusak.jpg', N'e53240c5-fefd-4ca1-37d1-08d742feb917', CAST(N'2019-09-27T00:58:58.120' AS DateTime), 3, 1)
INSERT [dbo].[Book] ([Title], [Description], [Author], [UrlImage], [Id], [Date], [Version], [Active]) VALUES (N'Livro Teste 1', N'Descrição Teste 1', N'Bruno Santana 1', N'https://awebic.com/wp-content/uploads/2017/04/a-menina-que-roubava-livros-markus-zusak.jpg', N'ba74f057-4555-439c-860f-08d74308323d', CAST(N'2019-09-27T02:04:32.990' AS DateTime), 1, 1)
INSERT [dbo].[Book] ([Title], [Description], [Author], [UrlImage], [Id], [Date], [Version], [Active]) VALUES (N'Livro Teste 2', N'Descrição Teste 2', N'Bruno Santana 2', N'https://awebic.com/wp-content/uploads/2017/04/a-menina-que-roubava-livros-markus-zusak.jpg', N'2ddcf8d7-3f3c-4a00-0f93-08d743089284', CAST(N'2019-09-27T02:07:18.510' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'bruno', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'02a2ce0e-5a67-452e-1448-08d743009e92', CAST(N'2019-09-27T01:10:23.533' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'usuario14494', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'8cf60b1c-09ce-4613-48a8-08d7430abcb3', CAST(N'2019-09-27T02:22:49.027' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'usuario29229', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'85c5159b-bd69-499b-1f44-08d7430bd39b', CAST(N'2019-09-27T02:30:36.967' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'usuario69649', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'fb8285d2-b527-4850-aa43-08d7430c270e', CAST(N'2019-09-27T02:32:56.970' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'usuario66376', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'5ed8b14c-d552-426a-3a96-08d7430ca4ad', CAST(N'2019-09-27T02:36:27.720' AS DateTime), 1, 1)
INSERT [dbo].[User] ([UserName], [Password], [Id], [Date], [Version], [Active]) VALUES (N'usuario71143', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', N'2f05ef3c-acbd-4c78-a481-08d7430c6675', CAST(N'2019-09-27T02:34:43.333' AS DateTime), 1, 1)
USE [master]
GO
ALTER DATABASE [bookstore] SET  READ_WRITE 
GO
