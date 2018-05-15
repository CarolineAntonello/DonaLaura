using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_VENDA_TABLE = "DELETE FROM [dbo].[TBVenda]" +
                                                    "DBCC CHECKIDENT ('TBVenda', RESEED, 0)";

        private const string RECREATE_PRODUTO_TABLE = "DELETE FROM [dbo].[TBProduto]" +
                                                       "DBCC CHECKIDENT ('TBProduto', RESEED, 0)";

        private const string INSERT = @"
                        DECLARE @dateNowMoreDays DateTime;
                        DECLARE @ProdutoId INT

                        SELECT  @dateNowMoreDays = DATEADD(day, 30, GETDATE())

                        INSERT INTO TBProduto(Nome, 
                                            PrecoVenda, 
                                            PrecoCusto, 
                                            Disponibilidade, 
                                            DataFabricacao, 
                                            DataValidade)

                        VALUES('Teste', 10, 8, 1, GETDATE(), @dateNowMoreDays)

                        SET @ProdutoId = @@IDENTITY

                        INSERT INTO TBVenda (ProdutoId, Cliente, Quantidade, Lucro)         
			            VALUES (@ProdutoId, 'Vinicius', 2, 2);";

        public static void SeedDeleteDatabase()
        {
            Db.Update(RECREATE_VENDA_TABLE);
            Db.Update(RECREATE_PRODUTO_TABLE);
        }

        public static void SeedInsertDatabase()
        {
            Db.Update(INSERT);
        }
    }
}
