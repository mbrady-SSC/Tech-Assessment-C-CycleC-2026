1. Open SQL Server Management Studio (or an equivalent SQL Management Software)
2. Connect to Northwind DB (Same DB as you used in Geek Week)
3. Write a query that shows each employee’s first name and the number of orders they have placed. Group the results by employee’s first name.

Please add your SQL query below AND add explanation of the query: 

```
SELECT
    e.FirstName,
    COUNT(o.OrderID) AS NumberOfOrders
FROM Employees AS e
LEFT JOIN Orders AS o
    ON e.EmployeeID = o.EmployeeID
GROUP BY e.FirstName;
```
This query lists each employee's first name and how many orders they have placed.


4. For submission commit and push this .md file to Github
