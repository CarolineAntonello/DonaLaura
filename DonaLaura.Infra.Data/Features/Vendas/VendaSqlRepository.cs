using DonaLaura.Domain.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Vendas
{
    public class VendaSqlRepository : IVendaRepository
    {
        private string _sqlAdd = 
            @"INSERT INTO TBVenda
                           (ProdutoId,
                            Cliente,
                            Quantidade,
                            Lucro) 
                            VALUES 
                            (@ProdutoId, 
                            @Cliente, 
                            @Quantidade, 
                            @Lucro)";

        private string _sqlUpdate =
            @"update TBVenda SET 
                            ProdutoId = @ProdutoId, 
                            Cliente = @Cliente, 
                            Quantidade = @Quantidade, 
                            Lucro = @Lucro 
                            where Id = @Id";

        private string _sqlGetById = @"SELECT 
                            TBVenda.Id,
                            TBVenda.ProdutoId,
                            TBVenda.Cliente,
                            TBVenda.Quantidade,     
                            TBVenda.Lucro,
                            TBProduto.Nome, 
                            TBProduto.PrecoVenda, 
                            TBProduto.PrecoCusto, 
                            TBProduto.Disponibilidade, 
                            TBProduto.DataFabricacao, 
                            TBProduto.DataValidade
                        FROM
                            TBVenda
                        INNER JOIN TBProduto ON TBVenda.ProdutoId = TBProduto.Id
                        WHERE TBVenda.Id = TBVenda.Id";

        private string _sqlDelete = @"delete from TBVenda where Id = Id";

        private string _sqlGetAll = @"SELECT 
                                    TBVenda.Id,
                                    TBVenda.ProdutoId,
                                    TBVenda.Cliente,
                                    TBVenda.Quantidade,     
                                    TBVenda.Lucro,
                                    TBProduto.Nome, 
                                    TBProduto.PrecoVenda, 
                                    TBProduto.PrecoCusto, 
                                    TBProduto.Disponibilidade, 
                                    TBProduto.DataFabricacao, 
                                    TBProduto.DataValidade
                                FROM
                                    TBVenda
                                INNER JOIN TBProduto ON TBVenda.ProdutoId = TBVenda.Id";

        public Venda Save(Venda venda)
        {
            venda.Validacao();
            venda.Id = Db.Insert(_sqlAdd, Take(venda));
            return venda;
        }

        public void Update(Venda venda)
        {
            venda.Validacao();
            Db.Update(_sqlUpdate, Take(venda));
        }

        public void Delete(Venda venda)
        {
            Db.Delete(_sqlDelete, Take(venda));
        }

        public Venda Get(long id)
        {
            Venda venda = Db.Get<Venda>(_sqlGetById, Make, new object[] { "@Id", id });
            return venda;
        }

        public IEnumerable<Venda> GetAll()
        {
            return Db.GetAll<Venda>(_sqlGetAll, Make);
        }
        
        private static Func<IDataReader, Venda> Make = reader =>
           new Venda
           {
               Id = Convert.ToInt64(reader["Id"]),
               ProdutoId = Convert.ToInt64(reader["ProdutoId"]),
               Cliente = reader["Cliente"].ToString(),
               Quantidade = Convert.ToInt16(reader["Quantidade"]),
               Lucro = Convert.ToDouble(reader["Lucro"])

           };

        private object[] Take(Venda venda)
        {
            return new object[]
            {
                "@Id", venda.Id,
                "@ProdutoId", venda.ProdutoId,
                "@Cliente", venda.Cliente,
                "@Quantidade", venda.Quantidade,
                "@Lucro", venda.Lucro
            };
        }
    }
}
