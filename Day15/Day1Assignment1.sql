CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2)
);
CREATE TABLE Orders (
    OrderID INT,
    CustomerID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
INSERT INTO Customer (CustomerID, CustomerName) VALUES
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Carol Davis');
INSERT INTO Product (ProductID, ProductName, Price) VALUES
(101, 'Laptop', 800.00),
(102, 'Mouse', 20.00),
(103, 'Keyboard', 45.00),
(104, 'Monitor', 150.00);
INSERT INTO Orders (OrderID, CustomerID, ProductID, Quantity) VALUES
(1001, 1, 101, 1),   -- Alice buys 1 Laptop
(1001, 1, 102, 2),   -- Alice buys 2 Mice in same order
(1002, 2, 103, 1),   -- Bob buys 1 Keyboard
(1002, 2, 104, 1),   -- Bob buys 1 Monitor in same order
(1003, 1, 103, 1),   -- Alice buys 1 Keyboard (separate order)
(1004, 3, 102, 3),   -- Carol buys 3 Mice
(1005, 3, 104, 1);  

SELECT 
    c.CustomerID,
    c.CustomerName,
    SUM(o.Quantity * p.Price) AS TotalAmountSpent
FROM Customer c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN Product p ON o.ProductID = p.ProductID
GROUP BY c.CustomerID, c.CustomerName
ORDER BY TotalAmountSpent DESC;
SELECT 
    c.CustomerID,
    c.CustomerName,
    COUNT(DISTINCT o.OrderID) AS NumberOfOrders
FROM Customer c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CustomerName
ORDER BY NumberOfOrders DESC;
SELECT 
    c.CustomerID,
    c.CustomerName,
    COALESCE(SUM(o.Quantity * p.Price), 0) / 
        NULLIF(COUNT(DISTINCT o.OrderID), 0) AS AvgOrderValue
FROM Customer c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN Product p ON o.ProductID = p.ProductID
GROUP BY c.CustomerID, c.CustomerName
ORDER BY AvgOrderValue DESC;

SELECT 
    p.ProductID,
    p.ProductName,
    COALESCE(SUM(o.Quantity), 0) AS TotalQuantitySold
FROM Product p
LEFT JOIN Orders o ON p.ProductID = o.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY TotalQuantitySold DESC;


SELECT 
    c.CustomerID,
    c.CustomerName,
    o.OrderID,
    p.ProductID,
    p.ProductName,
    o.Quantity,
    (o.Quantity * p.Price) AS LineTotal
FROM Customer c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN Product p ON o.ProductID = p.ProductID
ORDER BY c.CustomerID, o.OrderID;
INSERT INTO Orders (OrderID, CustomerID, ProductID, Quantity)
VALUES (9999, 99, 102, 1);   -- Customer 99 does not exist
SELECT 
    o.OrderID,
    o.CustomerID,
    c.CustomerName,          -- Will be NULL if customer missing
    o.ProductID,
    p.ProductName,
    o.Quantity,
    (o.Quantity * p.Price) AS LineTotal
FROM Orders o
LEFT JOIN Customer c ON o.CustomerID = c.CustomerID
LEFT JOIN Product p ON o.ProductID = p.ProductID
ORDER BY o.OrderID;
SELECT 
    c.CustomerID AS CustID,
    c.CustomerName,
    o.OrderID,
    o.CustomerID AS OrderCustID,
    p.ProductName,
    o.Quantity
FROM Customer c
FULL OUTER JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN Product p ON o.ProductID = p.ProductID
ORDER BY COALESCE(c.CustomerID, o.CustomerID), o.OrderID;
