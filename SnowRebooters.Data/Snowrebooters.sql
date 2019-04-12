


DROP TABLE IF EXISTS dbo.payer;
CREATE TABLE dbo.payer (
    payerId int identity(1,1) not null,
    name VARCHAR(200),
    email VARCHAR(1000),
    phone VARCHAR(50),
    addr1 VARCHAR(200),
    addr2 VARCHAR(200),
    city VARCHAR(200),
    state VARCHAR(2),
    zip VARCHAR(20),
	CONSTRAINT PK_Payer_ID PRIMARY KEY CLUSTERED (payerId)
);





DROP TABLE IF EXISTS dbo.payee;
CREATE TABLE dbo.payee (
    payeeId int identity(1,1) not null,
    name VARCHAR(200),
    email VARCHAR(1000),
    phone VARCHAR(50),
    addr1 VARCHAR(200),
    addr2 VARCHAR(200),
    city VARCHAR(200),
    state VARCHAR(2),
    zip VARCHAR(20),
	CONSTRAINT PK_Payee_ID PRIMARY KEY CLUSTERED (payeeId)
);




DROP TABLE IF EXISTS dbo.images;
create table dbo.images (
	imageId int identity(1,1) not null,
	image VARBINARY(MAX),
	CONSTRAINT PK_Images_ImageID PRIMARY KEY CLUSTERED (imageId)
);




DROP TABLE IF EXISTS dbo.payments
create table dbo.payments (
	paymentId int identity(1,1) not null,
	payerId int,
	payeeId int,
	amount numeric(10,2),
	CONSTRAINT PK_Payments_PaymentID PRIMARY KEY CLUSTERED (paymentId)
);
GO
ALTER TABLE dbo.payments DROP CONSTRAINT FK_Payments_PayerId;
ALTER TABLE dbo.payments ADD CONSTRAINT FK_Payments_PayerId FOREIGN KEY (payerId) REFERENCES dbo.Payer (payerId);
GO
ALTER TABLE dbo.payments DROP CONSTRAINT FK_Payments_PayeeId;
ALTER TABLE dbo.payments ADD CONSTRAINT FK_Payments_PayeeId FOREIGN KEY (payeeId) REFERENCES dbo.Payee (payeeId);
GO




DROP TABLE IF EXISTS dbo.checks
create table dbo.checks (
	checkId int identity(1,1) not null,
	paymentId int,
	checkNumber VARCHAR(50),
	amount numeric(10,2),
	dateIssued datetime,
	dateCleared datetime,
	issuedImageId int,
	clearedImageId int,
	CONSTRAINT PK_Checks_CheckID PRIMARY KEY CLUSTERED (checkId)
);
GO
ALTER TABLE dbo.checks DROP CONSTRAINT FK_Checks_PaymentId;
GO
ALTER TABLE dbo.checks ADD CONSTRAINT FK_Checks_PaymentId FOREIGN KEY (paymentId) REFERENCES dbo.payments (paymentId);
GO
ALTER TABLE dbo.checks DROP CONSTRAINT FK_Checks_IssuedImageId;
GO
ALTER TABLE dbo.checks ADD CONSTRAINT FK_Checks_IssuedImageId FOREIGN KEY (issuedImageId) REFERENCES dbo.images (imageId);
GO
ALTER TABLE dbo.checks DROP CONSTRAINT FK_Checks_ClearedImageId;
GO
ALTER TABLE dbo.checks ADD CONSTRAINT FK_Checks_ClearedImageId FOREIGN KEY (clearedImageId) REFERENCES dbo.images (imageId);
GO






DROP TABLE IF EXISTS dbo.paymentChecks;
create table dbo.paymentChecks (
	paymentId int,
	checkId int
);
ALTER TABLE dbo.paymentChecks DROP CONSTRAINT FK_PaymentChecks_PaymentId;
GO
ALTER TABLE dbo.paymentChecks ADD CONSTRAINT FK_PaymentChecks_PaymentId FOREIGN KEY (paymentId) REFERENCES dbo.payments (paymentId);
GO
ALTER TABLE dbo.paymentChecks DROP CONSTRAINT FK_PaymentChecks_CheckId;
GO
ALTER TABLE dbo.paymentChecks ADD CONSTRAINT FK_PaymentChecks_CheckId FOREIGN KEY (checkId) REFERENCES dbo.checks (checkId);
GO
