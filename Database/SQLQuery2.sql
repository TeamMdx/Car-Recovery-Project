-- DAY 1: Initial Database Setup
CREATE DATABASE CarRecoveryDB;
GO

USE CarRecoveryDB;
GO

CREATE TABLE CarRecoveries (
    NumberPlate VARCHAR(20) PRIMARY KEY,
    CarModel VARCHAR(100),
    Status VARCHAR(50) DEFAULT 'Pending'
);
GO

-- Add some seed data so the tree isn't empty on the first run
INSERT INTO CarRecoveries (NumberPlate, CarModel, Status) 
VALUES ('ABC-123', 'Tesla Model 3', 'Pending'),
       ('XYZ-789', 'Ford Transit', 'Pending');
GO
