using AttDescontosConvenios.Entities;
using AttDescontosConvenios.Repositories.Interfaces;
using AttDescontosConvenios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Services
{
    public class DescontoService : IDescontoService
    {
        private readonly IDescontoRepository _descontoRepository;

        public DescontoService(IDescontoRepository descontoRepository)
        {
            _descontoRepository = descontoRepository;
        }

        public async Task AtualizarDescontos(int id, int idCaracteristica, string valorCaracteristica, decimal desconto, Convenio convenio)
        {
            var data = DateTime.Now;
            var userId = 1456;
            var lockId = 1;

            await _descontoRepository.Add(new Desconto(
                       id,
                       convenio.EMCO_ID_EMPRESA_CONVENIO,
                       idCaracteristica,
                       valorCaracteristica,
                       desconto,
                       "P",
                       data,
                       userId,
                       lockId
                       ));
        }

        public async Task<IEnumerable<Desconto>> GetDescontos(int idConvenio)
        {
            var result = await _descontoRepository.Get(idConvenio);

            return result;
        }

        public async Task<int> GetUltimoCodigo()
        {
            var result = await _descontoRepository.GetUltimoCodigo();

            return result;
        }
    }
}
