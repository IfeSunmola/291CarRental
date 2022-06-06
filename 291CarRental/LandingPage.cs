using System.Data;
using System.Data.SqlClient;

namespace _291CarRental
{
    public partial class LandingPage : Form
    {
		private const String connectionString = "Server = INCOMINGVIRUSPC\\SQLEXPRESS; Database = CarRental; Trusted_Connection = yes;";
		//private const String connectionString = "Server=n6f5t50mloyw.us-east-3.psdb.cloud;Database=291carrental; Trusted_Connection = yes;";
		private SqlConnection? connection ;
        private SqlCommand? command;
        private SqlDataReader? reader;
        
        public LandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            empIdLabel.Visible = false;
            empIdTextbox.Visible = false;
            empLoginButton.Visible = false;

            planetScale_createTable();
			planetScale_insert();
        }


        private void planetScale_createTable()
        {
            String dropTables = @"DROP TABLE IF EXISTS Rental;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS Vehicle_Class;
DROP TABLE IF EXISTS Branch;";

            String createBranch = @"CREATE TABLE Branch(
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
);";

            String createEmployee = @"CREATE TABLE Employee(
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
);";

            String createVehicleClass = @"CREATE TABLE Vehicle_Class(
	vehicle_class_id INT IDENTITY (1, 1) PRIMARY KEY,
	vehicle_class VARCHAR(20) NOT NULL, -- add unique later
	CHECK (vehicle_class IN ('Car', 'SUV', 'Convertible', 'Luxury')),
	daily_rate SMALLMONEY NOT NULL,
	weekly_rate SMALLMONEY NOT NULL,
	monthly_rate SMALLMONEY NOT NULL,
	change_branch_fee SMALLMONEY NOT NULL,
	late_fee SMALLMONEY NOT NULL,
);";

            String createVehicle = @"CREATE TABLE Vehicle (
	vehicle_id INT IDENTITY (1, 1) PRIMARY KEY,

	plate_number VARCHAR (8) NOT NULL UNIQUE, -- change to be more accurate
	CHECK (LEN(plate_number) = 8),

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
);";

            String createCustomer = @"CREATE TABLE Customer(
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
	--previous_rental INT NOT NULL REFERENCES Rental
);";

            String createRental = @"CREATE TABLE Rental(
	rental_id INT IDENTITY (1, 1) PRIMARY KEY,
	start_date_of_booking DATE NOT NULL,
	expected_dropoff_date DATE NOT NULL,
	actual_dropoff_date DATE,
	total_mileage_used INT,
	amount_due_now SMALLMONEY NOT NULL,
	extra_charges SMALLMONEY,
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
	vehicle_id INT NOT NULL REFERENCES Vehicle,
	vehicle_class_requested INT NOT NULL REFERENCES Vehicle_Class,
	customer_id INT NOT NULL REFERENCES Customer,
);";

            String query = dropTables + createBranch + createEmployee + createVehicleClass + 
				createVehicle + createCustomer + createRental;


			using (connection = new SqlConnection(connectionString))
            using (command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

		private void planetScale_insert()
        {
			String branchInsert = @"INSERT INTO Branch VALUES 
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
);";
			
			String employeeInsert = @"INSERT INTO Employee VALUES 
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
);";
			
			String vehicleClassInsert = @"INSERT INTO Vehicle_Class VALUES 
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
);";
			
			String vehicleInsert = @"----------------------------------------- Branch 1.
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

----------------------------------------- Branch 2
-- Cars
INSERT INTO Vehicle VALUES
('U8V-X1N4', 2021, 'Kia', 'Forte', 'Automatic', 5, 15000, 'Blue', 2, 1
);

INSERT INTO Vehicle VALUES
('T5E-O4H4', 2018, 'Volkwagen', 'Jetta', 'Automatic', 5, 63400, 'Black', 2, 1
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

----------------------------------------- Branch 3
-- Cars
INSERT INTO Vehicle VALUES
('H4K-L5Z0', 2019, 'Toyota', 'Camry', 'Automatic', 5, 55400, 'Silver', 3, 1
);

INSERT INTO Vehicle VALUES
('B9J-Z7S2', 2019, 'Kia', 'Rio', 'Automatic', 4, 30901, 'Black', 3, 1
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
----------------------------------------- Branch 4
-- Cars
INSERT INTO Vehicle VALUES
('V5W-L3J5', 2021, 'Toyota', 'Corolla', 'Automatic', 5, 19500, 'Silver', 4, 1
);

INSERT INTO Vehicle VALUES
('K5C-D0M3', 2019, 'Hyundai', 'Sonata', 'Automatic', 5, 32012, 'Blue', 4, 001
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
);";
			
			String customerInsert = @"INSERT INTO Customer
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
'072', 'Schiller Forge', 'Velmaville', 'PE', 'X6B 6L6');";
			
			String rentalInsert = @"-- Rentals
INSERT INTO Rental 
(start_date_of_booking, expected_dropoff_date, amount_due_now, emp_id_booking,
pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)
VALUES
('2022-06-10', '2022-06-21', 130, 002, 003, 2, 1, 1);

INSERT INTO Rental 
(start_date_of_booking, expected_dropoff_date, amount_due_now, emp_id_booking,
pickup_branch_id, vehicle_id, vehicle_class_requested, customer_id)
VALUES
('2022-06-14', '2022-06-30', 240, 004, 004, 3, 3, 3);";

			String query = branchInsert + employeeInsert + vehicleClassInsert + vehicleInsert + 
				customerInsert + rentalInsert;
			using (connection = new SqlConnection(connectionString))
			using (command = new SqlCommand(query, connection))
			{
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
        private void custButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new CustSelectVehicleFilters(this).ShowDialog();
        }

        private void empButton_Click(object sender, EventArgs e)
        {
            empIdLabel.Visible = true;
            empIdTextbox.Visible = true;
            empLoginButton.Visible = true;
        }

        private void empLoginButton_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(empIdTextbox.Text))// empty text box
            {
                errorMessageLabel.Text = "ID CANNOT BE EMPTY";
                errorMessageLabel.Visible = true;
            }
            else
            {
                String query = "SELECT emp_id FROM Employee WHERE emp_id = " + empIdTextbox.Text + ";";
                using (connection = new SqlConnection(connectionString))
                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var empId = command.ExecuteScalar();
                    if (empId != null)
                    {// not null means a value was returned, value will only be returned if the emp_id was found
                        MessageBox.Show("LOGIN SUCCESSFULL", "ID FOUND");
                        this.Visible = false;
                        errorMessageLabel.Visible = false;
                        new EmployeeLandingPage(this, empId.ToString()).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found, try again", "INCORRECT ID");
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmExit = MessageBox.Show(
                "Are you sure you want to exit the application?" +
                "\nAny unsaved information will be lost".ToUpper(),
                "CONFIRM EXIT",
                MessageBoxButtons.YesNo);
            if (confirmExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // this method make the employee id textbox only accept numbers
        // copy and paste won't work because Shortcuts are disabled
        private void empIdTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}