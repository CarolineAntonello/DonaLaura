using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Base
{
    public static class VendaSqlTest
    {
        private const string RECREATE_VENDA_TABLE = "DELETE FROM [dbo].[TBVenda]; ";
        private const string EXCLUINDO_LIGAÇÃO = "DBCC CHECKIDENT('TBVenda', RESEED, 0);";
        private const string RECREATE_PRODUTO_TABLE = "DELETE FROM [dbo].[TBProduto]" + "DBCC CHECKIDENT('TBVenda', RESEED, 0);";
        //private const string INSERT_VENDA = "INSERT INTO TBVenda(ProdutoId,Cliente,Quantidade,Lucro) VALUES (1,'Caroline',1,500)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_VENDA_TABLE);
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(EXCLUINDO_LIGAÇÃO);
            //Db.Update(INSERT_VENDA);
        }
    }
}
