USE [CarRental];
INSERT INTO Branch VALUES 
('Edmonton', '16A', '1200', 'Avatar Street', 'Edmonton', 'AB', 'T1W 1SA', '587', '0921288', '2018-01-24'
);

INSERT INTO Branch VALUES 
('Toronto', NULL, '1655', 'Beifong Street SW', 'Toronto', 'ON', 'M1A 2TA', '416', '9104011', '2021-01-24'
);

INSERT INTO Branch VALUES 
('Montreal', '55A', '125', 'Flying bison Ave', 'Montreal', 'QC', 'X45 51A', '514', '1569322', '2017-01-24'
);

INSERT INTO Branch VALUES 
('Winnipeg', NULL, '100', 'Cabbages Street', 'Winnipeg', 'MB', 'R3T A2X', '431', '8331022', '2020-11-04'
);


/*
INSERT INTO Branch VALUES 
('Vancouver', '12F', '900', 'Kyoshi Island', 'Vancouver', 'BC', 'V2C B1X', '604', '3910345', '2022-01-15'
);

INSERT INTO Branch VALUES 
('Halifax', '100C', '1900', 'Suki Avenue', 'Halifax', 'NS', 'H2N F4S', '782', '4819164', '2018-03-29'
);

INSERT INTO Branch VALUES 
('Regina', NULL, '590', 'Waterman Street', 'Regina', 'SK', 'R2S S1K', '306', '2903811', '2019-05-14'
);

INSERT INTO Branch VALUES 
('ST. John''s', '12', '2012', 'Bender Road', 'St. John''s', 'NL', 'N9S J5S', '709', '9401229', '2021-12-19'
);

INSERT INTO Branch VALUES 
('Charlottetown', NULL, '19C', 'Fire Breather Road', 'Charlottetown', 'PE', 'C8E E3A', '902', '3015400', '2019-06-30'
);

INSERT INTO Branch VALUES 
('Fredericton', '200B', '16', 'Earth King Avenue', 'Frederiction', 'NB', 'F4B R9N', '506', '1049013', '2020-10-21'
);

INSERT INTO Branch VALUES 
('Yellowknife', NULL, '111', 'Hog monkey Street', 'Yellowknife', 'NT', 'Y3T P1V', '867', '9202799', '2018-01-11'
); 
*/


INSERT INTO Employee VALUES 
('Daniella', 'Monroe', 'daniellamonroe@gmail.com', 'Female', '587', '9208421', NULL, '223',
'Farmerville Ave', 'Edmonton', 'AB', 'ASX 123', 001
);

INSERT INTO Employee VALUES
('Cynthia', 'Nieman', 'cynthianieman@gmail.com', 'Female', '416', '4900691', NULL, '269', 
'Victoria Park Ave', 'Toronto', 'ON', 'M2J 3T7', 002
);

INSERT INTO Employee VALUES 
('Eduardo', 'Herod', 'eduardoherod@gmail.com', 'Male', '662', '1821943', NULL, '4693',
'Blanshard Street', 'Victoria', 'BC', 'V8W 2H9', 003
);

INSERT INTO Employee VALUES 
('Lily', 'Benjamin', 'lilybenjamin@gmail.com', 'Female', '488', '1296621', NULL, '4403',
'De la Providence Avenue', 'Buckingham', 'QC', 'J8L 1P1', 004
);

/*
INSERT INTO Employee VALUES 
('Aaron', 'Reilly', 'aaronreilly@gmail.com', 'Male', '613', '5631952', NULL, '4002',
'MacLaren Street', 'Ottawa', 'ON', 'K1P 5M7', 005
);

INSERT INTO Employee VALUES 
('Wendell', 'Gee', 'wendellgee@gmail.com', 'Male', '760', '5521121', NULL, '763',
'Benton Street', 'Kitchener', 'ON', 'N2G 4L9', 006
);

INSERT INTO Employee VALUES 
('Emery', 'Greene', 'emerygreene@gmail.com', 'Male', '250', '7259557', NULL, '455',
'Scotts Lane', 'Kitchner', 'ON', 'V0R 2Z0', 007
);

INSERT INTO Employee VALUES 
('Gail', 'Couey', 'gailcouey@gmail.com', 'Female', '587', '11940442', '18A', '1922',
'Big headed Street', 'Kitchner', 'ON', 'K1P 5M7', 008
);

INSERT INTO Employee VALUES 
('Herbert', 'Schmidt', 'herbertschmidt@gmail.com', 'Male', '418', '6590780', NULL, '2387',
'Rue', 'Garneau', 'QC', 'G1V 3V5', 009
);

INSERT INTO Employee VALUES 
('Jillian', 'Comer', 'jilliancomer@gmail.com', 'Female', '276', '2012599', NULL, '1448',
'Eglinton Avenue', 'Toronto', 'ON', 'M4P 1A6', 010
);

INSERT INTO Employee VALUES 
('Jared', 'Davis', 'jareddavis@gmail.com', 'Male', '350', '5731078', '12C', '99',
'Parker Street', 'Winnipeg', 'MB', 'R3T 2A5', 011
);
*/


