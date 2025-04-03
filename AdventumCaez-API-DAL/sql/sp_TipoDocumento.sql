---SP PARA OBTENER TOSO LOS TIPOS DE DOCUMENTO (NIE, DUI, ETC)
CREATE PROCEDURE SP_GetAllTipoDocumento
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TipoDocumento;
END;

GO

-----sp para obtener por id

CREATE PROCEDURE SP_GetTipoDocumentoById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM TipoDocumento WHERE Id = @Id;
END;

GO