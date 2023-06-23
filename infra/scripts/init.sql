-- Creación de la base de datos
CREATE DATABASE IF NOT EXISTS SkillUPDb;
USE SkillUPDb;

CREATE TABLE IF NOT EXISTS Clientes (
    Id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Name VARCHAR(100),
    Email VARCHAR(100),
    CreatedBy BIGINT UNSIGNED,
    CreatedAt DATETIME,
    State BOOL,
    PRIMARY KEY (Id)
);

INSERT INTO Clientes (Nombre, Email, CreatedBy, CreatedAt, State) VALUES ('Daniel Sebastiao', 'daniel.2.sebastiao@atos.net', 1 , NOW(), True);