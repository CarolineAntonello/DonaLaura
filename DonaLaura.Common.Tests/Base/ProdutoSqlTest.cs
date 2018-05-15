using DonaLaura.Infra;

namespace DonaLaura.Common.Tests.Base
{
    public static class ProdutoSqlTest
    {
        private const string RECREATE_PRODUTO_TABLE = "DELETE FROM [dbo].[TBProduto]" + "DBCC CHECKIDENT('TBVenda', RESEED, 0);";
        //private const string INSERT_PRODUTO = "INSERT INTO TBProduto(Nome,PrecoVenda,PrecoCusto,Disponibilidade,DataFabricacao,DataValidade) VALUES ('Computador',2000,1500,1, 2018-05-13,2019-05-13)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            //Db.Update(INSERT_PRODUTO);
        }

    }
}
