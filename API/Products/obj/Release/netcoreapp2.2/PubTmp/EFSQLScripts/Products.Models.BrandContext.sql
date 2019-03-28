IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190328112209_first')
BEGIN
    CREATE TABLE [Brand] (
        [BrandName] nvarchar(450) NOT NULL,
        [Value] float NOT NULL,
        CONSTRAINT [PK_Brand] PRIMARY KEY ([BrandName])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190328112209_first')
BEGIN
    CREATE TABLE [Product] (
        [id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [BrandName] nvarchar(450) NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Product_Brand_BrandName] FOREIGN KEY ([BrandName]) REFERENCES [Brand] ([BrandName]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190328112209_first')
BEGIN
    CREATE INDEX [IX_Product_BrandName] ON [Product] ([BrandName]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190328112209_first')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190328112209_first', N'2.2.2-servicing-10034');
END;

GO

