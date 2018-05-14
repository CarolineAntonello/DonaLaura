CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProdutoId] INT NOT NULL, 
    [Cliente] NVARCHAR(50) NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [Lucro] DECIMAL NOT NULL, 
    CONSTRAINT [FK_TBVenda_ToTable] FOREIGN KEY (ProdutoId) REFERENCES [TBProduto](Id)
)
