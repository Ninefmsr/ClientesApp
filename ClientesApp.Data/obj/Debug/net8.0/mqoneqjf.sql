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

CREATE TABLE [CLIENTE] (
    [IDCLIENTE] uniqueidentifier NOT NULL,
    [NOME] nvarchar(100) NOT NULL,
    [CPF] nvarchar(11) NOT NULL,
    [TELEFONE] nvarchar(9) NOT NULL,
    [EMAIL] nvarchar(256) NOT NULL,
    [DATA DE NASCIMENTO] datetime2 NOT NULL,
    CONSTRAINT [PK_CLIENTE] PRIMARY KEY ([IDCLIENTE])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240221181802_Initial', N'8.0.1');
GO

COMMIT;
GO

