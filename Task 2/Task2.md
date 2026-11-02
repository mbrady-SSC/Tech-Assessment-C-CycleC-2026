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
GROUP BY e.FirstName;```
```
This query lists each employee's first name and how many orders they have placed.

- SELECT e.FirstName, COUNT(o.OrderID) AS NumberOfOrders
  Returns the employee's first name and counts their orders. The count column
  is named NumberOfOrders.

- FROM Employees AS e
  Starts with the Employees table and gives it the short name "e".

- LEFT JOIN Orders AS o ON e.EmployeeID = o.EmployeeID
  Connects each employee to their orders by matching EmployeeID in both tables.
  A LEFT JOIN keeps every employee, even one with no orders. That employee
  would show a count of 0.

- GROUP BY e.FirstName
  Puts all the orders for each first name into one group, so COUNT gives
  one total per employee.```

4. For submission commit and push this .md file to Github
