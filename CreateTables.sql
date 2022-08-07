USE [CarRental];
DROP TABLE IF EXISTS Rental;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS Vehicle_Class;
DROP TABLE IF EXISTS Branch;

CREATE TABLE Branch(
	branch_id INT IDENTITY (1, 1) PRIMARY KEY,
	branch_name VARCHAR(20) NOT NULL,
	unit_number VARCHAR (10),
	street_number VARCHAR (10) NOT NULL,
	street_name VARCHAR(50) NOT NULL,
	city VARCHAR(20) NOT NULL,
	province CHAR(2) NOT NULL,
	CHECK (province IN ('NL', 'PE', 'NS', 'NB', 'QC', 'ON', 'MB', 'SK', 'AB', 'BC', 'NT')),
	postal_code CHAR(7) NOT NULL, -- format: XXX XXX
	area_code CHAR (3) NOT NULL,
	CHECK (LEN(area_code) = 3),
	phone_number CHAR (7) NOT NULL,
	CHECK (LEN(phone_number) = 7),
	CONSTRAINT b_unique_number UNIQUE (area_code, phone_number),
	date_opened DATE NOT NULL,
);

CREATE TABLE Employee(
	emp_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR(20) NOT NULL,
	last_name VARCHAR(20) NOT NULL,
	email VARCHAR(30) NOT NULL UNIQUE,
	gender VARCHAR (20) NOT NULL,
	area_code CHAR (3) NOT NULL,
	CHECK (LEN(area_code) = 3),
	phone_number CHAR (7) NOT NULL,
	CHECK (LEN(phone_number) = 7),
	CONSTRAINT e_unique_number UNIQUE (area_code, phone_number),
	unit_number VARCHAR (10),
	street_number VARCHAR (10) NOT NULL,
	street_name VARCHAR(50) NOT NULL,
	city VARCHAR(15) NOT NULL,
	province CHAR(2) NOT NULL,
	CHECK (province IN ('NL', 'PE', 'NS', 'NB', 'QC', 'ON', 'MB', 'SK', 'AB', 'BC', 'NT')),
	postal_code CHAR(7) NOT NULL,
	branch_id INT NOT NULL REFERENCES Branch
);

CREATE TABLE Vehicle_Class(
	vehicle_class_id INT IDENTITY (1, 1) PRIMARY KEY,
	vehicle_class VARCHAR(20) NOT NULL, -- add unique later
	CHECK (vehicle_class IN ('Car', 'SUV', 'Convertible', 'Luxury')),
	daily_rate SMALLMONEY NOT NULL,
	weekly_rate SMALLMONEY NOT NULL,
	monthly_rate SMALLMONEY NOT NULL,
	change_branch_fee SMALLMONEY NOT NULL,
	late_fee SMALLMONEY NOT NULL,
);

CREATE TABLE Vehicle ( -- add on delete cascade -- chapter 4 page 31
	vehicle_id INT IDENTITY (1, 1) PRIMARY KEY,

	plate_number VARCHAR (8) NOT NULL UNIQUE, -- change to be more accurate
	CHECK (LEN(plate_number) = 8),
	CHECK (plate_number LIKE '[A-Z][0-9][A-Z]-[A-Z][0-9][A-Z][0-9]'),

	[year] SMALLINT NOT NULL, -- change
	CHECK (year BETWEEN 1970 AND 2022),

	brand VARCHAR (10) NOT NULL,
	model VARCHAR(15) NOT NULL,
	transmission_type VARCHAR (10) NOT NULL,
	CHECK (transmission_type IN ('Automatic', 'Manual', 'Hybrid')),
	
	num_seats SMALLINT NOT NULL,
	CHECK (num_seats BETWEEN 2 AND 8),

	current_mileage INT NOT NULL,
	CHECK (current_mileage BETWEEN 0 AND 500000),

	color VARCHAR(10) NOT NULL,
	branch_id INT NOT NULL REFERENCES Branch,
	vehicle_class_id INT NOT NULL REFERENCES Vehicle_Class
);

CREATE TABLE Customer(
	customer_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR(20) NOT NULL,
	last_name VARCHAR(20) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	date_of_birth DATE NOT NULL,
	gender VARCHAR (20) NOT NULL,
	driver_license_no CHAR(8) NOT NULL,
	CHECK (LEN(driver_license_no) = 8),
	area_code CHAR (3) NOT NULL,
	CHECK (LEN(area_code) = 3),
	phone_number CHAR (7) NOT NULL,
	CHECK (LEN(phone_number) = 7),
	CONSTRAINT c_unique_number UNIQUE (area_code, phone_number),
	unit_number VARCHAR (10),
	street_number VARCHAR (10) NOT NULL,
	street_name VARCHAR(50) NOT NULL,
	city VARCHAR(15) NOT NULL,
	province CHAR(2) NOT NULL,
	CHECK (province IN ('NL', 'PE', 'NS', 'NB', 'QC', 'ON', 'MB', 'SK', 'AB', 'BC', 'NT')),
	postal_code CHAR(7) NOT NULL, -- XXX AAA
	date_registered DATE DEFAULT GETDATE(),
	membership_type VARCHAR(10) DEFAULT 'Bronze',
	CHECK (membership_type IN ('Bronze', 'Gold')),
	gold_membership_date Date
	--previous_rental INT NOT NULL REFERENCES Rental
);

CREATE TABLE Rental(
	rental_id INT IDENTITY (1, 1) PRIMARY KEY,
	[start_date] DATE NOT NULL,
	expected_dropoff_date DATE NOT NULL,
	actual_dropoff_date DATE,
	total_mileage_used INT,
	initial_amount_paid SMALLMONEY NOT NULL,
	late_fee SMALLMONEY, 
	different_branch_fee SMALLMONEY, 
	--extra_charges SMALLMONEY,
	--estimated_cost = initial_amount_paid
	-- Can get total_amount_paid by adding amount_due_now + extra_charges
	--estimated_cost SMALLMONEY NOT NULL,
	--actual_cost SMALLMONEY,
	--initial_amount_paid SMALLMONEY NOT NULL, -- customer has to pay something before taking the car
	-- total_amount_paid SMALLMONEY,
	emp_id_booking INT NOT NULL REFERENCES Employee,
	emp_id_return INT REFERENCES Employee,
	pickup_branch_id INT NOT NULL REFERENCES Branch,
	dropoff_branch_id INT REFERENCES Branch,
	vehicle_id INT REFERENCES Vehicle ON DELETE SET NULL,
	vehicle_class_requested INT NOT NULL REFERENCES Vehicle_Class,
	customer_id INT NOT NULL REFERENCES Customer,
);

-- on delete cascade
