--1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
--and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.

USE [TransactSQL]
GO
 

CREATE TABLE Persons(
	PersonID int IDENTITY NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
    CONSTRAINT PK_Persons PRIMARY KEY CLUSTERED(PersonID ASC)
)
GO

CREATE TABLE Accounts(
	AccountID int IDENTITY NOT NULL,
	PersonID int NOT NULL,
	Balance money,
    CONSTRAINT PK_Accounts PRIMARY KEY CLUSTERED(AccountID ASC),
	CONSTRAINT FK_Persons FOREIGN KEY(PersonID) REFERENCES Persons(PersonID)
)
GO

CREATE PROC dbo.usp_SelectPersonFullName 
AS
	SELECT
		CONCAT(FirstName, ' ', LastName) AS FullName
	FROM Persons
GO

EXEC usp_SelectPersonFullName
GO

--2. Create a stored procedure that accepts a number as a parameter and 
--returns all persons who have more money in their accounts than the supplied number.

CREATE PROC dbo.usp_CheckHigherBalanceByID(@balanceToCompare money) 
AS 
	SELECT
		*
	FROM Persons p
	JOIN Accounts a
	ON p.PersonID = a.PersonID
	WHERE a.Balance > @balanceToCompare
GO

EXEC usp_CheckHigherBalanceByID 2000
GO

--3. Create a function that accepts as parameters – sum, yearly interest 
--rate and number of months. It should calculate and return the new sum. 
--Write a SELECT to test whether the function works as expected.

CREATE FUNCTION dbo.ufn_CALCINTEREST(@sum money, @yearlyInterest float, @months int)
	RETURNS money
AS
	BEGIN
		DECLARE @precalcSum money;
		SET @precalcSum = ((((@yearlyInterest / 12) * @months) * @sum) / 100) + @sum;
		RETURN @precalcSum
	END
GO

SELECT 
	dbo.ufn_CALCINTEREST(2000, 12, 8) AS NewBalance
GO

--4. Create a stored procedure that uses the function from the previous example 
--to give an interest to a person's account for one month. It should take the 
--AccountId and the interest rate as parameters.

CREATE PROC dbo.usp_CalcMonthInterest(@accountID int, @interest float) 
AS
	UPDATE Accounts 
	SET Balance = dbo.ufn_CALCINTEREST(2000, @interest, 12)
	WHERE AccountID = @accountID
GO

EXEC usp_CalcMonthInterest 2, 5.6
GO

--5. Add two more stored procedures WithdrawMoney( AccountId, money) 
--and DepositMoney (AccountId, money) that operate in transactions.

CREATE PROC dbo.usp_WithdrawMoney(@accountID int, @money money)
AS
BEGIN TRAN
	DECLARE @currentBalance money = (SELECT Balance FROM Accounts WHERE AccountID = @accountID)
	IF (@currentBalance > @money)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @money
			WHERE AccountID = @accountID
			COMMIT TRAN
		END
		ELSE
			BEGIN
				RAISERROR ('Not enough money in the account to finish operation.', 16, 1)
				ROLLBACK TRAN
			END
GO

EXEC usp_WithdrawMoney 3, 300
GO

CREATE PROC dbo.usp_DepositMoney(@accountID int, @money money)
AS
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE AccountID = @accountID
GO

EXEC usp_DepositMoney 3, 300
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into 
--the Logs table every time the sum on an account changes.

CREATE TABLE AccountLogs(
	LogID int IDENTITY,
	AccountID int NOT NULL,
	OldSum money,
	NewSum money,
	CONSTRAINT PK_LogID PRIMARY KEY CLUSTERED(LogID ASC),
	CONSTRAINT FK_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID)
)
GO

CREATE TRIGGER tr_AccountsUpdate ON dbo.Accounts FOR UPDATE
AS
        BEGIN
			DECLARE @accountID int = (SELECT AccountID FROM deleted)
			DECLARE @oldSum money = (SELECT Balance FROM deleted)
			DECLARE @newSum money = (SELECT Balance FROM inserted)
			INSERT INTO AccountLogs (AccountID, OldSum, NewSum)
				VALUES(@accountID, @oldSum, @newSum)
        END
GO

EXEC usp_WithdrawMoney 4, 500
GO