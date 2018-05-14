CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [PrecoVenda] DECIMAL NOT NULL, 
    [PrecoCusto] DECIMAL NOT NULL, 
    [Disponibilidade] BINARY(2) NOT NULL, 
    [DataFabricacao] DATETIME NOT NULL, 
    [DataValidade] DATETIME NOT NULL
)
