USE Ecommappdb;
GO

CREATE OR ALTER TRIGGER trg_CheckShippedDateOnComplete
ON orders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Requirement: Validate that shipped_date is NOT NULL when order_status = 4
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            WHERE i.order_status = 4 AND i.shipped_date IS NULL
        )
        BEGIN
            -- Technical Constraint: Rollback and use custom error message
            RAISERROR('Validation Failed: An order cannot be set to Completed status (4) without a valid Shipped Date.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END TRY
    BEGIN CATCH
        -- Technical Constraint: Use TRY...CATCH block for error handling
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        
        -- If it wasn't already rolled back by the RAISERROR logic
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;

        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO