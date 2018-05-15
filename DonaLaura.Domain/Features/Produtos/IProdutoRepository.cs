using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos
{
    public interface IProdutoRepository
    {
        Produto Save(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        Produto Get(long id);
        IEnumerable<Produto> GetAll();
    }
}
