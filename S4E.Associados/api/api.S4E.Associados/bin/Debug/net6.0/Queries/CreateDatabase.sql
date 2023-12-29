USE master;

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'S4E-Associados')
BEGIN
    CREATE DATABASE [S4E-Associados]
END