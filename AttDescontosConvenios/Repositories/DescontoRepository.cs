using AttDescontosConvenios.Entities;
using AttDescontosConvenios.Repositories.Interfaces;
using System.Threading.Tasks;
using Dapper;
using Pmenos.Core.Data.Connection.Factories.Interfaces;
using Pmenos.Core.Data.Repositories.Dapper;
using AttDescontosConvenios.Repositories.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AttDescontosConvenios.Repositories
{
    public class DescontoRepository : DapperRepository<Desconto>, IDescontoRepository
    {
        public DescontoRepository(IDbConnectionFactory connectionFactory)
            : base(connectionFactory)
        { }

        public async Task<IEnumerable<Desconto>> Get(int idConvenio)
        {
            var parametros = new
            {
                idConvenio = idConvenio
            };

            using (var conexao = connectionFactory.CreateConnection())
            {
                try
                {
                    var query = DescontoScript.SELECT_DESCONTOS;
                    var result = await conexao.QueryAsync<Desconto>(query, parametros, null, 120);

                    return result.ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<int> GetUltimoCodigo()
        {
            using (var conexao = connectionFactory.CreateConnection())
            {
                try
                {
                    var query = DescontoScript.SELECT_ULT_ID;
                    var desconto = await conexao.QueryFirstOrDefaultAsync<Desconto>(query, null, null, 120);
                    int id = desconto == null ? 0 : desconto.ID;
                    return id;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task Add(Desconto desconto)
        {
            string insertDesconto = DescontoScript.InsertDesconto(desconto.ID.ToString(), desconto.EMCO_ID_EMPRESA_CONVENIO.ToString(),
                    desconto.CACO_ID_CARACTERISTICA.ToString(), desconto.DECO_VALOR_CARACTERISTICA, desconto.DECO_VALOR_DESCONTO.ToString(), 
                    desconto.DECO_TIPO_DESCONTO, desconto.XXXX_DH_CAD.ToString("yyyy-MM-dd HH:mm"), desconto.XXXX_CD_USUCAD.ToString(),
                    desconto.XXXX_CT_LOCK.ToString());

            using StreamWriter file = new(@"C:\Users\90005210\Documents\Work\Consulta previa\insertDescontos.sql", append: true);

            await file.WriteLineAsync(insertDesconto);
        }
    }
}
