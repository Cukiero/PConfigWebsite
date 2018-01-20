
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/22/2017 23:50:43
-- Generated from EDMX file: C:\Users\Danalscy\source\repos\ConsoleApp1\ConsoleApp1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PCCPU]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_PCCPU];
GO
IF OBJECT_ID(N'[dbo].[FK_MOBOPC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_MOBOPC];
GO
IF OBJECT_ID(N'[dbo].[FK_CasePC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_CasePC];
GO
IF OBJECT_ID(N'[dbo].[FK_PSUPC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_PSUPC];
GO
IF OBJECT_ID(N'[dbo].[FK_PCRAM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_PCRAM];
GO
IF OBJECT_ID(N'[dbo].[FK_PCGPU]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_PCGPU];
GO
IF OBJECT_ID(N'[dbo].[FK_PC_StorageStorage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PC_Storage] DROP CONSTRAINT [FK_PC_StorageStorage];
GO
IF OBJECT_ID(N'[dbo].[FK_PC_StoragePC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PC_Storage] DROP CONSTRAINT [FK_PC_StoragePC];
GO
IF OBJECT_ID(N'[dbo].[FK_PCCooler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PCs] DROP CONSTRAINT [FK_PCCooler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PCs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PCs];
GO
IF OBJECT_ID(N'[dbo].[CPUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CPUs];
GO
IF OBJECT_ID(N'[dbo].[MOBOes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MOBOes];
GO
IF OBJECT_ID(N'[dbo].[GPUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GPUs];
GO
IF OBJECT_ID(N'[dbo].[PSUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PSUs];
GO
IF OBJECT_ID(N'[dbo].[Cases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cases];
GO
IF OBJECT_ID(N'[dbo].[RAMs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RAMs];
GO
IF OBJECT_ID(N'[dbo].[Storages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Storages];
GO
IF OBJECT_ID(N'[dbo].[PC_Storage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PC_Storage];
GO
IF OBJECT_ID(N'[dbo].[Coolers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coolers];
GO
