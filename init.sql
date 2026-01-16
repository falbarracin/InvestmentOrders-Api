/* ===============================
   DATABASE
   =============================== */
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'InvestmentOrdersDb')
BEGIN
    CREATE DATABASE InvestmentOrdersDb;
END
GO

USE InvestmentOrdersDb;
GO

/* ===============================
   ASSET TYPES (MASTER)
   =============================== */
IF OBJECT_ID('AssetTypes', 'U') IS NULL
BEGIN
    CREATE TABLE AssetTypes (
        Id INT NOT NULL,
        Description NVARCHAR(32) NOT NULL,
        CONSTRAINT PK_AssetTypes PRIMARY KEY (Id)
    );
END
GO

/* ===============================
   ORDER STATUS (MASTER)
   TABLA: OrderStatus  (singular)
   =============================== */
IF OBJECT_ID('OrderStatus', 'U') IS NULL
BEGIN
    CREATE TABLE OrderStatus (
        Id INT NOT NULL,
        Description NVARCHAR(32) NOT NULL,
        CONSTRAINT PK_OrderStatus PRIMARY KEY (Id)
    );
END
GO

/* ===============================
   ASSETS
   =============================== */
IF OBJECT_ID('Assets', 'U') IS NULL
BEGIN
    CREATE TABLE Assets (
        Id INT NOT NULL,
        Ticker NVARCHAR(32) NOT NULL,
        Name NVARCHAR(64) NOT NULL,
        AssetTypeId INT NOT NULL,
        Price DECIMAL(18,4) NOT NULL,
        CONSTRAINT PK_Assets PRIMARY KEY (Id),
        CONSTRAINT FK_Assets_AssetTypes
            FOREIGN KEY (AssetTypeId)
            REFERENCES AssetTypes(Id)
            ON DELETE NO ACTION
    );
END
GO

/* ===============================
   ORDERS
   =============================== */
IF OBJECT_ID('Orders', 'U') IS NULL
BEGIN
    CREATE TABLE Orders (
        Id INT IDENTITY(1,1) NOT NULL,
        AccountId INT NOT NULL,
        AssetId INT NOT NULL,
        Quantity INT NOT NULL,
        Price DECIMAL(18,4) NULL,
        StatusId INT NOT NULL,
        TotalAmount DECIMAL(18,4) NOT NULL,
        CONSTRAINT PK_Orders PRIMARY KEY (Id),
        CONSTRAINT FK_Orders_Assets
            FOREIGN KEY (AssetId)
            REFERENCES Assets(Id)
            ON DELETE NO ACTION,
        CONSTRAINT FK_Orders_OrderStatus
            FOREIGN KEY (StatusId)
            REFERENCES OrderStatus(Id)
            ON DELETE NO ACTION
    );
END
GO

/* ===============================
   SEED: ASSET TYPES
   =============================== */
IF NOT EXISTS (SELECT 1 FROM AssetTypes)
BEGIN
    INSERT INTO AssetTypes (Id, Description) VALUES
    (1, 'Acción'),
    (2, 'Bono'),
    (3, 'FCI');
END
GO

/* ===============================
   SEED: ORDER STATUS
   =============================== */
IF NOT EXISTS (SELECT 1 FROM OrderStatus)
BEGIN
    INSERT INTO OrderStatus (Id, Description) VALUES
    (1, 'En proceso'),
    (2, 'Ejecutada'),
    (3, 'Cancelada');
END
GO

/* ===============================
   SEED: ASSETS
   =============================== */
IF NOT EXISTS (SELECT 1 FROM Assets)
BEGIN
    INSERT INTO Assets (Id, Ticker, Name, AssetTypeId, Price) VALUES
    (1, 'AAPL', 'Apple', 1, 177.97),
    (2, 'GOOGL', 'Alphabet Inc', 1, 138.21),
    (3, 'MSFT', 'Microsoft', 1, 329.04),
    (4, 'KO', 'Coca Cola', 1, 58.30),
    (5, 'WMT', 'Walmart', 1, 163.42),
    (6, 'AL30', 'BONOS ARGENTINA USD 2030 L.A', 2, 307.40),
    (7, 'GD30', 'Bonos Globales Argentina USD Step Up 2030', 2, 336.10),
    (8, 'Delta.Pesos', 'Delta Pesos Clase A', 3, 0.0181),
    (9, 'Fima.Premium', 'Fima Premium Clase A', 3, 0.0317);
END
GO