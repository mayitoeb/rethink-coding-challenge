-- Create Database
IF NOT EXISTS(SELECT * 
			  FROM sys.databases 
			  WHERE name = 'sqldb-patients')
 BEGIN
  CREATE DATABASE [sqldb-patients]
 END
GO
 
-- Create Patients Table
USE [sqldb-patients]
 
IF NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Patients')
 BEGIN
  CREATE TABLE [dbo].[Patients](
	--[Id] [char](36) NOT NULL PRIMARY KEY,
	Id UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Birthday] [datetime2] NOT NULL,
	[Gender] [char](1) NOT NULL)
 END
GO