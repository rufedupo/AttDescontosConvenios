using AttDescontosConvenios.Entities;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Repositories.Interfaces
{
    public interface IConvenioRepository
    {
        Task<Convenio> Get(int idEpharma);

        Task Add(Convenio convenio);
    }
}
