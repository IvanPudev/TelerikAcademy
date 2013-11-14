--1. Write a SQL query to find the names and salaries of the employees
--that take the minimal salary in the company. Use a nested SELECT statement.

SELECT
	FirstName,
	LastName,
	Salary
FROM Employees
WHERE Salary = (SELECT
	MIN(Salary)
FROM Employees)
GO

--2. Write a SQL query to find the names and salaries of the employees
--that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT
	FirstName,
	LastName,
	Salary
FROM Employees
WHERE Salary > (SELECT
	MIN(Salary)
FROM Employees)
AND
Salary <= (SELECT
	MIN(Salary) * 1.10
FROM Employees)
GO

--3. Write a SQL query to find the full name, salary and department of
--the employees that take the minimal salary in their department.
--Use a nested SELECT statement.

SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	e.Salary,
	d.Name AS DepartmentNAme
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT
	MIN(Salary)
FROM Employees
WHERE DepartmentID = d.DepartmentID)
GO

--4. Write a SQL query to find the average 
--salary in the department #1.

SELECT
	AVG(Salary) AS AvarageSalary
FROM Employees
WHERE DepartmentID = 1
GO

--5. Write a SQL query to find the average 
--salary  in the "Sales" department.

SELECT
	AVG(Salary) AS AvarageSalary
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GO
--6. Write a SQL query to find the number 
--of employees in the "Sales" department.

SELECT
	COUNT(*)
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GO

--7. Write a SQL query to find the number of 
--all employees that have manager.

SELECT
	COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL

--8. Write a SQL query to find the number of all 
--employees that have no manager.

SELECT
	COUNT(*)
FROM Employees
WHERE ManagerID IS NULL
GO

--9. Write a SQL query to find all departments and the 
--average salary for each of them.

SELECT
	d.Name AS Department,
	AVG(e.Salary) AS AverageSalary
FROM Departments d
INNER JOIN Employees e
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
GO

--10. Write a SQL query to find the count of all employees 
--in each department and for each town.

SELECT
	COUNT(*) AS EmployeesCount,
	d.Name AS DepartmentName,
	t.Name AS TownName
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY	d.Name,
			t.Name
ORDER BY d.Name, t.Name DESC
GO

--11. Write a SQL query to find all managers that have exactly
--5 employees. Display their first name and last name.

SELECT
	m.FirstName,
	m.LastName,
	COUNT(*) AS EmployeeCount
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY	m.FirstName,
			m.LastName
HAVING COUNT(e.ManagerID) = 5
GO

--12. Write a SQL query to find all employees along with their managers.
--For employees that do not have manager display the value "(no manager)".

--With COALESCE
SELECT
	e.FirstName,
	e.LastName,
	COALESCE(m.LastName, '(no manager)') AS Manager
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GO

--With ISNULL
SELECT
	e.FirstName,
	e.LastName,
	ISNULL(m.LastName, '(no manager)') AS Manager
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GO

--13. Write a SQL query to find the names of all employees whose last
--name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT
	FirstName,
	LastName
FROM Employees
WHERE LEN(LastName) = 5
GO

--14.Write a SQL query to display the current date and time in the following
--format "day.month.year hour:minutes:seconds:milliseconds".
--Search in  Google to find how to format dates in SQL Server.

SELECT
	CONCAT(CONVERT(varchar(24), GETDATE(), 104), ' ', CONVERT(varchar(12), GETDATE(), 114)) AS DateNow
GO

--15. Write a SQL statement to create a table Users. Users should have username,
--password, full name and last login time. Choose appropriate data types for the
--table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
	UserID int IDENTITY,
	Username nvarchar(50) NOT NULL,
	UserPassword nvarchar(50),
	FullName nvarchar(50) NOT NULL,
	LastLoginDate smalldatetime,
	CONSTRAINT PK_Users PRIMARY KEY(UserID),
	CONSTRAINT UK_Username UNIQUE(Username),
	CONSTRAINT UserPassword CHECK(len(UserPassword) > 5)
)
GO

--16. Write a SQL statement to create a view that displays the users from
--the Users table that have been in the system today. Test if the view works correctly.

CREATE VIEW [Users Today] AS
SELECT
	UserName
FROM Users
WHERE YEAR(LastLoginDate) = YEAR(GETDATE()) AND
MONTH(LastLoginDate) = MONTH(GETDATE()) AND
DAY(LastLoginDate) = DAY(GETDATE())
GO
--17. Write a SQL statement to create a table Groups. Groups should have
--unique name (use unique constraint). Define primary key and identity column.

