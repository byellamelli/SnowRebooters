


DROP TABLE IF EXISTS dbo.payer;
CREATE TABLE dbo.payer (
    payerId int identity(1,1),
    name VARCHAR(200),
    email VARCHAR(1000),
    phone VARCHAR(50),
    addr1 VARCHAR(200),
    addr2 VARCHAR(200),
    city VARCHAR(200),
    state VARCHAR(2),
    zip VARCHAR(20)
PRIMARY KEY CLUSTERED);




DROP TABLE IF EXISTS dbo.payee;
CREATE TABLE dbo.payee (
    payerId int identity(1,1),
    name VARCHAR(200),
    email VARCHAR(1000),
    phone VARCHAR(50),
    addr1 VARCHAR(200),
    addr2 VARCHAR(200),
    city VARCHAR(200),
    state VARCHAR(2),
    zip VARCHAR(20)
PRIMARY KEY CLUSTERED);




DROP TABLE IF EXISTS dbo.images;
create table dbo.images (
	imageId int identity(1,1),
	image VARBINARY(MAX)
);




DROP TABLE IF EXISTS dbo.payments
create table dbo.payments (
	paymentId int identity(1,1),
	payerId int,
	payeeId int,
	amount numeric(10,2)
);




DROP TABLE IF EXISTS dbo.checks
create table dbo.checks (
	checkId int identity(1,1),
	paymentId int,
	checkNumber VARCHAR(50),
	amount numeric(10,2),
	dateIssued datetime,
	dateCleared datetime,
	issuedImageId int,
	clearedImageId int
);



DROP TABLE IF EXISTS dbo.paymentChecks;
create table dbo.paymentChecks (
	paymentId int,
	checkId int
);
