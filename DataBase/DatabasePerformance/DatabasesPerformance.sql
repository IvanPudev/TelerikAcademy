CREATE TABLE Logs(
  Id int NOT NULL IDENTITY,
  LogDate datetime,
  MsgText nvarchar(300),
  CONSTRAINT PK_Logs_Id PRIMARY KEY (Id)
)

GO

CREATE PROC usp_Add1MilionLogs
AS
DECLARE @counter int
SET @counter = 1;
WHILE(@counter < 10000000)
BEGIN
  DECLARE @Date datetime
	SET @Date = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	INSERT INTO Logs (LogDate, MsgText)
	VALUES(@Date, 'dsd')
	SET @counter = @counter + 1;
END
GO
--filled 2 000 000 logs for 12 minutes...and i have stopped it

EXEC usp_Add1MilionLogs


CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--1.Create a table in SQL Server with 10 000 000 log entries (date + text). 
--Search in the table by date range. Check the speed (without caching).

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001

--RESULT:
-- 3sec. without cache
-- 2sec. with cache

--2.Add an index to speed-up the search by date. 
--Test the search speed (after cleaning the cache).

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
DROP INDEX Logs.IDX_Logs_LogDate
--indexes created for 8sec.
SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
--no difference for 2 000 000 logs...

--3.Add a full text index for the text column. Try to search with 
--and without the full-text index and compare the speed.

DROP INDEX Logs.IDX_Logs_LogDate
CREATE INDEX IDX_Logs_MsgText ON Logs(MsgText)

SELECT l.MsgText
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
-- without cache 4 sec no index and the same with index
-- with cache 3 sec no index and the same with index