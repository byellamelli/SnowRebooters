insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Tenley Wine and Liquor', 'jim@tenley.com', '545-165-5522', '4525 Wisconsin Ave Nw', 'Washington', 'DC', '20016');



insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Royal Liquors', 'suzy@royalliquor.com', '444-387-1928', '801 Southwest Blvd', 'Kansas City', 'MO', '64108');



insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Lukas Liquor Superstore', 'lukas@lukaslukas.com', '333-989-3737', '13657 Washington St', 'Kansas City', 'MO', '64145');



insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Still Liquor LLC', 'samba@stillliquor.com', '777-181-9999', '1524 Minor Ave', 'Seattle', 'WA', '98101');




insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Full Throttle Bottles', 'steve@fullthrottle.com', '555-222-1616', '5909 Airport Way S', 'Seattle', 'WA', '98108');



insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Charles Street Liquors', 'ron@charlesstreet.com', '373-292-1881', '143 Charles St', 'Boston', 'MA', '02114');



insert into dbo.payer
(name, email, phone, addr1, city, state, zip)
values
('Boston Wine Exchange', 'angela@bostonwine.com', '444-292-0205', '181 Devonshire St', 'Boston', 'MA', '02110');

---------------------------------------------


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Norge Cleaners', 'alex@norgeenfield.com', '646-225-0336', '37 Green Street', 'Enfield', 'CT', '06082');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Wax And Wane', 'julie@waxandwane.com', '666-321-6548', '234 Birch Hill Street', 'Irmo', 'SC', '29063');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Pett Putt', 'kisses@pettputt.com', '444-625-0052', '8726 Brookside Street', 'Amsterdam', 'NY', '12010');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Egg Drum Beat', 'rhonda@eggdrum.net', '444-777-1111', '36 N. 53rd Ave.', 'Westerville', 'OH', '43081');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Pizza Putz', 'andrew@pizzaputz.com', '333-548-8888', '48 Courtland Ave.', 'Kent', 'OH', '44240');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('Zo Zao Gym', 'efren@zozao.com', '888-999-1212', '65 Peachtree Dr.', 'Spartanburg', 'SC', '29301');


insert into dbo.payee
(name, email, phone, addr1, city, state, zip)
values
('', '', '', '', '', '', '');


insert into dbo.payments
(payerId, payeeId, amount)
values
(6,6,453.09);

insert into dbo.payments
(payerId, payeeId, amount)
values
(7,7,309.45);

insert into dbo.payments
(payerId, payeeId, amount)
values
(8,8,23.79);

insert into dbo.payments
(payerId, payeeId, amount)
values
(9,9,661.70);

insert into dbo.payments
(payerId, payeeId, amount)
values
(10,10,1305.12);

insert into dbo.payments
(payerId, payeeId, amount)
values
(11,11,781.44);

insert into dbo.payments
(payerId, payeeId, amount)
values
(12,11,47.55);

---------------------------------------------------------------------------------
-- checks
---------------------------------------------------------------------------------
insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(6, '520001', '2019-02-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(7, '520007', '2018-12-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(8, '520008', '2018-11-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(9, '520009', '2018-09-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(10, '520010', '2018-08-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(11, '520011', '2019-03-03');

insert into dbo.checks
(paymentId, checkNumber, dateIssued)
values
(12, '520012', '2019-01-03');

update dbo.checks set issuedImageId = 21 where checkId = 7;
update dbo.checks set issuedImageId = 20 where checkId = 8;
update dbo.checks set issuedImageId = 19 where checkId = 9;
update dbo.checks set issuedImageId = 18 where checkId = 10;
update dbo.checks set issuedImageId = 17 where checkId = 11;
update dbo.checks set issuedImageId = 16 where checkId = 12;
update dbo.checks set issuedImageId = 15 where checkId = 13;

update dbo.checks set amount = (select dbo.payments.amount from dbo.payments where dbo.payments.paymentId = dbo.checks.paymentId);

update dbo.checks set reviewCount = 0 where (reviewCount is NULL);













