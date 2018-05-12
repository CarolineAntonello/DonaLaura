CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [PrecoVenda] DECIMAL(18, 2) NOT NULL, 
    [PrecoCusto] DECIMAL(18, 2) NOT NULL, 
    [Disponilidade] BINARY(2) NOT NULL, 
    [DataFabricacao] DATETIME NOT NULL, 
    [DataValidade] DATETIME NOT NULL
)
