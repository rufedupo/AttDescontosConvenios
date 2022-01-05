using System;
using System.ComponentModel.DataAnnotations;

namespace AttDescontosConvenios.Entities
{
    public class Convenio
    {
		public Convenio(int EMCO_ID_EMPRESA_EPHARMA, string EMCO_NM_FANTASIA, string EMCO_NM_RAZAOSOCIAL,
			string EMCO_TN_CNPJ, string EMCO_FL_ATIVO, DateTime XXXX_DH_CAD, int XXXX_CD_USUCAD, DateTime XXXX_DH_ALT, int XXXX_CD_USUALT,
			int XXXX_CT_LOCK, string LAYOUT_NOME, string LAYOUT_FLAG, string EMCO_MECANICA_DESCONTO,
			string SEPARADOR, string DELIMITADOR, bool EXIGE_VALIDACAO_USUARIO
			) 
		{
			this.EMCO_ID_EMPRESA_EPHARMA = EMCO_ID_EMPRESA_EPHARMA;
			this.EMCO_NM_FANTASIA = EMCO_NM_FANTASIA;
			this.EMCO_NM_RAZAOSOCIAL = EMCO_NM_RAZAOSOCIAL;
			this.EMCO_TN_CNPJ = EMCO_TN_CNPJ;
			this.EMCO_FL_ATIVO = EMCO_FL_ATIVO;
			this.XXXX_DH_CAD = XXXX_DH_CAD;
			this.XXXX_CD_USUCAD = XXXX_CD_USUCAD;
			this.XXXX_DH_ALT = XXXX_DH_ALT;
			this.XXXX_CD_USUALT = XXXX_CD_USUALT;
			this.XXXX_CT_LOCK = XXXX_CT_LOCK;
			this.LAYOUT_NOME = LAYOUT_NOME;
			this.LAYOUT_FLAG = LAYOUT_FLAG;
			this.EMCO_MECANICA_DESCONTO = EMCO_MECANICA_DESCONTO;
			this.SEPARADOR = SEPARADOR;
			this.DELIMITADOR = DELIMITADOR;
			this.EXIGE_VALIDACAO_USUARIO = EXIGE_VALIDACAO_USUARIO;
		}

		public Convenio() { }

		public int EMCO_ID_EMPRESA_CONVENIO { get; set; }

		public int EMCO_ID_EMPRESA_EPHARMA { get; set; }

		public string EMCO_NM_FANTASIA { get; set; }

		public string EMCO_NM_RAZAOSOCIAL { get; set; }

		public string EMCO_TN_CNPJ { get; set; }

		public string EMCO_FL_ATIVO { get; set; }

		public DateTime XXXX_DH_CAD { get; set; }

		public int XXXX_CD_USUCAD { get; set; }

		public DateTime XXXX_DH_ALT { get; set; }

		public int XXXX_CD_USUALT { get; set; }

		public int XXXX_CT_LOCK { get; set; }

		public string LAYOUT_NOME { get; set; }

		public string LAYOUT_FLAG { get; set; }

		public string EMCO_MECANICA_DESCONTO { get; set; }

		public string SEPARADOR { get; set; }

		public string DELIMITADOR { get; set; }

		public bool EXIGE_VALIDACAO_USUARIO { get; set; }
	}
}
