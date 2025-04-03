-- //SP PARA OBTENER TODOS LOS TIPOS DE PAGO (Maticuloa, colegiatura, etc)
CREATE PROCEDURE SP_GetAllTipoPago
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TipoPago;
END;
GO

-----------//SP PARA OBTENER POR ID
CREATE PROCEDURE SP_GetTipoPagoById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TipoPago WHERE Id = @Id;
END;
GO


-- //como usar
-- EXEC SP_GetAllTipoPago;
--EXEC SP_GetTipoPagoById @Id = 1;
