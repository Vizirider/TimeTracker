
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2019 19:41:27
-- Generated from EDMX file: C:\Users\rolcs\Source\Repos\BugFactory.TimeTracker\Master\DataAccessLayer\TimeTrackerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Bugfactory.TimeTracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InvoiceCurrency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_InvoiceCurrency];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoicePayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_InvoicePayment];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceProjectLinkInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceProjectLink] DROP CONSTRAINT [FK_InvoiceProjectLinkInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceProjectLinkProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceProjectLink] DROP CONSTRAINT [FK_InvoiceProjectLinkProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_ProjectClient];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_ProjectStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissionLinkPermission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissionLink] DROP CONSTRAINT [FK_RolePermissionLinkPermission];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePermissionLinkRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolePermissionLink] DROP CONSTRAINT [FK_RolePermissionLinkRole];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_TeamClient];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_TeamProject];
GO
IF OBJECT_ID(N'[dbo].[FK_TodoStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Todo] DROP CONSTRAINT [FK_TodoStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_TodoTimeRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeRecord] DROP CONSTRAINT [FK_TodoTimeRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_UserClient];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeamLinkCurrency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserTeamLink] DROP CONSTRAINT [FK_UserTeamLinkCurrency];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeamLinkInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_UserTeamLinkInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeamLinkTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserTeamLink] DROP CONSTRAINT [FK_UserTeamLinkTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTeamLinkUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserTeamLink] DROP CONSTRAINT [FK_UserTeamLinkUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Currency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currency];
GO
IF OBJECT_ID(N'[dbo].[Invoice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoice];
GO
IF OBJECT_ID(N'[dbo].[InvoiceProjectLink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceProjectLink];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[RolePermissionLink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolePermissionLink];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team];
GO
IF OBJECT_ID(N'[dbo].[TimeRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeRecord];
GO
IF OBJECT_ID(N'[dbo].[Todo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Todo];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserTeamLink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserTeamLink];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Payment'
CREATE TABLE [dbo].[Payment] (
    [InvoiceId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
	[Token] nvarchar(max) NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RoleId] bigint  NOT NULL
);
GO

-- Creating table 'InvoiceProjectLink'
CREATE TABLE [dbo].[InvoiceProjectLink] (
    [InvoiceId] bigint  NOT NULL,
    [ProjectID] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Currency'
CREATE TABLE [dbo].[Currency] (
    [Code] nvarchar(max)  NOT NULL,
    [IsDefault] bit  NULL,
    [PriceToDefault] nvarchar(max)  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RolePermissionLink'
CREATE TABLE [dbo].[RolePermissionLink] (
    [RoleId] bigint  NOT NULL,
    [PermissionId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'UserTeamLink'
CREATE TABLE [dbo].[UserTeamLink] (
    [PublicPrice] nvarchar(max)  NOT NULL,
    [PrivatePrice] nvarchar(max)  NOT NULL,
    [CurrencyId] bigint  NOT NULL,
    [UserID] bigint  NOT NULL,
    [TeamId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Todo'
CREATE TABLE [dbo].[Todo] (
    [StatusId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] varchar(50)  NOT NULL,
    [Content] varchar(max)  NOT NULL,
    [ProjectId] bigint  NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [Name] nvarchar(max)  NOT NULL,
    [StateTypeId] tinyint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Key] nvarchar(max)  NOT NULL,
    [RoleTypeId] tinyint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Invoice'
CREATE TABLE [dbo].[Invoice] (
    [Title] nvarchar(max)  NOT NULL,
    [DeadLine] nvarchar(max)  NULL,
    [CurrencyId] bigint  NOT NULL,
    [UserTeamLinkId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Team'
CREATE TABLE [dbo].[Team] (
    [Name] nvarchar(max)  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TimeRecord'
CREATE TABLE [dbo].[TimeRecord] (
    [TodoId] bigint  NOT NULL,
    [TimeInSeconds] int  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [Key] nvarchar(max)  NOT NULL,
    [PermissionTypeId] int  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Name] nvarchar(max)  NOT NULL,
    [DeadLine] datetime  NULL,
    [EffortInHours] smallint  NULL,
    [EffortInCurrency] decimal(18,0)  NULL,
    [TeamId] bigint  NOT NULL,
    [StatusId] bigint  NOT NULL,
    [ClientId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CurrencyId] bigint  NOT NULL
);
GO

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [Website] nvarchar(max)  NULL,
    [TeamId] bigint  NOT NULL,
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [PK_Payment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoiceProjectLink'
ALTER TABLE [dbo].[InvoiceProjectLink]
ADD CONSTRAINT [PK_InvoiceProjectLink]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Currency'
ALTER TABLE [dbo].[Currency]
ADD CONSTRAINT [PK_Currency]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolePermissionLink'
ALTER TABLE [dbo].[RolePermissionLink]
ADD CONSTRAINT [PK_RolePermissionLink]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserTeamLink'
ALTER TABLE [dbo].[UserTeamLink]
ADD CONSTRAINT [PK_UserTeamLink]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Todo'
ALTER TABLE [dbo].[Todo]
ADD CONSTRAINT [PK_Todo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoice'
ALTER TABLE [dbo].[Invoice]
ADD CONSTRAINT [PK_Invoice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Team'
ALTER TABLE [dbo].[Team]
ADD CONSTRAINT [PK_Team]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeRecord'
ALTER TABLE [dbo].[TimeRecord]
ADD CONSTRAINT [PK_TimeRecord]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole'
CREATE INDEX [IX_FK_UserRole]
ON [dbo].[User]
    ([RoleId]);
GO

-- Creating foreign key on [TeamId] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_TeamProject]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamProject'
CREATE INDEX [IX_FK_TeamProject]
ON [dbo].[Project]
    ([TeamId]);
GO

-- Creating foreign key on [TeamId] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [FK_TeamClient]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamClient'
CREATE INDEX [IX_FK_TeamClient]
ON [dbo].[Client]
    ([TeamId]);
GO

-- Creating foreign key on [CurrencyId] in table 'UserTeamLink'
ALTER TABLE [dbo].[UserTeamLink]
ADD CONSTRAINT [FK_UserTeamLinkCurrency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currency]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeamLinkCurrency'
CREATE INDEX [IX_FK_UserTeamLinkCurrency]
ON [dbo].[UserTeamLink]
    ([CurrencyId]);
GO

-- Creating foreign key on [ClientId] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_ProjectClient]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectClient'
CREATE INDEX [IX_FK_ProjectClient]
ON [dbo].[Project]
    ([ClientId]);
GO

-- Creating foreign key on [CurrencyId] in table 'Invoice'
ALTER TABLE [dbo].[Invoice]
ADD CONSTRAINT [FK_InvoiceCurrency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currency]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceCurrency'
CREATE INDEX [IX_FK_InvoiceCurrency]
ON [dbo].[Invoice]
    ([CurrencyId]);
GO

-- Creating foreign key on [TodoId] in table 'TimeRecord'
ALTER TABLE [dbo].[TimeRecord]
ADD CONSTRAINT [FK_TodoTimeRecord]
    FOREIGN KEY ([TodoId])
    REFERENCES [dbo].[Todo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TodoTimeRecord'
CREATE INDEX [IX_FK_TodoTimeRecord]
ON [dbo].[TimeRecord]
    ([TodoId]);
GO

-- Creating foreign key on [UserTeamLinkId] in table 'Invoice'
ALTER TABLE [dbo].[Invoice]
ADD CONSTRAINT [FK_UserTeamLinkInvoice]
    FOREIGN KEY ([UserTeamLinkId])
    REFERENCES [dbo].[UserTeamLink]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeamLinkInvoice'
CREATE INDEX [IX_FK_UserTeamLinkInvoice]
ON [dbo].[Invoice]
    ([UserTeamLinkId]);
GO

-- Creating foreign key on [InvoiceId] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [FK_InvoicePayment]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[Invoice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoicePayment'
CREATE INDEX [IX_FK_InvoicePayment]
ON [dbo].[Payment]
    ([InvoiceId]);
GO

-- Creating foreign key on [StatusId] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_ProjectStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectStatus'
CREATE INDEX [IX_FK_ProjectStatus]
ON [dbo].[Project]
    ([StatusId]);
GO

-- Creating foreign key on [StatusId] in table 'Todo'
ALTER TABLE [dbo].[Todo]
ADD CONSTRAINT [FK_TodoStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TodoStatus'
CREATE INDEX [IX_FK_TodoStatus]
ON [dbo].[Todo]
    ([StatusId]);
GO

-- Creating foreign key on [UserID] in table 'UserTeamLink'
ALTER TABLE [dbo].[UserTeamLink]
ADD CONSTRAINT [FK_UserTeamLinkUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeamLinkUser'
CREATE INDEX [IX_FK_UserTeamLinkUser]
ON [dbo].[UserTeamLink]
    ([UserID]);
GO

-- Creating foreign key on [TeamId] in table 'UserTeamLink'
ALTER TABLE [dbo].[UserTeamLink]
ADD CONSTRAINT [FK_UserTeamLinkTeam]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTeamLinkTeam'
CREATE INDEX [IX_FK_UserTeamLinkTeam]
ON [dbo].[UserTeamLink]
    ([TeamId]);
GO

-- Creating foreign key on [RoleId] in table 'RolePermissionLink'
ALTER TABLE [dbo].[RolePermissionLink]
ADD CONSTRAINT [FK_RolePermissionLinkRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissionLinkRole'
CREATE INDEX [IX_FK_RolePermissionLinkRole]
ON [dbo].[RolePermissionLink]
    ([RoleId]);
GO

-- Creating foreign key on [PermissionId] in table 'RolePermissionLink'
ALTER TABLE [dbo].[RolePermissionLink]
ADD CONSTRAINT [FK_RolePermissionLinkPermission]
    FOREIGN KEY ([PermissionId])
    REFERENCES [dbo].[Permission]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePermissionLinkPermission'
CREATE INDEX [IX_FK_RolePermissionLinkPermission]
ON [dbo].[RolePermissionLink]
    ([PermissionId]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceProjectLink'
ALTER TABLE [dbo].[InvoiceProjectLink]
ADD CONSTRAINT [FK_InvoiceProjectLinkInvoice]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[Invoice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceProjectLinkInvoice'
CREATE INDEX [IX_FK_InvoiceProjectLinkInvoice]
ON [dbo].[InvoiceProjectLink]
    ([InvoiceId]);
GO

-- Creating foreign key on [ProjectID] in table 'InvoiceProjectLink'
ALTER TABLE [dbo].[InvoiceProjectLink]
ADD CONSTRAINT [FK_InvoiceProjectLinkProject]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceProjectLinkProject'
CREATE INDEX [IX_FK_InvoiceProjectLinkProject]
ON [dbo].[InvoiceProjectLink]
    ([ProjectID]);
GO

-- Creating foreign key on [UserId] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [FK_UserClient]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserClient'
CREATE INDEX [IX_FK_UserClient]
ON [dbo].[Client]
    ([UserId]);
GO

-- Creating foreign key on [ProjectId] in table 'Todo'
ALTER TABLE [dbo].[Todo]
ADD CONSTRAINT [FK_TodoProject]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TodoProject'
CREATE INDEX [IX_FK_TodoProject]
ON [dbo].[Todo]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------