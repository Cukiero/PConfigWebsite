
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
IF OBJECT_ID(N'[dbo].[FK_UserPC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserPC];
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
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
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

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PCs'
CREATE TABLE [dbo].[PCs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CPUId] int  NOT NULL,
    [MOBOId] int  NOT NULL,
    [CaseId] int  NOT NULL,
    [PSUId] int  NOT NULL,
    [RAMId] int  NOT NULL,
    [GPUId] int  NULL,
    [CoolerId] int  NOT NULL
);
GO

-- Creating table 'CPUs'
CREATE TABLE [dbo].[CPUs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Series] nvarchar(max)  NOT NULL,
    [Socket] nvarchar(max)  NOT NULL,
    [Cores] nvarchar(max)  NOT NULL,
    [TDP] nvarchar(max)  NOT NULL,
    [iGPU] tinyint  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MOBOes'
CREATE TABLE [dbo].[MOBOes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Standard] nvarchar(max)  NOT NULL,
    [Chipset] nvarchar(max)  NOT NULL,
    [Socket] nvarchar(max)  NOT NULL,
    [Ram_type] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GPUs'
CREATE TABLE [dbo].[GPUs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Chipset] nvarchar(max)  NOT NULL,
    [TDP] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PSUs'
CREATE TABLE [dbo].[PSUs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Wattage] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cases'
CREATE TABLE [dbo].[Cases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RAMs'
CREATE TABLE [dbo].[RAMs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Ram_type] nvarchar(max)  NOT NULL,
    [Speed] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password_hash] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Storages'
CREATE TABLE [dbo].[Storages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Manufacturer] nvarchar(max)  NOT NULL,
    [Size] nvarchar(max)  NOT NULL,
    [is_SSD] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PC_Storage'
CREATE TABLE [dbo].[PC_Storage] (
    [PCId] int  NOT NULL,
    [StorageId] int  NOT NULL
);
GO

-- Creating table 'Coolers'
CREATE TABLE [dbo].[Coolers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Socket] nvarchar(max)  NOT NULL,
    [Fans] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [PK_PCs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CPUs'
ALTER TABLE [dbo].[CPUs]
ADD CONSTRAINT [PK_CPUs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MOBOes'
ALTER TABLE [dbo].[MOBOes]
ADD CONSTRAINT [PK_MOBOes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GPUs'
ALTER TABLE [dbo].[GPUs]
ADD CONSTRAINT [PK_GPUs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PSUs'
ALTER TABLE [dbo].[PSUs]
ADD CONSTRAINT [PK_PSUs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cases'
ALTER TABLE [dbo].[Cases]
ADD CONSTRAINT [PK_Cases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RAMs'
ALTER TABLE [dbo].[RAMs]
ADD CONSTRAINT [PK_RAMs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Storages'
ALTER TABLE [dbo].[Storages]
ADD CONSTRAINT [PK_Storages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StorageId], [PCId] in table 'PC_Storage'
ALTER TABLE [dbo].[PC_Storage]
ADD CONSTRAINT [PK_PC_Storage]
    PRIMARY KEY CLUSTERED ([StorageId], [PCId] ASC);
GO

-- Creating primary key on [Id] in table 'Coolers'
ALTER TABLE [dbo].[Coolers]
ADD CONSTRAINT [PK_Coolers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CPUId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_PCCPU]
    FOREIGN KEY ([CPUId])
    REFERENCES [dbo].[CPUs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PCCPU'
CREATE INDEX [IX_FK_PCCPU]
ON [dbo].[PCs]
    ([CPUId]);
GO

-- Creating foreign key on [MOBOId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_MOBOPC]
    FOREIGN KEY ([MOBOId])
    REFERENCES [dbo].[MOBOes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MOBOPC'
CREATE INDEX [IX_FK_MOBOPC]
ON [dbo].[PCs]
    ([MOBOId]);
GO

-- Creating foreign key on [CaseId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_CasePC]
    FOREIGN KEY ([CaseId])
    REFERENCES [dbo].[Cases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CasePC'
CREATE INDEX [IX_FK_CasePC]
ON [dbo].[PCs]
    ([CaseId]);
GO

-- Creating foreign key on [PSUId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_PSUPC]
    FOREIGN KEY ([PSUId])
    REFERENCES [dbo].[PSUs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PSUPC'
CREATE INDEX [IX_FK_PSUPC]
ON [dbo].[PCs]
    ([PSUId]);
GO

-- Creating foreign key on [RAMId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_PCRAM]
    FOREIGN KEY ([RAMId])
    REFERENCES [dbo].[RAMs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PCRAM'
CREATE INDEX [IX_FK_PCRAM]
ON [dbo].[PCs]
    ([RAMId]);
GO

-- Creating foreign key on [GPUId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_PCGPU]
    FOREIGN KEY ([GPUId])
    REFERENCES [dbo].[GPUs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PCGPU'
CREATE INDEX [IX_FK_PCGPU]
ON [dbo].[PCs]
    ([GPUId]);
GO

-- Creating foreign key on [StorageId] in table 'PC_Storage'
ALTER TABLE [dbo].[PC_Storage]
ADD CONSTRAINT [FK_PC_StorageStorage]
    FOREIGN KEY ([StorageId])
    REFERENCES [dbo].[Storages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PCId] in table 'PC_Storage'
ALTER TABLE [dbo].[PC_Storage]
ADD CONSTRAINT [FK_PC_StoragePC]
    FOREIGN KEY ([PCId])
    REFERENCES [dbo].[PCs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PC_StoragePC'
CREATE INDEX [IX_FK_PC_StoragePC]
ON [dbo].[PC_Storage]
    ([PCId]);
GO

-- Creating foreign key on [CoolerId] in table 'PCs'
ALTER TABLE [dbo].[PCs]
ADD CONSTRAINT [FK_PCCooler]
    FOREIGN KEY ([CoolerId])
    REFERENCES [dbo].[Coolers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PCCooler'
CREATE INDEX [IX_FK_PCCooler]
ON [dbo].[PCs]
    ([CoolerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------