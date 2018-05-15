DROP DATABASE DBDonaLaura;
CREATE DATABASE DBDonaLaura;
GO
USE [DBDonaLaura]
GO
CREATE TABLE [dbo].[TBProduto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](140)  NOT NULL,
	[PrecoVenda] [decimal] NOT NULL,
	[PrecoCusto] [decimal] NOT NULL,
	[Disponibilidade] [bit] NOT NULL,
	[Datafabricacao] [datetime]  NOT NULL,
	[DataValidade] [datetime] NOT NULL
 CONSTRAINT [PK_TBProduto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProdutoId] INT NOT NULL, 
    [Cliente] NVARCHAR(50) NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [Lucro] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_TBVenda_TBProduto] FOREIGN KEY (ProdutoId) REFERENCES [TBProduto](Id)
)

