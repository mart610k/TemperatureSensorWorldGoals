CREATE DATABASE WorldGoals;

USE WorldGoals;

CREATE TABLE Sensor(ID binary(16) primary key,`Name` varchar(32), MacAddress binary(6),IpAddress varchar(15), `description` varchar(150));

CREATE TABLE SensorType(ID int primary key auto_increment,SensorName varchar(16));

CREATE TABLE SensorReading(ID int primary key auto_increment, SensorID binary(16),SensorTypeID int, TimeRead Datetime,ValueRead float(2), foreign key (SensorID) references Sensor(ID),foreign key (SensorTypeID) references SensorType(ID));


CREATE TABLE CustomSensorLimit(SensorTypeID int, SensorID binary(16), UpperLimit float(2),LowerLimit float(2),primary key(SensorTypeID,SensorID), foreign key (SensorID) references Sensor(ID),foreign key (SensorTypeID) references SensorType(ID));


CREATE TABLE StandardSensorLimit(SensorTypeID int primary key, UpperLimit float(2),LowerLimit float(2), foreign key (SensorTypeID) references SensorType(ID));