USE Ecommappdb;
GO

/* Level-1: Problem 1 – Product Analysis Using Nested Queries
   Requirements:
   1. Retrieve product details.
   2. Use a nested query to compare price with category average.
   3. Calculate the price difference.
   4. Concatenate Product Name and Model Year.
*/

SELECT 
    -- Requirement 5: Concatenate product name and model year
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS Product_Details,
    list_price,
    
    -- Requirement 4: Show calculated difference
    list_price - (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS Price_Difference_From_Avg

FROM products p1

-- Requirement 2 & 3: Use subquery in WHERE clause to filter products above average
WHERE list_price > (
    SELECT AVG(p2.list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);