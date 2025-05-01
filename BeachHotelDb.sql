-- Crear base de datos
CREATE DATABASE BeachHotelDb;
GO

USE BeachHotelDb;
GO

-- Crear tabla de Clientes
CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    Cedula NVARCHAR(150) NOT NULL,
    TipoCedula NVARCHAR(150) NOT NULL,
    NombreCompleto NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(150) NOT NULL,
    Direccion NVARCHAR(150) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
GO

-- Insertar clientes iniciales
INSERT INTO Clientes (Cedula, TipoCedula, NombreCompleto, Telefono, Direccion, Email)
VALUES 
('2233445566', 'Cédula de Ciudadanía', 'María López', '3009876543', 'Calle 10 #23-45', 'maria.lopez@email.com'),
('3344556677', 'Cédula de Ciudadanía', 'Pedro Martínez', '3101234567', 'Avenida 5 #78-90', 'pedro.martinez@email.com'),
('4455667788', 'Cédula de Extranjería', 'Lucía Rodríguez', '3208765432', 'Carrera 20 #33-45', 'lucia.rodriguez@email.com'),
('5566778899', 'Cédula de Ciudadanía', 'José Ramírez', '3302345678', 'Calle 50 #12-34', 'jose.ramirez@email.com'),
('6677889900', 'Cédula de Extranjería', 'Laura Fernández', '3403456789', 'Calle 7 #10-20', 'laura.fernandez@email.com');
GO

-- Crear tabla de Paquetes
CREATE TABLE Paquetes (
    PaqueteId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    CostoPorPersonaPorNoche DECIMAL(10,2) NOT NULL,
    PrimaPorcentaje DECIMAL(5,2) NOT NULL,
    PlazoMeses INT NOT NULL
);
GO

-- Insertar paquetes iniciales
INSERT INTO Paquetes (Nombre, CostoPorPersonaPorNoche, PrimaPorcentaje, PlazoMeses)
VALUES 
('Todo Incluido', 450.00, 45.00, 24),
('Alimentación', 275.00, 35.00, 18),
('Hospedaje', 210.00, 15.00, 12),
('Aventura y Naturaleza', 500.00, 50.00, 30),
('Relax y Spa', 350.00, 40.00, 20);
GO

-- Crear tabla de Reservaciones
CREATE TABLE Reservaciones (
    ReservacionId INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    PaqueteId INT NOT NULL,
    FechaReserva DATETIME NOT NULL,
    CantidadPersonas INT NOT NULL,
    MontoTotal DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    FOREIGN KEY (PaqueteId) REFERENCES Paquetes(PaqueteId)
);
GO

-- Insertar reservaciones iniciales
INSERT INTO Reservaciones (ClienteId, PaqueteId, FechaReserva, CantidadPersonas, MontoTotal)
VALUES 
(1, 1, '2025-06-01 10:00:00', 2, 900.00),
(2, 3, '2025-06-02 14:00:00', 3, 630.00),
(3, 5, '2025-06-03 11:30:00', 1, 350.00),
(4, 4, '2025-06-04 15:00:00', 2, 1000.00),
(5, 2, '2025-06-05 09:00:00', 4, 1100.00);
GO

