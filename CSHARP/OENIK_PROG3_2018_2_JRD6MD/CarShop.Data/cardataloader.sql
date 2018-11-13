DROP TABLE ModelExtraswitch;
DROP TABLE Models;
DROP TABLE Extras;
DROP TABLE CarBrands;

CREATE TABLE CarBrands(     
Carbrand_Id int NOT NULL IDENTITY(1, 1),    
Carbrand_Name VARCHAR(64),   
Carbrand_Country_Name VARCHAR(64),
Carbrand_Url VARCHAR(64),    
Carbrand_Foundation_Year NUMERIC(4),    
Carbrand_Yearly_Traffic VARCHAR(64),    
    CONSTRAINT PK_Carbrand_Id PRIMARY KEY(Carbrand_Id) 
);    

CREATE TABLE Models(     
Model_Id int NOT NULL IDENTITY(1, 1), 
Carbrand_Id int NOT NULL, 
Model_Name VARCHAR(64),
Model_Release_Day  DATE,
Model_Engine_Volume NUMERIC(4) NOT NULL,
Model_Horsepower NUMERIC(8) NOT NULL,    
Model_Base_Price NUMERIC(16) NOT NULL,     
CONSTRAINT PK_Model_Id PRIMARY KEY(Model_Id),
CONSTRAINT FK_Carbrand_Id FOREIGN KEY(Carbrand_Id) REFERENCES CarBrands(Carbrand_Id)

);     

CREATE TABLE Extras(     
Extra_Id int NOT NULL IDENTITY(1, 1), 
Extra_Category_Name VARCHAR(64),     
Extra_Name VARCHAR(64), 
Extra_Price NUMERIC(16) NOT NULL,  
Extra_Color VARCHAR(64),
Extra_Multiple_Usage NUMERIC(1) NOT NULL DEFAULT '0',
CONSTRAINT PK_Extra_Id PRIMARY KEY(Extra_Id)
);     

CREATE TABLE ModelExtraswitch(     
ModelExtraswitch_Id int NOT NULL IDENTITY(1, 1),  
Model_Id int NOT NULL, 
Extra_Id int NOT NULL,       
CONSTRAINT PK_ModelExtraswitch_Id PRIMARY KEY(ModelExtraswitch_Id),
CONSTRAINT FK_Model_Id FOREIGN KEY(Model_Id) REFERENCES Models(model_Id),
CONSTRAINT FK_Extra_Id FOREIGN KEY(extra_id) REFERENCES Extras(Extra_Id)
);  


INSERT INTO CarBrands VALUES ('Audi', 'Germany', 'https://wwww.audi.hu/', 1909, '48 billion euro');
INSERT INTO CarBrands VALUES ('BMW', 'Germany', 'https://www.bmw.hu/', 1929, '50 billion euro');
INSERT INTO CarBrands VALUES ('Renault', 'French', 'https://www.renault.hu/', 1899, '41 billion euro');


INSERT INTO Models VALUES (1, 'A1', '2010-08-01', '1197', '85', '17000' );
INSERT INTO Models VALUES (1, 'A2', '1999-11-01', '1390', '74', '16000' );
INSERT INTO Models VALUES (1, 'Q8', '2017-01-09', '2995', '230', '65000' );

INSERT INTO Models VALUES (2, 'X6', '2008-04-01', '2979', '302', '58000' );
INSERT INTO Models VALUES (2, 'X5 F15', '2006-02-01', '2979', '302', '60000' );
INSERT INTO Models VALUES (2, 'F90 M5', '2017-08-21', '4395', '591', '100000' );

INSERT INTO Models VALUES (3, 'Twingo', '2012-03-01', '1149', '60', '10163' );
INSERT INTO Models VALUES (3, 'Clio', '2012-09-01', '1461', '75', '10496' );
INSERT INTO Models VALUES (3, 'Megane', '2015-09-01', '2385', '89', '25000' )

INSERT INTO Extras VALUES ('KategoriaNev1', 'Név1', 500, 'blue', 1);
INSERT INTO Extras VALUES ('KategoriaNev1', 'Név2', 300, 'white', 1);
INSERT INTO Extras VALUES ('KategoriaNev2', 'Név3', 1000, 'metalgreen', 1);
INSERT INTO Extras VALUES ('KategoriaNev2', 'Név4', 5000, 'violet', 1);
INSERT INTO Extras VALUES ('KategoriaNev3', 'Név5', 200, 'matte blue', 0);
INSERT INTO Extras VALUES ('KategoriaNev3', 'Név6', 100, 'no color', 0);

INSERT INTO ModelExtraswitch VALUES (1, 1);
INSERT INTO ModelExtraswitch VALUES (1, 2);
INSERT INTO ModelExtraswitch VALUES (1, 3);
INSERT INTO ModelExtraswitch VALUES (1, 4);
INSERT INTO ModelExtraswitch VALUES (1, 5);
INSERT INTO ModelExtraswitch VALUES (2, 6);
INSERT INTO ModelExtraswitch VALUES (2, 1);
INSERT INTO ModelExtraswitch VALUES (2, 2);
INSERT INTO ModelExtraswitch VALUES (3, 3);
INSERT INTO ModelExtraswitch VALUES (3, 4);
INSERT INTO ModelExtraswitch VALUES (3, 5);
INSERT INTO ModelExtraswitch VALUES (3, 6);
INSERT INTO ModelExtraswitch VALUES (4, 1);
INSERT INTO ModelExtraswitch VALUES (4, 2);
INSERT INTO ModelExtraswitch VALUES (4, 3);
INSERT INTO ModelExtraswitch VALUES (4, 4);
INSERT INTO ModelExtraswitch VALUES (4, 5);
INSERT INTO ModelExtraswitch VALUES (5, 6);
INSERT INTO ModelExtraswitch VALUES (5, 1);
INSERT INTO ModelExtraswitch VALUES (5, 2);
INSERT INTO ModelExtraswitch VALUES (5, 3);
INSERT INTO ModelExtraswitch VALUES (6, 4);
INSERT INTO ModelExtraswitch VALUES (6, 5);
INSERT INTO ModelExtraswitch VALUES (7, 6);
INSERT INTO ModelExtraswitch VALUES (7, 1);
INSERT INTO ModelExtraswitch VALUES (8, 2);
INSERT INTO ModelExtraswitch VALUES (8, 3);
INSERT INTO ModelExtraswitch VALUES (9, 4);
INSERT INTO ModelExtraswitch VALUES (9, 5);
INSERT INTO ModelExtraswitch VALUES (9, 6);






