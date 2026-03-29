USE Ecommappdb;
GO

CREATE OR ALTER TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ProductID INT;
    DECLARE @StoreID INT;
    DECLARE @OrderQuantity INT;
    DECLARE @CurrentStock INT;

    -- Get details from the inserted row
    -- Note: We join with the orders table to get the store_id
    SELECT 
        @ProductID = i.product_id, 
        @OrderQuantity = i.quantity,
        @StoreID = o.store_id
    FROM inserted i
    JOIN orders o ON i.order_id = o.order_id;

    BEGIN TRY
        -- Check current stock levels
        SELECT @CurrentStock = quantity 
        FROM stocks 
        WHERE product_id = @ProductID AND store_id = @StoreID;

        -- Check if enough stock is available
        IF (@CurrentStock < @OrderQuantity)
        BEGIN
            -- Custom error message if stock is insufficient
            RAISERROR('Insufficient stock! The transaction has been rolled back.', 16, 1);
            ROLLBACK TRANSACTION;
        END
        ELSE
        BEGIN
            -- Update (reduce) the stock quantity
            UPDATE stocks
            SET quantity = quantity - @OrderQuantity
            WHERE product_id = @ProductID AND store_id = @StoreID;
        END
    END TRY
    BEGIN CATCH
        -- Handle any other errors during execution
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    END CATCH
END;
GO