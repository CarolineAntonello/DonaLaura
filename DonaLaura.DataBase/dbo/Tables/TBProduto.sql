CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [PrecoVenda] DECIMAL NOT NULL, 
    [PrecoCusto] DECIMAL NOT NULL, 
    [Disponibilidade] BIT NOT NULL, 
    [DataFabricacao] DATETIME NOT NULL, 
    [DataValidade] DATETIME NOT NULL
)
