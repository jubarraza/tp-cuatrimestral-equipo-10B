-- VISTA DE PROVINCIAS Y PAISES
CREATE VIEW vw_ProvinciaYPais AS 
SELECT p.Id AS IdProvincia, p.Nombre AS Provincia, p.Visible, p2.Id AS IdPais, p2.Nombre AS Pais, p2.Activo FROM PROVINCIAS p 
INNER JOIN Paises p2 ON p.IdPais = p2.Id WHERE p.Activo = 1

