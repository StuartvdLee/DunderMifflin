-- Run after 00_DunderMifflinSchema.pgsql
SET search_path = dm, public;absolute/path/to

COPY categories        FROM 'absolute/path/to/DataFiles/Categories.txt'        WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY suppliers         FROM 'absolute/path/to/DataFiles/Suppliers.txt'         WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY shippers          FROM 'absolute/path/to/DataFiles/Shippers.txt'          WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY regions           FROM 'absolute/path/to/DataFiles/Regions.txt'           WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY employeestatus    FROM 'absolute/path/to/DataFiles/EmployeeStatus.txt'    WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY customers         FROM 'absolute/path/to/DataFiles/Customers.txt'         WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY employees         FROM 'absolute/path/to/DataFiles/Employees.txt'         WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY products          FROM 'absolute/path/to/DataFiles/Products.txt'          WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY orders            FROM 'absolute/path/to/DataFiles/Orders1.txt'           WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false, ENCODING 'WIN1252'); -- Lazy solution for encoding
COPY orders            FROM 'absolute/path/to/DataFiles/Orders2.txt'           WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false, ENCODING 'WIN1252'); -- Lazy solution for encoding
COPY orderdetails      FROM 'absolute/path/to/DataFiles/OrderDetails1.txt'     WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
COPY orderdetails      FROM 'absolute/path/to/DataFiles/OrderDetails2.txt'     WITH (FORMAT csv, DELIMITER '|', NULL '', HEADER false);
