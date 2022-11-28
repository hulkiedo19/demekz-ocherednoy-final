# dima_pozarnik

# sql

create table Department
(
	Id int primary key identity,
	EmployeeCount int not null,
	DepartmentName nvarchar(max) not null
);

create table Equipment
(
	Id int primary key identity,
	EquipmentCount int not null,
	EquipmentType nvarchar(max) not null
);