INSERT INTO Vehicle_Class VALUES 
('Car', 35.99, 90.99, 150.99, 20.00, 30.00
);

INSERT INTO Vehicle_Class VALUES 
('SUV', 70.99, 120.99, 190.99, 40.00, 50.00
);

INSERT INTO Vehicle_Class VALUES 
('Convertible', 120.99, 220.99, 390.99, 60.00, 80.00
);

INSERT INTO Vehicle_Class VALUES 
('Luxury', 200.99, 290.99, 490.99, 100.00, 120.00
);

----------------------------------------- Branch 1.
-- Cars
INSERT INTO Vehicle VALUES
('F9I-Y6D3', 2021, 'Chevrolet', 'Spark', 'Automatic', 4, 20000, 'Black', 1, 1
);

INSERT INTO Vehicle VALUES
('E3P-N6M1', 2020, 'Nissan', 'Versa', 'Automatic', 5, 12000, 'White', 1, 1
);

-- SUVs
INSERT INTO Vehicle VALUES
('L8F-D7G2', 2021, 'Toyota', 'RAV4', 'Automatic', 5, 20000, 'Silver', 1, 2
);

INSERT INTO Vehicle VALUES
('P4B-G6S2', 2020, 'Hyundai', 'Kona', 'Automatic', 5, 31000, 'Blue', 1, 2
);

-- Convertibles
INSERT INTO Vehicle VALUES
('G4D-L1X4', 2022, 'Mazda', 'MX-5 Miata', 'Hybrid', 2, 5000, 'White', 1, 3
);
 
INSERT INTO Vehicle VALUES
('M6M-A5H0', 2022, 'Ford', 'Mustang', 'Hybrid', 2, 3000, 'Red', 1, 3
);

-- Luxury
INSERT INTO Vehicle VALUES
('C3F-P4F1', 2022,	'Mercedes',	'E-Class', 'Manual', 3,	900, 'White', 1, 4
);
----------------------------------------- Branch 2
-- Cars
INSERT INTO Vehicle VALUES
('U8V-X1N4', 2021, 'Kia', 'Forte', 'Automatic', 5, 15000, 'Blue', 2, 1
);

INSERT INTO Vehicle VALUES
('T5E-O4H4', 2020, 'Volkwagen', 'Jetta', 'Automatic', 5, 63400, 'Black', 2, 1
);

-- SUVs
INSERT INTO Vehicle VALUES
('R3M-T6I4', 2022, 'Ford', 'Edge', 'Automatic', 5, 5000, 'Black', 2, 2
);

INSERT INTO Vehicle VALUES
('V5S-M8B7', 2021, 'Dodge', 'Durango', 'Automatic', 5, 13000, 'Red', 2, 2
);

-- Convertibles
INSERT INTO Vehicle VALUES
('D7V-H3K9', 2022, 'Chevrolet', 'Camaro', 'Manual', 4, 3000, 'Grey', 2, 3
);

INSERT INTO Vehicle VALUES
('R8V-S8O9', 2022, 'BMW', 'Z4', 'Hybrid', 2, 4000, 'Black', 2, 3
);

-- Luxury
INSERT INTO Vehicle VALUES
('S9F-L3V1', 2022, 'BMW', '5-Series', 'Hybrid', 4, 1000, 'Black', 2, 4
);

----------------------------------------- Branch 3
-- Cars
INSERT INTO Vehicle VALUES
('H4K-L5Z0', 2020, 'Toyota', 'Camry', 'Automatic', 5, 55400, 'Silver', 3, 1
);

INSERT INTO Vehicle VALUES
('B9J-Z7S2', 2020, 'Kia', 'Rio', 'Automatic', 4, 30901, 'Black', 3, 1
);

