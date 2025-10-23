-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Rowing')
BEGIN
    CREATE DATABASE Rowing;
END
GO

USE Rowing;
GO