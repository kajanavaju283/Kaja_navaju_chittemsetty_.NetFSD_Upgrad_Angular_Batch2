USE Ecommappdb;
GO

/* Level-1: Problem 2 – Customer Activity Classification
   Requirements:
   1. Use nested query for total order value.
   2. Classify (Premium, Regular, Basic) using CASE.
   3. Use UNION for customers with/without orders.
   4. Concatenate Full Name.
*/

-- Part 1: Customers who HAVE placed orders
SELECT 
    c.first_name + ' ' + c.last_name AS FullName,
    t.TotalOrderValue,
    CASE 
        WHEN t.TotalOrderValue > 10000 THEN 'Premium'
        WHEN t.TotalOrderValue BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS CustomerType
FROM customers c
JOIN (
    -- Nested query to calculate total per customer
    SELECT 
        o.customer_id, 
        SUM(oi.quantity * oi.list_price) AS TotalOrderValue
    FROM orders o
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t ON c.customer_id = t.customer_id

UNION

-- Part 2: Customers who HAVE NOT placed orders
SELECT 
    first_name + ' ' + last_name AS FullName,
    0 AS TotalOrderValue,
    'Basic' AS CustomerType
FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM orders);
GO