using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Repositories.Scripts
{
    public class ConvenioScript
    {
        internal readonly static string SELECT_CONVENIO = @"SELECT *
                FROM 
	                [Cosmos_v14b].dbo.[RC_EMPRESA_CONVENIO] WITH (NOLOCK)
                WHERE 
                    EMCO_ID_EMPRESA_EPHARMA = @IdEpharma";

		public static string InsertConvenio(string idEpharma, string nomeFantasia, string razaoSocial, string cnpj,  string ativo, string data,
											string idUsuario, string idLock, string layoutNome, string layoutFlag, string mecanicaDesconto,
											string separador, string delimitador, string exigeValidacaoUsuario)
		{
			string insertConvenio = String.Format(@"INSERT INTO [cosmos_v14b].dbo.[RC_EMPRESA_CONVENIO] (EMCO_ID_EMPRESA_EPHARMA, EMCO_NM_FANTASIA, EMCO_NM_RAZAOSOCIAL, EMCO_TN_CNPJ, EMCO_FL_ATIVO, XXXX_DH_CAD, XXXX_CD_USUCAD, XXXX_DH_ALT, XXXX_CD_USUALT, XXXX_CT_LOCK, LAYOUT_NOME, LAYOUT_FLAG, EMCO_MECANICA_DESCONTO, SEPARADOR, DELIMITADOR, EXIGE_VALIDACAO_USUARIO) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');", 
													idEpharma, nomeFantasia, razaoSocial, cnpj, ativo, data, idUsuario, idLock, 
													layoutNome, layoutFlag, mecanicaDesconto, separador, delimitador, exigeValidacaoUsuario);

			return insertConvenio;
		}
    }
}
