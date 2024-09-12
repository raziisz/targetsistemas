SELECT 
	c.Id, 
	c.Razao_Social,
	STRING_AGG(t.Numero, ', ') AS Telefones
FROM 
	clientes c
INNER JOIN estados e ON
	c.Id_Estado = e.Id
INNER JOIN 
    telefones t ON
	c.Id = t.Id_Cliente
where
	e.UF = 'SP'
GROUP BY 
    c.Id, c.Razao_Social;

-- Em Sql Server