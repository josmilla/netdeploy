IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220203064415_Init')
BEGIN
    CREATE TABLE [Product] (
        [ProductId] uniqueidentifier NOT NULL DEFAULT ((newid())),
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,3) NOT NULL,
        [Created] datetimeoffset NOT NULL,
        [Updated] datetimeoffset NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220203064415_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220203064415_Init', N'5.0.13');
END;
GO

COMMIT;
GO