CREATE TABLE Groups(
	GroupID int IDENTITY,
	Name nvarchar(50) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
	CONSTRAINT UK_Name UNIQUE(Name),
)
GO

--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the Groups table.
--Write a SQL statement to add a foreign key constraint between 
--tables Users and Groups tables.

ALTER TABLE Users
ADD GroupID int;
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Groups FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)
GO
--19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups
	VALUES ('Group1'),
	('Group2'),
	('Group3')
GO

INSERT INTO Users (Username, UserPassword, FullName, LastLoginDate, GroupID)
	VALUES ('Pesho', 'qwerty123', 'Pesho Peshev', '2013-07-13', 1),
	('Gosho', 'taratara', 'Gosho Peshev', '2013-07-13', 1),
	('Misho', 'qwerty567', 'Misho Peshev', '2013-07-13', 2),
	('Minka', 'qwerty321', 'Minka Svirkova', '2013-07-13', 3),
	('Ginka', 'qwerty456', 'Ginka Giova', '2013-07-13', 3),
	('Siika', 'qwerty', 'Siika Misirkova', '2013-07-13', 3)
GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET Username = 'GinkaGia'
WHERE UserID = 5
GO

UPDATE Groups
SET Name = 'Women'
WHERE GroupID = 3
GO

--21. Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users
WHERE Username = 'Misho'
GO

DELETE FROM Groups
WHERE Name = 'Group2'
GO

--22. Write SQL statements to insert in the Users table the names of all employees
--from the Employees table. Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.

INSERT INTO Users (Username, UserPassword, FullName, LastLoginDate)
	SELECT
		LOWER
(CONCAT(LEFT(FirstName, 1), LastName, CONVERT(nvarchar(5), ROW_NUMBER()))),
		LOWER(CONCAT(LEFT(FirstName, 1), LastName, '123')),
		CONCAT(FirstName, ' ', LastName),
		NULL
	FROM Employees
GO

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

UPDATE Users
SET UserPassword = NULL
WHERE YEAR(LastLoginDate) > YEAR(2010) AND
MONTH(LastLoginDate) > MONTH(03) AND
DAY(LastLoginDate) > DAY(10)
GO

--24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users
WHERE UserPassword IS NULL
GO

--25. Write a SQL query to display the average employee salary by department and job title.

SELECT
	AVG(e.Salary) AS AvgSalary,
	e.JobTitle,
	d.Name
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	e.JobTitle,
			d.Name
GO

--26. Write a SQL query to display the minimal employee salary by department 
--and job title along with the name of some of the employees that take it.

--MIN Salary in the Department
SELECT
	e.FirstName,
	e.LastName,
	e.Salary,
	e.JobTitle,
	d.Name
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT
	MIN(m.Salary)
FROM Employees m
WHERE m.DepartmentID = d.DepartmentID)
GO

--MIN Salary by JobTitle in Department
SELECT
	MIN(e.Salary) AS MinSalary,
	MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS FullName,
	e.JobTitle,
	d.Name AS DepartmentName
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	e.JobTitle,
			d.Name
GO

--27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1
	t.Name,
	COUNT(*) AS EmployeeCount
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC
GO

--28. Write a SQL query to display the number of managers from each town.

SELECT
	t.Name AS TownName,
	COUNT(e.ManagerID) AS ManagersCount
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
WHERE e.EmployeeID IN (SELECT DISTINCT
	ManagerID
FROM Employees)
GROUP BY t.Name
GO

--29. Write a SQL to create table WorkHours to store work reports for each employee
--(employee id, date, task, hours, comments). Don't forget to define  identity, 
--primary key and appropriate foreign key. 
--	Issue few SQL statements to insert, update and delete of some data in the table.
--	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours(
	WorkHoursID int IDENTITY,
	DateWorking smalldatetime,
	Task nvarchar(50),
	HoursSpent int,
	Comments ntext,
	EmployeeID int,
	CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursID),
	CONSTRAINT FK_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)
GO

--30. Start a database transaction, delete all employees from the 'Sales' department 
--along with all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN
ALTER TABLE Departments NOCHECK CONSTRAINT ALL
DELETE FROM Employees
WHERE DepartmentID IN (SELECT
		DepartmentID
	FROM Departments
	WHERE Name = 'Sales')
ROLLBACK


--31. Start a database transaction and drop the table EmployeesProjects. 
--Now how you could restore back the lost table data?

BEGIN TRAN



--32. Find how to use temporary tables in SQL Server. Using temporary tables backup 
--all records from EmployeesProjects and restore them back after dropping and re-creating the table.