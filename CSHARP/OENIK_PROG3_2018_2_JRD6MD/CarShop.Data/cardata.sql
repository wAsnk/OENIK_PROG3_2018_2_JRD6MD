CREATE TABLE CarBrands(     
Carbrand_Id NUMERIC(2) NOT NULL,     
Carbrand_Name VARCHAR(64),   
Carbrand_Country_Name VARCHAR(64),
Carbrand_Url VARCHAR(64),    
Carbrand_Foundation_Year DATE,    
Carbrand_Yearly_Traffic VARCHAR(64),    
    CONSTRAINT PK_Carbrand_Id PRIMARY KEY(Carbrand_Id) 
);    

CREATE TABLE Models(     
Model_Id NUMERIC(2) NOT NULL,
Carbrand_Id NUMERIC(2) NOT NULL, 
Model_Name VARCHAR(64),
Model_Release_Day  DATE,
Model_Engine_Volume NUMERIC(4) NOT NULL,
Model_Horsepower NUMERIC(8) NOT NULL,    
Model_Base_Price NUMERIC(16) NOT NULL,     
CONSTRAINT PK_Model_Id PRIMARY KEY(Model_Id),
CONSTRAINT FK_Carbrand_Id FOREIGN KEY(Carbrand_Id) REFERENCES CarBrands(Carbrand_Id)

);     

CREATE TABLE Extras(     
Extra_Id NUMERIC(2) NOT NULL,    
Extra_Category_Name VARCHAR(64),     
Extra_Name VARCHAR(64), 
Extra_Price NUMERIC(16) NOT NULL,  
Extra_Color VARCHAR(64),
Extra_Multiple_Usage NUMERIC(1) NOT NULL DEFAULT '0',
CONSTRAINT PK_Extra_Id PRIMARY KEY(Extra_Id)
);     

CREATE TABLE ModelExtraswitch(     
ModelExtraswitch_Id NUMERIC(2) NOT NULL,  
Model_Id NUMERIC(2) NOT NULL, 
Extra_Id NUMERIC(2) NOT NULL,       
CONSTRAINT PK_ModelExtraswitch_Id PRIMARY KEY(ModelExtraswitch_Id),
CONSTRAINT FK_Model_Id FOREIGN KEY(Model_Id) REFERENCES Models(model_Id),
CONSTRAINT FK_Extra_Id FOREIGN KEY(extra_id) REFERENCES Extras(Extra_Id)
);  


INSERT INTO CarBrands VALUES (1, 'Audi', 'Germany', 'https://wwww.audi.hu/', '1909', '48 billion euro');
INSERT INTO CarBrands VALUES (2, 'BMW', 'Germany', 'https://www.bmw.hu/', '1929', '50 billion euro');
INSERT INTO CarBrands VALUES (3, 'Renault', 'French', 'https://www.renault.hu/', '1899', '41 billion euro');


INSERT INTO Models VALUES (1,1, 'A1', '2010-08-01', '1197', '85', '17000' );
INSERT INTO Models VALUES (2,1, 'A2', '1999-11-01', '1390', '74', '16000' );
INSERT INTO Models VALUES (3,1, 'Q8', '2017-01-09', '2995', '230', '65000' );

INSERT INTO Models VALUES (4,2, 'X6', '2008-04-01', '2979', '302', '58000' );
INSERT INTO Models VALUES (5,2, 'X5 F15', '2006-02-01', '2979', '302', '60000' );
INSERT INTO Models VALUES (6,2, 'F90 M5', '2017-08-21', '4395', '591', '100000' );

INSERT INTO Models VALUES (7,3, 'Twingo', '2012-03-01', '1149', '60', '10163' );
INSERT INTO Models VALUES (8,3, 'Clio', '2012-09-01', '1461', '75', '10496' );
INSERT INTO Models VALUES (9,3, 'Megane', '2015-09-01', '2385', '89', '25000' )

INSERT INTO Extras VALUES (1,'KategoriaNev1', 'Név1', 500, 'blue', 1);
INSERT INTO Extras VALUES (2,'KategoriaNev1', 'Név2', 300, 'white', 1);
INSERT INTO Extras VALUES (3,'KategoriaNev2', 'Név3', 1000, 'metalgreen', 1);
INSERT INTO Extras VALUES (4,'KategoriaNev2', 'Név4', 5000, 'violet', 1);
INSERT INTO Extras VALUES (5,'KategoriaNev3', 'Név5', 200, 'matte blue', 0);
INSERT INTO Extras VALUES (6,'KategoriaNev3', 'Név6', 100, 'no color', 0);

INSERT INTO ModelExtraswitch VALUES (1, 1, 1);
INSERT INTO ModelExtraswitch VALUES (2, 1, 2);
INSERT INTO ModelExtraswitch VALUES (3, 1, 3);
INSERT INTO ModelExtraswitch VALUES (4, 1, 4);
INSERT INTO ModelExtraswitch VALUES (5, 1, 5);
INSERT INTO ModelExtraswitch VALUES (6, 2, 6);
INSERT INTO ModelExtraswitch VALUES (7, 2, 1);
INSERT INTO ModelExtraswitch VALUES (8, 2, 2);
INSERT INTO ModelExtraswitch VALUES (9, 3, 3);
INSERT INTO ModelExtraswitch VALUES (10, 3, 4);
INSERT INTO ModelExtraswitch VALUES (11, 3, 5);
INSERT INTO ModelExtraswitch VALUES (12, 3, 6);
INSERT INTO ModelExtraswitch VALUES (13, 4, 1);
INSERT INTO ModelExtraswitch VALUES (14, 4, 2);
INSERT INTO ModelExtraswitch VALUES (15, 4, 3);
INSERT INTO ModelExtraswitch VALUES (16, 4, 4);
INSERT INTO ModelExtraswitch VALUES (17, 4, 5);
INSERT INTO ModelExtraswitch VALUES (18, 5, 6);
INSERT INTO ModelExtraswitch VALUES (19, 5, 1);
INSERT INTO ModelExtraswitch VALUES (20, 5, 2);
INSERT INTO ModelExtraswitch VALUES (21, 5, 3);
INSERT INTO ModelExtraswitch VALUES (22, 6, 4);
INSERT INTO ModelExtraswitch VALUES (23, 6, 5);
INSERT INTO ModelExtraswitch VALUES (24, 7, 6);
INSERT INTO ModelExtraswitch VALUES (25, 7, 1);
INSERT INTO ModelExtraswitch VALUES (26, 8, 2);
INSERT INTO ModelExtraswitch VALUES (27, 8, 3);
INSERT INTO ModelExtraswitch VALUES (28, 9, 4);
INSERT INTO ModelExtraswitch VALUES (29, 9, 5);
INSERT INTO ModelExtraswitch VALUES (30, 9, 6);






