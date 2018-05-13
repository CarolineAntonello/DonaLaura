using DonaLaura.Infra;

namespace DonaLaura.Common.Tests.Base
{
    public static class ProdutoSqlTest
    {
        private const string RECREATE_POST_TABLE = "TRUNCATE TABLE [dbo].[TBProduto] ";
        private const string INSERT_POST = "INSERT INTO Posts(Nome,PrecoVenda,PrecoCusto,Disponibilidade,DataFabricacao,DataValidade) VALUES ('Computador',2000,1500,true, GETDATE(),GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_POST_TABLE);
            Db.Update(INSERT_POST);
        }

    }
}
