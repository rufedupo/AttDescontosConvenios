using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttDescontosConvenios.Repositories.Scripts
{
    public class DescontoScript
    {
        internal readonly static string SELECT_DESCONTOS = @"SELECT *
                FROM 
	                [Cosmos_v14b].dbo.[RC_DESCONTO_CONVENIO] WITH (NOLOCK)
                WHERE 
                    EMCO_ID_EMPRESA_CONVENIO = @IdConvenio";

        internal readonly static string SELECT_ULT_ID = @"
                    SELECT top 1 [ID]
                    FROM [cosmos_v14b]..[RC_DESCONTO_CONVENIO] WITH (NOLOCK)
                    ORDER BY [ID] DESC
                ";

		public static string InsertDesconto(string id, string idConvenio, string idCaracteristica, string valorCaracteristica, 
											string valorDesconto, string tipoDesconto, string data, string idUsuario, string idLock)
		{
			string insertDesconto = String.Format(@"INSERT INTO [cosmos_v14b].dbo.[RC_DESCONTO_CONVENIO] (ID, EMCO_ID_EMPRESA_CONVENIO, CACO_ID_CARACTERISTICA, DECO_VALOR_CARACTERISTICA, DECO_VALOR_DESCONTO, DECO_TIPO_DESCONTO, XXXX_DH_CAD, XXXX_CD_USUCAD, XXXX_CT_LOCK) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
													id, idConvenio, idCaracteristica, valorCaracteristica, valorDesconto.Replace(",", "."), tipoDesconto, 
													data, idUsuario, idLock);

			return insertDesconto;
		}
    }
}
