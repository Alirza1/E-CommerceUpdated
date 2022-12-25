
create table [Admin]
(
	[Id]int primary key identity (1,1) not null,
	[Email]Nvarchar(100) not null,
	[UserName]Nvarchar(100) not null,
	[Password]Nvarchar(100) not null	
)

insert into [Admin](Email,UserName,[Password])
values
('omrcvnsrli@hotmail.com','cavanshirli','12345')


create table [User]
(
	[Id]int primary key identity (1,1) not null,
	[Email]Nvarchar(100) not null,
	[UserName]Nvarchar(100) not null,
	[Password]Nvarchar(100) not null
)

insert into [User](Email,UserName,[Password])
values
('nurlan@gmail.com','Nurlan','nurlan123'),
('mehemmed@gmail.com','Mehemmed','mehemmed123'),
('sevinc@gmail.com','sevinc','sevinc123')