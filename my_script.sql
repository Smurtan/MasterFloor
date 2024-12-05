Use MasterFloor;

CREATE TABLE MaterialType ( 
  ID INT IDENTITY(1,1) PRIMARY KEY,
  Title VARCHAR(255),
  ScrapRate DECIMAL(7,2),
);

CREATE TABLE ProductType( 
  ID INT IDENTITY(1,1) PRIMARY KEY,
  Title VARCHAR(255),
  Ratio DECIMAL(7,2),
);

CREATE TABLE Products ( 
  ID INT IDENTITY(1,1) PRIMARY KEY,
  Title  VARCHAR(255),
  Article VARCHAR(255),
  MinPartnerPrice DECIMAL(7,2),
  ProductTypeID INT,
  FOREIGN KEY (ProductTypeID) REFERENCES  ProductType(ID)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
);

CREATE TABLE Partners ( 
  ID INT IDENTITY(1,1) PRIMARY KEY,
  TypePartners VARCHAR(255),
  Title VARCHAR(255),
  Director VARCHAR(255),
  Email VARCHAR(255),
  Phone VARCHAR(255),
  LegalAddress VARCHAR(255),
  INN VARCHAR(255),
  Rating INT,
);

CREATE TABLE PartnerProducts (
  ID INT IDENTITY(1,1) PRIMARY KEY,
  CountProduct INT,
  DataSale DATE,
  ProductID INT,
  PartnerID INT,
  FOREIGN KEY (ProductID) REFERENCES  Products(ID)
      ON UPDATE CASCADE
      ON DELETE CASCADE,
  FOREIGN KEY (PartnerID) REFERENCES  Partners(ID)
      ON UPDATE CASCADE 
      ON DELETE CASCADE, 
);
