using AttDescontosConvenios.Entities;
using AttDescontosConvenios.Repositories.Interfaces;
using System.Threading.Tasks;
using Dapper;
using Pmenos.Core.Data.Connection.Factories.Interfaces;
using Pmenos.Core.Data.Repositories.Dapper;
using AttDescontosConvenios.Repositories.Scripts;
using System;
using System.IO;

namespace AttDescontosConvenios.Repositories
{
    public class ConvenioRepository : DapperRepository<Convenio>, IConvenioRepository
    {

        public ConvenioRepository(IDbConnectionFactory connectionFactory)
            : base(connectionFactory)
        { }

        public async Task Add(Convenio convenio)
        {
            string insertConvenio = ConvenioScript.InsertConvenio(convenio.EMCO_ID_EMPRESA_EPHARMA.ToString(), convenio.EMCO_NM_FANTASIA,
                    convenio.EMCO_NM_RAZAOSOCIAL, convenio.EMCO_TN_CNPJ, convenio.EMCO_FL_ATIVO, convenio.XXXX_DH_CAD.ToString("yyyy-MM-dd HH:mm"),
                    convenio.XXXX_CD_USUCAD.ToString(), convenio.XXXX_CT_LOCK.ToString(), convenio.LAYOUT_NOME, convenio.LAYOUT_FLAG,
                    convenio.EMCO_MECANICA_DESCONTO, convenio.SEPARADOR, convenio.DELIMITADOR, convenio.EXIGE_VALIDACAO_USUARIO.ToString());
            
            using StreamWriter file = new(@"C:\Users\90005210\Documents\Work\Consulta previa\insertConvenios.sql", append: true);

            await file.WriteLineAsync(insertConvenio);
        }

        public async Task<Convenio> Get(int idEpharma)
        {
            var parametros = new
            {
                idEpharma = idEpharma
            };

            using (var conexao = connectionFactory.CreateConnection())
            {
                try
                {
                    var query = ConvenioScript.SELECT_CONVENIO;
                    var result = await conexao.QueryFirstOrDefaultAsync<Convenio>(query, parametros, null, 120);

                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
