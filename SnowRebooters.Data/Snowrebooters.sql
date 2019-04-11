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

-- create payee table
CREATE TABLE dbo.payee (
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

create table dbo.images (
	imageId int,
	image VARBINARY(MAX)
);

create table dbo.payments (
	paymentId int,
	payerId int,
	payeeId int,
	amount numeric(10,2)
);

create table dbo.checks (
	checkId int,
	paymentId int,
	checkNumber VARCHAR(50),
	amount numeric(10,2),
	dateIssued datetime,
	dateCleared datetime,
	issuedImageId int,
	clearedImageId int
);

create table dbo.paymentChecks (
	paymentId int,
	checkId int
);
