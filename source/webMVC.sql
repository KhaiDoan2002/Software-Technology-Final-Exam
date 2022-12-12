CREATE DATABASE WEBMVC
GO
USE WEBMVC
GO

CREATE TABLE Manufacturer
(
	ManufacturerID VARCHAR(255) PRIMARY KEY,
	ManufacturerName VARCHAR(50),
	Address VARCHAR(100)
)

CREATE TABLE Goods
(
	GoodsId VARCHAR(255),
	GoodsUnit VARCHAR(50),
	GoodsName VARCHAR(50),
	GoodsPrice DECIMAL(13,2),
	PRIMARY KEY(GoodsId,GoodsUnit),
	ManufacturerID VARCHAR(255) FOREIGN KEY REFERENCES Manufacturer(ManufacturerID)
)

CREATE TABLE Accountant
(
	AccountantId VARCHAR(255) PRIMARY KEY,
	AccountantName VARCHAR(50),
	AccountantPassword VARCHAR(255),
	AccountantAge INT,
	AccountantAddress VARCHAR(100)
)

CREATE TABLE Agent
(
	AgentId VARCHAR(255) PRIMARY KEY,
	AgentName VARCHAR(50),
	AgentPassword VARCHAR(255),
	AgentAddress VARCHAR(100)
)

CREATE TABLE Imports
(
	AccountantId VARCHAR(255) FOREIGN KEY REFERENCES Accountant(AccountantId),
	GoodsId VARCHAR(255) not null,
	GoodsUnit VARCHAR(50) not null,
	FOREIGN KEY (GoodsId, GoodsUnit) REFERENCES Goods(GoodsId,GoodsUnit), 
	Quantity INT,
	TotalPrice DECIMAL(13,2),
	ImportDate DATE,
	primary key(AccountantId, GoodsId, GoodsUnit, ImportDate)
)

CREATE TABLE Orders
(
	AgentId VARCHAR(255) FOREIGN KEY REFERENCES Agent(AgentId),
	GoodsId VARCHAR(255) not null,
	GoodsUnit VARCHAR(50) not null,
	FOREIGN KEY(GoodsId, GoodsUnit) REFERENCES Goods(GoodsId,GoodsUnit),
	Quantity INT,
	TotalPrice DECIMAL(13,2),
	OrderDate DATE,
	chargeState VARCHAR(13),
	deliveryState VARCHAR(13)
	primary key(AgentId, GoodsId, GoodsUnit,OrderDate)
)

Create table warehouse
(
	GoodsId VARCHAR(255) not null,
	GoodsUnit VARCHAR(50) not null,
	FOREIGN KEY(GoodsId, GoodsUnit) REFERENCES Goods(GoodsId,GoodsUnit),
	Quantity INT,
	primary key(GoodsId, GoodsUnit)
)

insert into Manufacturer values 
('JP','Japana','Japan'),
('HTG','Huong Thao Group','Ha Noi'),
('LG','Life Gift','Ho Chi Minh'),
('LFT','La Terra France','France'),
('MA','Mediphar USA','United States'),
('PA','Pharmedic','Ho Chi Minh'),
('SPM','Saigon Pharma','Ho Chi Minh')

insert into Goods values
('SJA','Blister Pack','Spirulina Japan Algae',5.0,'JP'),
('GH','Container','GH Creation',6.5,'HTG'),
('DHC','Container','DHC Japan',7.3,'LG'),
('FJ','Container','Fine',2.0,'LFT'),
('ORH','Blister Pack','Orihiro',4.0,'MA'),
('ADN','Container','Asahi Dear Natura',6.0,'PA'),
('FJP','Blister Pack','Fine Japan Nattokinase',3.4,'SPM')

insert into Accountant values 
('AC1','Ho Tuan Kiet','123456',23,'Ho Chi Minh'),
('AC2','Alexander Lisandro','123456',26,'England'),
('AC3','Tran Van Nghia','123456',45,'Hai Phong'),
('AC4','Nguyen Thi Thao','123456',34,'Thai Binh'),
('AC5','Ho Thi Tuyet Dung','123456',40,'Nha Trang'),
('AC6','Tran Gia Vi','123456',29,'Ho Chi Minh'),
('AC7','Hang Thi Nga','123456',26,'Ha Noi')

insert into Agent values
('AG1','Naso Company','123456','Ho Chi Minh'),
('AG2','Edwin Company','54u34hu','Ha Noi'),
('AG3','Laphonso','fejf3u4','Hai Phong'),
('AG4','Malibu','f34bfye','American'),
('AG5','Akito','34ffu4f','Japan'),
('AG6','Transchamp','43fb4fr','France'),
('AG7','Becamex','154545444','Thailand')


select * from Accountant 
select * from Goods
select * from Manufacturer
select * from Agent
select * from Orders
select * from Imports
select * from warehouse
