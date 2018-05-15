using DonaLaura.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using DonaLaura.Infra;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Produtos
{
    public class ProdutoSqlRepository : IProdutoRepository
    {
        private string _sqlAdd = @"INSERT INTO 
                                    TBProduto
                                    (Nome,
                                    PrecoVenda,
                                    PrecoCusto,
                                    Disponibilidade,
                                    DataFabricacao,
                                    DataValidade) 
                                    VALUES 
                                    (@Nome, 
                                    @PrecoVenda,
                                    @PrecoCusto, 
                                    @Disponibilidade, 
                                    @DataFabricacao, 
                                    @DataValidade)";

        private string _sqlUpdate = @"UPDATE 
                                    TBProduto 
                                    SET 
                                    Nome = @Nome, 
                                    PrecoVenda = @PrecoVenda, 
                                    PrecoCusto = @PrecoCusto, 
                                    Disponibilidade = @Disponibilidade, 
                                    DataFabricacao = @DataFabricacao, 
                                    DataValidade = @DataValidade 
                                    where Id = @Id";

        private string _sqlGetById = @"select *from TBProduto where Id = @Id";

        private string _sqlDelete = @"DELETE FROM TBProduto
                                    WHERE Id = @Id";

        private string _sqlGetAll = @"SELECT 
                                    Id,
                                    Nome, 
                                    PrecoVenda, 
                                    PrecoCusto, 
                                    Disponibilidade, 
                                    DataFabricacao, 
                                    DataValidade
                                    FROM
                                    TBProduto";

        public Produto Save(Produto produto)
        {
            produto.Validacao();
            produto.Id = Db.Insert(_sqlAdd, Take(produto));
            return produto;
        }

        public void Update(Produto produto)
        {
            produto.Validacao();
            Db.Update(_sqlUpdate, Take(produto));
        }

        public void Delete(Produto produto)
        {
            Db.Delete(_sqlDelete, Take(produto));
        }

        public Produto Get(long id)
        {
            Produto produto = Db.Get<Produto>(_sqlGetById, Make, new object[] { "@Id", id });
            return produto;
        }

        public IEnumerable<Produto> GetAll()
        {
            return Db.GetAll<Produto>(_sqlGetAll, Make);
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Produto> Make = reader =>
           new Produto
           {
               Id = Convert.ToInt64(reader["Id"]),
               //Nome = reader["Nome"].ToString(),
               //PrecoCusto = Convert.ToInt64(reader["PrecoCusto"]),
               //PrecoVenda = Convert.ToInt64(reader["PrecoVenda"]),
               //Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
               //DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
               //DataValidade = Convert.ToDateTime(reader["DataValidade"])
           };

        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="produto">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Produto produto)
        {
            return new object[]
            {
                "@Id", produto.Id,
                "@Nome", produto.Nome,
                "@PrecoVenda", produto.PrecoVenda,
                "@Disponibilidade", produto.Disponibilidade,
                "@PrecoCusto", produto.PrecoCusto,
                "@DataFabricacao", produto.DataFabricacao,
                "@DataValidade", produto.DataValidade
            };
        }
    }
}
