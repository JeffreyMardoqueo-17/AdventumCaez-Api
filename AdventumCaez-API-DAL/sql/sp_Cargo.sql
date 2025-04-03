-- OBTENER TODOS
CREATE PROCEDURE SP_GetAllCargo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Cargo;
END;

GO

-- OBTNER POR ID
CREATE PROCEDURE SP_GetCargoById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Cargo WHERE Id = @Id;
END;

GO