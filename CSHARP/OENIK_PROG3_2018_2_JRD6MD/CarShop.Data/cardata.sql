CREATE TABLE carbrands(     
carbrand_id NUMERIC(2) NOT NULL,     
carbrand_name VARCHAR(64),   
carbrand_country_name VARCHAR(64),
carbrand_url VARCHAR(64),    
carbrand_foundation_year DATE,    
carbrand_yearly_traffic VARCHAR(64),    
    CONSTRAINT PK_carbrand_id PRIMARY KEY(carbrand_id) 
);    

CREATE TABLE models(     
model_id NUMERIC(2) NOT NULL,
carbrand_id NUMERIC(2) NOT NULL, 
model_name VARCHAR(64),
model_release_day  DATE,
model_engine_volume NUMERIC(4) NOT NULL,
model_horsepower NUMERIC(8) NOT NULL,    
model_base_price NUMERIC(16) NOT NULL,     
CONSTRAINT PK_model_id PRIMARY KEY(model_id),
CONSTRAINT FK_carbrand_id FOREIGN KEY(carbrand_id) REFERENCES carbrands(carbrand_id)

);     

CREATE TABLE extras(     
extra_id NUMERIC(2) NOT NULL,    
extra_category_name VARCHAR(64),     
extra_name VARCHAR(64), 
extra_price NUMERIC(16) NOT NULL,  
extra_color VARCHAR(64),
extra_multiple_usage NUMERIC(1) NOT NULL DEFAULT '0',
CONSTRAINT PK_extra_id PRIMARY KEY(extra_id)
);     

CREATE TABLE modelExtraSwitch(     
modelExtraSwitch_id NUMERIC(2) NOT NULL,  
model_id NUMERIC(2) NOT NULL, 
extra_id NUMERIC(2) NOT NULL,       
CONSTRAINT PK_modelExtraSwitch_id PRIMARY KEY(modelExtraSwitch_id),
CONSTRAINT FK_model_id FOREIGN KEY(model_id) REFERENCES models(model_id),
CONSTRAINT FK_extra_id FOREIGN KEY(extra_id) REFERENCES extras(extra_id)
);  


INSERT INTO carbrands VALUES (1, 'Audi', 'Germany', 'https://wwww.audi.hu/', '1909', '48 billion euro');
INSERT INTO carbrands VALUES (2, 'BMW', 'Germany', 'https://www.bmw.hu/', '1929', '50 billion euro');
INSERT INTO carbrands VALUES (3, 'Renault', 'French', 'https://www.renault.hu/', '1899', '41 billion euro');


INSERT INTO models VALUES (1,1, 'A1', '2010-08-01', '1197', '85', '17000' );
INSERT INTO models VALUES (2,1, 'A2', '1999-11-01', '1390', '74', '16000' );
INSERT INTO models VALUES (3,1, 'Q8', '2017-01-09', '2995', '230', '65000' );

INSERT INTO models VALUES (4,2, 'X6', '2008-04-01', '2979', '302', '58000' );
INSERT INTO models VALUES (5,2, 'X5 F15', '2006-02-01', '2979', '302', '60000' );
INSERT INTO models VALUES (6,2, 'F90 M5', '2017-08-21', '4395', '591', '100000' );

INSERT INTO models VALUES (7,3, 'Twingo', '2012-03-01', '1149', '60', '10163' );
INSERT INTO models VALUES (8,3, 'Clio', '2012-09-01', '1461', '75', '10496' );
INSERT INTO models VALUES (9,3, 'Megane', '2015-09-01', '2385', '89', '25000' )

INSERT INTO extras VALUES (1,'KategoriaNev1', 'Név1', 500, 'blue', 1);
INSERT INTO extras VALUES (2,'KategoriaNev1', 'Név2', 300, 'white', 1);
INSERT INTO extras VALUES (3,'KategoriaNev2', 'Név3', 1000, 'metalgreen', 1);
INSERT INTO extras VALUES (4,'KategoriaNev2', 'Név4', 5000, 'violet', 1);
INSERT INTO extras VALUES (5,'KategoriaNev3', 'Név5', 200, 'matte blue', 0);
INSERT INTO extras VALUES (6,'KategoriaNev3', 'Név6', 100, 'no color', 0);

INSERT INTO modelExtraSwitch VALUES (1, 1, 1);
INSERT INTO modelExtraSwitch VALUES (2, 1, 2);
INSERT INTO modelExtraSwitch VALUES (3, 1, 3);
INSERT INTO modelExtraSwitch VALUES (4, 1, 4);
INSERT INTO modelExtraSwitch VALUES (5, 1, 5);
INSERT INTO modelExtraSwitch VALUES (6, 2, 6);
INSERT INTO modelExtraSwitch VALUES (7, 2, 1);
INSERT INTO modelExtraSwitch VALUES (8, 2, 2);
INSERT INTO modelExtraSwitch VALUES (9, 3, 3);
INSERT INTO modelExtraSwitch VALUES (10, 3, 4);
INSERT INTO modelExtraSwitch VALUES (11, 3, 5);
INSERT INTO modelExtraSwitch VALUES (12, 3, 6);
INSERT INTO modelExtraSwitch VALUES (13, 4, 1);
INSERT INTO modelExtraSwitch VALUES (14, 4, 2);
INSERT INTO modelExtraSwitch VALUES (15, 4, 3);
INSERT INTO modelExtraSwitch VALUES (16, 4, 4);
INSERT INTO modelExtraSwitch VALUES (17, 4, 5);
INSERT INTO modelExtraSwitch VALUES (18, 5, 6);
INSERT INTO modelExtraSwitch VALUES (19, 5, 1);
INSERT INTO modelExtraSwitch VALUES (20, 5, 2);
INSERT INTO modelExtraSwitch VALUES (21, 5, 3);
INSERT INTO modelExtraSwitch VALUES (22, 6, 4);
INSERT INTO modelExtraSwitch VALUES (23, 6, 5);
INSERT INTO modelExtraSwitch VALUES (24, 7, 6);
INSERT INTO modelExtraSwitch VALUES (25, 7, 1);
INSERT INTO modelExtraSwitch VALUES (26, 8, 2);
INSERT INTO modelExtraSwitch VALUES (27, 8, 3);
INSERT INTO modelExtraSwitch VALUES (28, 9, 4);
INSERT INTO modelExtraSwitch VALUES (29, 9, 5);
INSERT INTO modelExtraSwitch VALUES (30, 9, 6);






