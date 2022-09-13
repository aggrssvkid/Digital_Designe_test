CREATE TABLE public.Department (
	ID integer primary key not null,
  	NAME varchar(100) not null
);

insert into department (ID, NAME) values
(123, 'lol'),
(456, 'kek');


CREATE TABLE public.Employee (
	ID integer primary key not null,
	DEPARTMENT_ID integer references public.Department(ID),
	CHIEF_ID integer,
	NAME varchar(100) not null,
	SALARY integer
);

insert into employee (ID, department_id, chief_id, "name", salary) values
(01, 123, 777, 'Gennadiy makaroshki', 100),
(02, 123, 777, 'Petrovich kotletkin', 250),
(03, 123, 777, 'Vasek pyurehka', 375),
(04, 456, 777, 'Drug shefa', 50000),
(777, 456, 777, 'Shef', 100000);

alter table employee
add constraint kek
FOREIGN KEY (CHIEF_ID)
REFERENCES employee(ID)
