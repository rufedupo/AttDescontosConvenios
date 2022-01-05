using AttDescontosConvenios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Services.Interfaces
{
    public interface IDescontoService
    {
        Task AtualizarDescontos(int id, int idCaracteristica, string valorCaracteristica, decimal desconto, Convenio convenio);

        Task<IEnumerable<Desconto>> GetDescontos(int idConvenio);

        Task<int> GetUltimoCodigo ();
    }
}