-- SUVs
INSERT INTO Vehicle VALUES
('L8K-N6V7', 2022, 'Nissan', 'Rogue', 'Automatic', 5, 10043, 'Black', 3, 2
);

INSERT INTO Vehicle VALUES
('Q6D-G5H9', 2020, 'Jeep', 'Wrangler', 'Automatic', 5, 21231, 'Black', 3, 2
);
-- Convertibles
INSERT INTO Vehicle VALUES
('B0H-B5I1', 2022, 'Chevrolet', 'Camaro ZL1', 'Hybrid', 2, 8000, 'Light Blue', 3, 3
);

INSERT INTO Vehicle VALUES
('P6C-C0I9', 2022, 'Mercedes', 'AMG C43', 'Manual', 2, 4000, 'Black', 3, 3
);

-- Luxury
INSERT INTO Vehicle VALUES
('D4R-L2N4', 2022, 'BMW','2-Series', 'Hybrid', 4, 1200, 'Black', 3, 4
);

----------------------------------------- Branch 4
-- Cars
INSERT INTO Vehicle VALUES
('V5W-L3J5', 2021, 'Toyota', 'Corolla', 'Automatic', 5, 19500, 'Silver', 4, 1
);

INSERT INTO Vehicle VALUES
('K5C-D0M3', 2020, 'Hyundai', 'Sonata', 'Automatic', 5, 32012, 'Blue', 4, 001
);

-- SUVs
INSERT INTO Vehicle VALUES
('C4L-Q2Y3', 2021, 'Hyundai', 'Santa Fe', 'Automatic', 5, 20500, 'Silver', 4, 2
);

INSERT INTO Vehicle VALUES
('B8F-F5Q4', 2022, 'Hyundai', 'Tucson', 'Automatic', 5, 10000, 'Black', 4, 2
);

-- Convertibles
INSERT INTO Vehicle VALUES
('E2P-I8T9', 2022, 'Chevrolet', 'Corvette', 'Manual', 2, 6000, 'Yellow', 4, 3
);

INSERT INTO Vehicle VALUES
('E2R-X4E8', 2022, 'Porsche', '718 Boxster', 'Manual', 2, 5400, 'Red', 4, 3
);

-- Luxury
INSERT INTO Vehicle VALUES
('V2B-T9N1', 2021, 'Mercedes', 'C-Class', 'Hybrid', 2, 6122, 'White', 4, 4
);

-- Customers
INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
('Wayne', 'Fire', 'waynefire@gmail.com', '1991-08-22', 'Female', '12139748', '204', '1249022', '097',
'4506', 'Gillian Rue', 'Lake Norberto', 'NB', 'E2G 8X2');

INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
('Paavo', 'Nurmi', 'paavonurmi@gmail.com', '1985-07-26', 'Male', '97632345', '394', '7842912', '738',
'07673 ', 'Casper Mountain', 'New Glen', 'ON', 'E2S 0E5');

INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
('Todd', 'Howells', 'toddhowells@gmail.com', '1995-04-11', 'Male', '30275392', '820', '2699593', '431',
'5792', 'Mohr Groves', 'New Aida', 'BC', 'P1P 7Z0');

INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
('Alexandra', 'Daddario', 'alexandradaddario@gmail.com', '1989-01-09', 'Female', '39027302', '242', '1908527', '121',
'072', 'Schiller Forge', 'Velmaville', 'PE', 'X6B 6L6');


INSERT INTO Customer
(first_name, last_name, email, date_of_birth, gender, driver_license_no, area_code, phone_number, unit_number, street_number,
street_name, city, province, postal_code)
VALUES
('Daniel', 'Fighter', 'danielfighter@gmail.com', '1989-01-10', 'Male', '39027302', '422', '1938427', '121',
'072', 'Schiller Forge', 'Velmaville', 'PE', 'X6B 6L6');

-- Rentals
--INSERT INTO Rental 
--(start_date, expected_dropoff_date, amount_due_now, emp_id_booking,
--pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)
--VALUES
--('2022-06-10', '2022-06-21', 130, 002, 003, 2, 1, 1);

--INSERT INTO Rental 
--(start_date, expected_dropoff_date, amount_due_now, emp_id_booking,
--pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)
--VALUES
--('2022-06-14', '2022-06-30', 240, 004, 004, 3, 3, 3);