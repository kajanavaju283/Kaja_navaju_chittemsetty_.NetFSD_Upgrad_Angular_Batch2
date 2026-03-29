-- 1. Use the correct database
USE Ecommappdb;
GO

-- 2. Create the Trigger first (To handle automatic stock updates)
CREATE OR ALTER TRIGGER trg_UpdateStockAndCheckAvailability
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Requirement: Prevent stock from becoming negative
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN stocks s ON i.product_id = s.product_id
            JOIN orders o ON i.order_id = o.order_id AND s.store_id = o.store_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock! Transaction Rolled Back.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Requirement: Reduce stock quantity automatically
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i ON s.product_id = i.product_id
        JOIN orders o ON i.order_id = o.order_id AND s.store_id = o.store_id;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        DECLARE @Err NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@Err, 16, 1);
    END CATCH
END;
GO

-- 3. Explicit Transaction to Insert Data (Testing the logic)
BEGIN TRY
    BEGIN TRANSACTION;

    -- Adding a new order
    DECLARE @NewOrderId INT;
    INSERT INTO orders (customer_id, order_status, order_date, required_date, store_id, staff_id)
    VALUES (1, 1, GETDATE(), DATEADD(day, 5, GETDATE()), 1, 1);

    SET @NewOrderId = SCOPE_IDENTITY();

    -- Adding items to the order (This activates the trigger)
    INSERT INTO order_items (order_id, item_id, product_id, quantity, list_price, discount)
    VALUES (@NewOrderId, 1, 1, 2, 999.99, 0.10);

    -- If everything is fine, Save changes
    COMMIT TRANSACTION;
    PRINT 'Success: Order placed and stock updated.';
END TRY
BEGIN CATCH
    -- If trigger fails or any error occurs, undo everything
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'Error: ' + ERROR_MESSAGE();
END CATCH;
GO