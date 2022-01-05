using AttDescontosConvenios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Repositories.Interfaces
{
    public interface IDescontoRepository
    {
        Task<IEnumerable<Desconto>> Get(int idConvenio);

        Task<int> GetUltimoCodigo();

        Task Add(Desconto desconto);
    }
}
