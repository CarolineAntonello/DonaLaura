﻿CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ProdutoId] INT NOT NULL, 
    [Cliente] NVARCHAR(50) NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [Lucro] DECIMAL NOT NULL, 
    CONSTRAINT [FK_TBVenda_TBProduto] FOREIGN KEY (ProdutoId) REFERENCES [TBProduto](Id) ON DELETE CASCADE
)
