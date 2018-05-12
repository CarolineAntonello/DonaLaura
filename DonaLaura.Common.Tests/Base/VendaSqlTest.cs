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
        private const string RECREATE_POST_TABLE = "TRUNCATE TABLE [dbo].[Venda] ";
        private const string INSERT_POST = "INSERT INTO Posts(ProdutoId,Cliente,Quantidade,Lucro) VALUES (1,'Carol',1,500)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_POST_TABLE);
            Db.Update(INSERT_POST);
        }
    }
}
