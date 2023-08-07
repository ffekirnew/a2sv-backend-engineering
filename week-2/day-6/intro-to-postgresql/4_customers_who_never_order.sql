SELECT name AS Customers
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE c.id = o.customerId
);
