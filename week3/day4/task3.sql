USE Ecommappdb;
GO

/* Level-2: Problem 3 – Store Performance and Stock Validation
   Requirements:
   1. Identify sold products per store using subqueries.
   2. Use INTERSECT/EXCEPT to compare sold products vs stock.
   3. Calculate revenue: (quantity * list_price - discount).
   4. Update stock for discontinued products.
*/

--- Step 1: Identify products sold but currently have zero stock ---
SELECT 
    s.store_name,
    p.product_name,
    t.TotalQuantitySold,
    t.TotalRevenue
FROM stores s
JOIN (
    -- Subquery in FROM clause to calculate revenue and totals
    SELECT 
        o.store_id,
        oi.product_id,
        SUM(oi.quantity) AS TotalQuantitySold,
        SUM(oi.quantity * (oi.list_price - oi.discount)) AS TotalRevenue
    FROM orders o
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY o.store_id, oi.product_id
) t ON s.store_id = t.store_id
JOIN products p ON t.product_id = p.product_id
JOIN stocks st ON s.store_id = st.store_id AND p.product_id = st.product_id
WHERE st.quantity = 0;

--- Step 2: Set Operators Simulation (Constraint Requirement) ---
-- Products that are both in the products table AND have been ordered
SELECT product_id FROM products
INTERSECT
SELECT product_id FROM order_items;

-- Products that exist but have NEVER been sold
SELECT product_id FROM products
EXCEPT
SELECT product_id FROM order_items;

--- Step 3: Update stock to 0 for a discontinued product (Simulation) ---
-- Assuming 'product_id = 10' is a discontinued product for this simulation
UPDATE stocks
SET quantity = 0
WHERE product_id = 10;
GO