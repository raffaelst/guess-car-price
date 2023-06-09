SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
    c.Age,
    o.OrderID,
    o.DateCreated,
    o.MethodofPurchase AS PurchaseMethod,
    od.ProductNumber,
    od.ProductOrigin
FROM 
    CustomerTable c
    INNER JOIN OrdersTable o ON c.PersonID = o.PersonID
    INNER JOIN OrdersDetailsTable od ON o.OrderID = od.OrderID
WHERE 
    od.ProductID = 1112222333;
