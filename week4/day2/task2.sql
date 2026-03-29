USE Ecommappdb;
GO

BEGIN TRY
    -- Start the main transaction
    BEGIN TRANSACTION;

    -- Variable for the order you want to cancel
    DECLARE @CancelOrderId INT = 1; 

    -- 1. Update order_status to 3 (Rejected)
    UPDATE orders 
    SET order_status = 3 
    WHERE order_id = @CancelOrderId;

    -- 2. Create a SAVEPOINT before restoring stock
    SAVE TRANSACTION StockRestorePoint;

    -- 3. Restore stock quantities based on order_items
    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi ON s.product_id = oi.product_id
    JOIN orders o ON oi.order_id = o.order_id AND s.store_id = o.store_id
    WHERE o.order_id = @CancelOrderId;

    -- 4. Commit transaction if everything succeeds
    COMMIT TRANSACTION;
    PRINT 'Order cancelled and stock restored successfully.';

END TRY
BEGIN CATCH
    -- 5. Rollback to SAVEPOINT if stock restoration fails
    IF @@TRANCOUNT > 0
    BEGIN
        -- This restores the status to "Rejected" but rolls back the stock changes
        ROLLBACK TRANSACTION StockRestorePoint;
        
        -- Finalize the status update even if stock restore failed
        COMMIT TRANSACTION; 
        PRINT 'Stock restoration failed; rolled back to savepoint. Order status remains Rejected.';
    END
    ELSE
    BEGIN
        -- Handle severe errors that prevent the transaction from starting
        PRINT 'Critical Error: ' + ERROR_MESSAGE();
    END
END CATCH;
GO