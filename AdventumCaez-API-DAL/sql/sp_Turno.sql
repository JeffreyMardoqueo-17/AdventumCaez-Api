CREATE PROCEDURE SP_GetAllTurno
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Turno;
END;


GO

CREATE PROCEDURE SP_GetTurnoById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Turno WHERE Id = @Id;        
END;