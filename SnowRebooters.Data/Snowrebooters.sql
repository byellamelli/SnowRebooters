-- create payer table
CREATE TABLE dbo.payer (
    payerId int,
    name VARCHAR(200),
    email VARCHAR(1000),
    phone VARCHAR(50),
    addr1 VARCHAR(200),
    addr2 VARCHAR(200),
    city VARCHAR(200),
    state VARCHAR(2),
    zip VARCHAR(20)
PRIMARY KEY CLUSTERED);