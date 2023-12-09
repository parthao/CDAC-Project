
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2023 10:45:57
-- Generated from EDMX file: D:\CDAC Project\Timeless-treasure-\WebBackEndAPI\WebBackEndAPI\Models\Project.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Project];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_bid_table_ibfk_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[bid_table] DROP CONSTRAINT [FK_bid_table_ibfk_1];
GO
IF OBJECT_ID(N'[dbo].[FK_bid_table_ibfk_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[bid_table] DROP CONSTRAINT [FK_bid_table_ibfk_2];
GO
IF OBJECT_ID(N'[dbo].[FK_aution_tableproduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aution_table] DROP CONSTRAINT [FK_aution_tableproduct];
GO
IF OBJECT_ID(N'[dbo].[FK_product_ibfk_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_product_ibfk_1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[aution_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aution_table];
GO
IF OBJECT_ID(N'[dbo].[bid_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bid_table];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[user_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_db];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'aution_table'
CREATE TABLE [dbo].[aution_table] (
    [auc_id] int IDENTITY(1,1) NOT NULL,
    [start_date] datetime  NULL,
    [end_date] datetime  NULL,
    [create_time] datetime  NULL,
    [product_p_id] int  NOT NULL
);
GO

-- Creating table 'bid_table'
CREATE TABLE [dbo].[bid_table] (
    [bid_id] int IDENTITY(1,1) NOT NULL,
    [usr_id] int  NOT NULL,
    [p_id] int  NULL,
    [user_bid_price] int  NULL,
    [create_time] datetime  NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [p_id] int IDENTITY(1,1) NOT NULL,
    [p_name] varchar(100)  NULL,
    [p_descp] varchar(1000)  NULL,
    [p_size] float  NULL,
    [p_weight] float  NULL,
    [p_material] varchar(15)  NULL,
    [p_imgloc] varchar(1000)  NULL,
    [create_time] datetime  NULL,
    [p_category] char(1)  NOT NULL,
    [usr_id] int  NULL,
    [base_price] int  NOT NULL
);
GO

-- Creating table 'user_db'
CREATE TABLE [dbo].[user_db] (
    [usr_id] int IDENTITY(1,1) NOT NULL,
    [f_name] varchar(50)  NULL,
    [l_name] varchar(50)  NULL,
    [pass_w] varchar(255)  NULL,
    [email] varchar(50)  NOT NULL,
    [mobile] varchar(12)  NOT NULL,
    [usraddress] varchar(100)  NULL,
    [pincode] int  NULL,
    [city] varchar(150)  NULL,
    [statex] varchar(150)  NULL,
    [country] varchar(15)  NULL,
    [created_At] datetime  NULL,
    [x] varchar(255)  NULL,
    [y] varchar(255)  NULL,
    [z] varchar(255)  NULL,
    [type] char(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [auc_id] in table 'aution_table'
ALTER TABLE [dbo].[aution_table]
ADD CONSTRAINT [PK_aution_table]
    PRIMARY KEY CLUSTERED ([auc_id] ASC);
GO

-- Creating primary key on [bid_id] in table 'bid_table'
ALTER TABLE [dbo].[bid_table]
ADD CONSTRAINT [PK_bid_table]
    PRIMARY KEY CLUSTERED ([bid_id] ASC);
GO

-- Creating primary key on [p_id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([p_id] ASC);
GO

-- Creating primary key on [usr_id] in table 'user_db'
ALTER TABLE [dbo].[user_db]
ADD CONSTRAINT [PK_user_db]
    PRIMARY KEY CLUSTERED ([usr_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [product_p_id] in table 'aution_table'
ALTER TABLE [dbo].[aution_table]
ADD CONSTRAINT [FK_aution_tableproduct]
    FOREIGN KEY ([product_p_id])
    REFERENCES [dbo].[products]
        ([p_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aution_tableproduct'
CREATE INDEX [IX_FK_aution_tableproduct]
ON [dbo].[aution_table]
    ([product_p_id]);
GO

-- Creating foreign key on [usr_id] in table 'bid_table'
ALTER TABLE [dbo].[bid_table]
ADD CONSTRAINT [FK_bid_table_ibfk_1]
    FOREIGN KEY ([usr_id])
    REFERENCES [dbo].[user_db]
        ([usr_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bid_table_ibfk_1'
CREATE INDEX [IX_FK_bid_table_ibfk_1]
ON [dbo].[bid_table]
    ([usr_id]);
GO

-- Creating foreign key on [p_id] in table 'bid_table'
ALTER TABLE [dbo].[bid_table]
ADD CONSTRAINT [FK_bid_table_ibfk_2]
    FOREIGN KEY ([p_id])
    REFERENCES [dbo].[products]
        ([p_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bid_table_ibfk_2'
CREATE INDEX [IX_FK_bid_table_ibfk_2]
ON [dbo].[bid_table]
    ([p_id]);
GO

-- Creating foreign key on [usr_id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_product_ibfk_1]
    FOREIGN KEY ([usr_id])
    REFERENCES [dbo].[user_db]
        ([usr_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_product_ibfk_1'
CREATE INDEX [IX_FK_product_ibfk_1]
ON [dbo].[products]
    ([usr_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------