Create Database MVC_EmployeePayroll;

CREATE TABLE EmployeeManagement(
	EmployeeId INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50),
	ProfileImage VARBINARY(MAX),
	Gender varchar(10),
	Department VARCHAR(50),
	Salary MONEY,
	StartDate DATE,
	Notes VARCHAR(200)
	);
Alter Table EmployeeManagement Alter column ProfileImage VARCHAR(MAX);

select * from EmployeeManagement;

Create or Alter Procedure InsertEmployeeData
@Name varchar(50),
@ProfileImage varchar(Max),
@Gender Varchar(10),
@Department VARCHAR(50),
@Salary MONEY,
@StartDate DATE,
@Notes VARCHAR(200)
As
Begin
Begin Try 
Insert into EmployeeManagement (Name,ProfileImage,Gender,Department,Salary,StartDate,Notes)
Values(@Name,@ProfileImage,@Gender,@Department,@Salary,@StartDate,@Notes);
End Try
Begin Catch
SELECT ERROR_MESSAGE() AS ErrorMessage;
End Catch;
End;

Create or Alter Procedure GetAllEmployees
As
Begin
Begin Try 
Select * from EmployeeManagement;
End Try
Begin Catch
SELECT ERROR_MESSAGE() AS ErrorMessage;
End Catch;
End;

select * from EmployeeManagement;