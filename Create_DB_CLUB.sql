USE [master]
GO

/****** Object:  Database [Club]    Script Date: 09-Oct-21 3:10:25 PM ******/
CREATE DATABASE [Club]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Club', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Club.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Club_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Club_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Club].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Club] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Club] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Club] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Club] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Club] SET ARITHABORT OFF 
GO

ALTER DATABASE [Club] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Club] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Club] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Club] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Club] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Club] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Club] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Club] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Club] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Club] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Club] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Club] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Club] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Club] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Club] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Club] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Club] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Club] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Club] SET  MULTI_USER 
GO

ALTER DATABASE [Club] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Club] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Club] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Club] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Club] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Club] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Club] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Club] SET  READ_WRITE 
GO
