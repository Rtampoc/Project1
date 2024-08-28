﻿CREATE DATABASE dbBincard
GO

USE dbBincard
GO

CREATE TABLE tbl_Item(
ID INT IDENTITY PRIMARY KEY,
Itmname VARCHAR(500),
Descript VARCHAR(500),
CatgryID INT,
Catgry VARCHAR(100),
Brand VARCHAR(100),
SerlNo VARCHAR(100),
Qty INT,
UCost DECIMAL(18, 2),
Warranty VARCHAR(50),
InvcNo VARCHAR(100),
InvcDate DATETIME,
DelDate DATETIME,
SuppID INT,
Supplier VARCHAR(100),
Stat BIT DEFAULT 1,
RecvdBy VARCHAR(100),
InspctBy VARCHAR(100),
RecrdBy VARCHAR(100),
[Timestamp] DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE tbl_Transaction(
ID INT IDENTITY PRIMARY KEY,
ItemID INT,
TransDate DATETIME,
TransType VARCHAR(500),
EUser VARCHAR(150),
Dept VARCHAR(100),
Loc VARCHAR(100),
Remarks VARCHAR(500),
[Timestamp] DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE tbl_Supplier(
ID INT IDENTITY PRIMARY KEY,
Supplier VARCHAR(100),
Addrss VARCHAR(500),
TelNo VARCHAR(50),
Email VARCHAR(100),
[Timestamp] DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE tbl_Category(
ID INT IDENTITY PRIMARY KEY,
Catgry VARCHAR(100),
CatgryCode VARCHAR(10),
[Timestamp] DATETIME DEFAULT GETDATE()
)
GO