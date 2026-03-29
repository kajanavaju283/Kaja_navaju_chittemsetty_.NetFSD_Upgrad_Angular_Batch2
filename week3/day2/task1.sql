-- 1. Use the correct database
USE Ecommappdb;
GO

-- 2. Stored Procedure for Total Sales per Store
CREATE OR ALTER PROCEDURE sp_GetTotalSalesByStore
AS
BEGIN
    SELECT 
        s.store_name, 
        SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS TotalSales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_name;
END;
GO

-- 3. Stored Procedure for Orders by Date Range
CREATE OR ALTER PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT * FROM orders 
    WHERE order_date BETWEEN @StartDate AND @EndDate;
END;
GO

-- 4. Scalar Function for Discounted Price
CREATE OR ALTER FUNCTION fn_CalculateDiscountedPrice (
    @Price DECIMAL(10,2),
    @Discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN (@Price * (1 - @Discount));
END;
GO

-- 5. Table-Valued Function for Top 5 Selling Products
CREATE OR ALTER FUNCTION fn_GetTop5SellingProducts()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 5 
        p.product_name, 
        SUM(oi.quantity) AS TotalQuantitySold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY TotalQuantitySold DESC
);
GO