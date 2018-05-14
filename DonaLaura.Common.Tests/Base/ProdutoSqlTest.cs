using DonaLaura.Infra;

namespace DonaLaura.Common.Tests.Base
{
    public static class ProdutoSqlTest
    {
        private const string RECREATE_PRODUTO_TABLE = "TRUNCATE TABLE [dbo].[TBProduto]";
        private const string INSERT_PRODUTO = "INSERT INTO TBProduto(Nome,PrecoVenda,PrecoCusto,Disponibilidade,DataFabricacao,DataValidade) VALUES ('Computador',2000,1500,true, 2018-05-13,2019-05-13)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }

    }
}
