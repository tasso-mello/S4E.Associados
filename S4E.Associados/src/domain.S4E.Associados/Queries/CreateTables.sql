IF EXISTS (SELECT name FROM sys.databases WHERE name = 'S4E-Associados')
BEGIN    
    USE [S4E-Associados]

    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Associados')
    BEGIN
        CREATE TABLE Associados
        (
            Id BIGINT IDENTITY(1,1) PRIMARY KEY,
            Nome NVARCHAR(MAX),
            CPF NVARCHAR(11) UNIQUE,
            Nascimento DATETIME
        )
    END

    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empresas')
    BEGIN
        CREATE TABLE Empresas
        (
            Id BIGINT IDENTITY(1,1) PRIMARY KEY,
            Nome NVARCHAR(MAX),
            CNPJ NVARCHAR(14) UNIQUE
        )
    END

    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AssociadoEmpresa')
    BEGIN
        CREATE TABLE AssociadoEmpresa
        (
            AssociadoId BIGINT,
            EmpresaId BIGINT,
            PRIMARY KEY (AssociadoId, EmpresaId),
            FOREIGN KEY (AssociadoId) REFERENCES Associados(Id),
            FOREIGN KEY (EmpresaId) REFERENCES Empresas(Id)
        )
    END
END