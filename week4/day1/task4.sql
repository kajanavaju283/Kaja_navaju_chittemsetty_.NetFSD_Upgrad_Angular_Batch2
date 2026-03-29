USE Ecommappdb;
GO

-- 1. Create a Temporary Table to store the computed results
IF OBJECT_ID('tempdb..#StoreRevenueResults') IS NOT NULL DROP TABLE #StoreRevenueResults;
CREATE TABLE #StoreRevenueResults (
    StoreName NVARCHAR(255),
    TotalRevenue DECIMAL(18, 2)
);

-- 2. Declare variables for data processing
DECLARE @StoreName NVARCHAR(255);
DECLARE @RevenuePerStore DECIMAL(18, 2);

-- 3. Declare the CURSOR to iterate through stores with completed orders (status = 4)
DECLARE RevenueCursor CURSOR FOR
SELECT 
    s.store_name, 
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS Revenue
FROM stores s
JOIN orders o ON s.store_id = o.store_id
JOIN order_items oi ON o.order_id = oi.order_id
WHERE o.order_status = 4  -- Filter for completed orders only
GROUP BY s.store_name;

BEGIN TRY
    -- 4. Start Explicit Transaction
    BEGIN TRANSACTION;

    OPEN RevenueCursor;

    -- Fetch the first record
    FETCH NEXT FROM RevenueCursor INTO @StoreName, @RevenuePerStore;

    -- 5. Row-by-row processing using WHILE loop
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Insert the computed revenue into the temporary table
        INSERT INTO #StoreRevenueResults (StoreName, TotalRevenue)
        VALUES (@StoreName, @RevenuePerStore);

        -- Fetch the next record
        FETCH NEXT FROM RevenueCursor INTO @StoreName, @RevenuePerStore;
    END

    -- 6. Clean up Cursor
    CLOSE RevenueCursor;
    DEALLOCATE RevenueCursor;

    -- Commit the transaction if processing completes successfully
    COMMIT TRANSACTION;

    -- 7. Display the final store-wise revenue summary
    SELECT * FROM #StoreRevenueResults;

END TRY
BEGIN CATCH
    -- 8. Rollback in case of failure and handle errors
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;

    -- Ensure cursor is closed and deallocated if an error occurs
    IF CURSOR_STATUS('global','RevenueCursor') >= 0 
    BEGIN
        CLOSE RevenueCursor;
        DEALLOCATE RevenueCursor;
    END

    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@ErrorMessage, 16, 1);
END CATCH;