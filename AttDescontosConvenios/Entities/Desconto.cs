using System;

namespace AttDescontosConvenios.Entities
{
    public class Desconto
    {
		public Desconto(int ID, int EMCO_ID_EMPRESA_CONVENIO, int CACO_ID_CARACTERISTICA,
			string DECO_VALOR_CARACTERISTICA, decimal DECO_VALOR_DESCONTO, string DECO_TIPO_DESCONTO, DateTime XXXX_DH_CAD, 
			int XXXX_CD_USUCAD, int XXXX_CT_LOCK
			)
		{
			this.ID = ID;
			this.EMCO_ID_EMPRESA_CONVENIO = EMCO_ID_EMPRESA_CONVENIO;
			this.CACO_ID_CARACTERISTICA = CACO_ID_CARACTERISTICA;
			this.DECO_VALOR_CARACTERISTICA = DECO_VALOR_CARACTERISTICA;
			this.DECO_VALOR_DESCONTO = DECO_VALOR_DESCONTO;
			this.DECO_TIPO_DESCONTO = DECO_TIPO_DESCONTO;
			this.XXXX_DH_CAD = XXXX_DH_CAD;
			this.XXXX_CD_USUCAD = XXXX_CD_USUCAD;
			this.XXXX_CT_LOCK = XXXX_CT_LOCK;
		}

		public Desconto() { }

		public int ID { get; set; }

        public int EMCO_ID_EMPRESA_CONVENIO { get; set; }

        public int CACO_ID_CARACTERISTICA { get; set; }

        public string DECO_VALOR_CARACTERISTICA { get; set; }

        public decimal DECO_VALOR_DESCONTO { get; set; }

        public string DECO_TIPO_DESCONTO { get; set; }

        public DateTime XXXX_DH_CAD { get; set; }

        public int XXXX_CD_USUCAD { get; set; }

        public int XXXX_CT_LOCK { get; set; }
    }
}
