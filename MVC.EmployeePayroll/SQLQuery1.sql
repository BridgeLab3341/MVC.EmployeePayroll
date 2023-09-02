--Creating DataBase
Create Database MVC_EmployeePayroll;

--Creating Table 
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

--Altered the Table for Column
Alter Table EmployeeManagement Alter column ProfileImage VARCHAR(MAX);

--Stored Procedure for InsertEmployeeDetails
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

--Stored Procedure for GetAllEmployees
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

--Stored Procedure for Update Employee Details
Create or Alter Procedure SPUpdateEmployeeDeatils(
@EmployeeId Int,
@Name varchar(50),
@ProfileImage varchar(Max),
@Gender Varchar(10),
@Department VARCHAR(50),
@Salary MONEY,
@StartDate DATE,
@Notes VARCHAR(200)
)
As
Begin
Begin Try
Update EmployeeManagement Set Name=@Name,ProfileImage=@ProfileImage,Gender=@Gender,Department=@Department,
Salary=@Salary,StartDate=@StartDate,Notes=@Notes where EmployeeId = @EmployeeId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End

--Stored Procedure for Get Employee Details By Id
Create or Alter Procedure GetEmployeeDeatils(
@EmployeeId Int)
As
Begin
Begin Try
Select * from EmployeeManagement where EmployeeId=@EmployeeId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End

Create or Alter Procedure SPDeleteEmployee(
@EmployeeId Int)
As
Begin
Begin Try
Select * from EmployeeManagement where EmployeeId=@EmployeeId;
End Try
Begin Catch
Select ERROR_MESSAGE() as ErrorMessage;
End Catch;
End

