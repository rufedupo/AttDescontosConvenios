using AttDescontosConvenios.Repositories.Interfaces;
using AttDescontosConvenios.Services.Interfaces;
using AttDescontosConvenios.Entities;
using ClosedXML.Excel;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AttDescontosConvenios.Services
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;
        private readonly IDescontoService _descontoService;

        public ConvenioService(IConvenioRepository convenioRepository, IDescontoService descontoService)
        {
            _convenioRepository = convenioRepository;
            _descontoService = descontoService;
        }

        public async Task AtualizarConvenios()
        {
            var xls = new XLWorkbook(@"C:\Users\90005210\Documents\Work\Consulta previa\convenios.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Report");
            var totalLinhas = planilha.Rows().Count();
            int ultimoCod = await _descontoService.GetUltimoCodigo();

            for (int l = 4; l <= totalLinhas; l++)
            {
                var codigo = int.Parse(planilha.Cell($"C{l}").Value.ToString());
                var nomeFantasia = planilha.Cell($"D{l}").Value.ToString();
                var razaoSocial = planilha.Cell($"E{l}").Value.ToString();
                var cnpj = Convert.ToUInt64(planilha.Cell($"F{l}").Value).ToString(@"00\.000\.000\/0000\-00");
                var ativo = planilha.Cell($"G{l}").Value.ToString() == "ATIVO" ? "S" : "N";
                var data = DateTime.Now;
                var userId = 1456;

                var convenio = await _convenioRepository.Get(codigo);

                // INSERIR CASO ESTEJA FALTANDO
                if (convenio == null)
                {
                    await _convenioRepository.Add(new Convenio (
                        codigo,
                        nomeFantasia,
                        razaoSocial,
                        cnpj,
                        ativo,
                        data,
                        userId,
                        data,
                        userId,
                        1,
                        "NOME",
                        "OPERACAO",
                        "PMC",
                        ".",
                        "",
                        true
                        ));
                } 
                else
                {
                    //ATUALIZAR TABELA DESCONTOS
                    var descontos = await _descontoService.GetDescontos(convenio.EMCO_ID_EMPRESA_CONVENIO);
                    
                    var descontoMedicamento = planilha.Cell($"AF{l}").Value.ToString();
                    if (descontoMedicamento != null && descontoMedicamento != "" && descontoMedicamento != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 1 && d.DECO_VALOR_CARACTERISTICA == "5").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 1, "5", decimal.Parse(descontoMedicamento), convenio);
                    }

                    var descontoOTC = planilha.Cell($"AG{l}").Value.ToString();
                    if (descontoOTC != null && descontoOTC != "" && descontoOTC != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 1 && d.DECO_VALOR_CARACTERISTICA == "7").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 1, "7", decimal.Parse(descontoOTC), convenio);
                    }

                    var descontoMarca = planilha.Cell($"AH{l}").Value.ToString();
                    if (descontoMarca != null && descontoMarca != "" && descontoMarca != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 4 && d.DECO_VALOR_CARACTERISTICA == "R").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 4, "R", decimal.Parse(descontoMarca), convenio);
                    }

                    var descontoGenerico = planilha.Cell($"AI{l}").Value.ToString();
                    if (descontoGenerico != null && descontoGenerico != "" && descontoGenerico != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 4 && d.DECO_VALOR_CARACTERISTICA == "G").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 4, "G", decimal.Parse(descontoGenerico), convenio);
                    }

                    var descontoSimilar = planilha.Cell($"AJ{l}").Value.ToString();
                    if (descontoSimilar != null && descontoSimilar != "" && descontoSimilar != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 4 && d.DECO_VALOR_CARACTERISTICA == "S").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 4, "S", decimal.Parse(descontoSimilar), convenio);
                    }

                    var descontoNMedicamento = planilha.Cell($"AK{l}").Value.ToString();
                    if (descontoNMedicamento != null && descontoNMedicamento != "" && descontoNMedicamento != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 1 && d.DECO_VALOR_CARACTERISTICA == "9").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 1, "9", decimal.Parse(descontoNMedicamento), convenio);
                    }

                    var descontoAlimento = planilha.Cell($"AL{l}").Value.ToString();
                    if (descontoAlimento != null && descontoAlimento != "" && descontoAlimento != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 3 && d.DECO_VALOR_CARACTERISTICA == "2.506.005.01.00.00.00.00").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 3, "2.506.005.01.00.00.00.00", decimal.Parse(descontoAlimento), convenio);
                    }

                    var descontoDermo = planilha.Cell($"AN{l}").Value.ToString();
                    if (descontoDermo != null && descontoDermo != "" && descontoDermo != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 2 && d.DECO_VALOR_CARACTERISTICA == "DC").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 2, "DC", decimal.Parse(descontoDermo), convenio);
                    }

                    var descontoHB = planilha.Cell($"AO{l}").Value.ToString();
                    if (descontoHB != null && descontoHB != "" && descontoHB != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 1 && d.DECO_VALOR_CARACTERISTICA == "8").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 1, "8", decimal.Parse(descontoHB), convenio);
                    }

                    var descontoMInfantil = planilha.Cell($"AP{l}").Value.ToString();
                    if (descontoMInfantil != null && descontoMInfantil != "" && descontoMInfantil != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 3 && d.DECO_VALOR_CARACTERISTICA == "9.001.001.01.01.02.01.00").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 3, "9.001.001.01.01.02.01.00", decimal.Parse(descontoMInfantil), convenio);
                    }

                    var descontoDPromo = planilha.Cell($"AQ{l}").Value.ToString();
                    if (descontoDPromo != null && descontoDPromo != "" && descontoDPromo != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 2 && d.DECO_VALOR_CARACTERISTICA == "PP").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 2, "PP", decimal.Parse(descontoDPromo), convenio);
                    }

                    var descontoServicos = planilha.Cell($"AS{l}").Value.ToString();
                    if (descontoServicos != null && descontoServicos != "" && descontoServicos != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 3 && d.DECO_VALOR_CARACTERISTICA == "3.901.000.00.00.00.00.00").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 3, "3.901.000.00.00.00.00.00", decimal.Parse(descontoServicos), convenio);
                    }

                    var descontoCartao = planilha.Cell($"AT{l}").Value.ToString();
                    if (descontoCartao != null && descontoCartao != "" && descontoCartao != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 3 && d.DECO_VALOR_CARACTERISTICA == "3.901.102.00.00.00.00.00").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 3, "3.901.102.00.00.00.00.00", decimal.Parse(descontoCartao), convenio);
                    }

                    var descontoClinic = planilha.Cell($"AU{l}").Value.ToString();
                    if (descontoClinic != null && descontoClinic != "" && descontoClinic != "0" && descontos.Where(d => d.CACO_ID_CARACTERISTICA == 3 && d.DECO_VALOR_CARACTERISTICA == "3.901.103.00.00.00.00.00").Count() == 0)
                    {
                        ultimoCod++;
                        await _descontoService.AtualizarDescontos(ultimoCod, 3, "3.901.103.00.00.00.00.00", decimal.Parse(descontoClinic), convenio);
                    }
                }
            }
        }
    }
}
