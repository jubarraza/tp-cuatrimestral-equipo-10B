-- VISTA DE LISTA DIRECCIONES
CREATE OR ALTER VIEW vw_listaDireccionYCliente AS
SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, d.IdProvincia, d.Activo, p.Nombre + ' ' + p.Apellido AS NombreApellidoCliente FROM DIRECCIONES d
INNER JOIN CLIENTES c ON c.IdDireccion = d.Id
INNER JOIN PERSONAS p ON c.IdPersona = p.Id