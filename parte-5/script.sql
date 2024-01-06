USE MyDatabaseName
GO;

DROP TABLE IF EXISTS OrderReports
GO;
CREATE TABLE  OrderReports (
    ReportId INT PRIMARY KEY IDENTITY,
    OrderId INT,
    CustomerName VARCHAR(255),
    Quantity decimal(18,2),
    ReportDate DATETIME
)
GO;

DROP PROCEDURE IF EXISTS GenerateOrderReports;
GO;
CREATE PROCEDURE GenerateOrderReports
    AS
BEGIN
    DELETE FROM OrderReports;
    INSERT INTO OrderReports (OrderId, CustomerName, Quantity, ReportDate)
    SELECT
        o.Id,
        c.Name,
        o.Quantity,
        GETDATE()
    FROM
        Orders o
            INNER JOIN
        Customers c ON o.CustomerId = c.Id
    END
GO;
