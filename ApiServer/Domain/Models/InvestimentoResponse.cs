using System.ComponentModel;

namespace ApiServer.Domain.Models
{

    /// <summary>
    /// Retorna os valores após o calculo de investimento em CDB
    /// </summary>
    public class InvestimentoResponse
    {
        [DisplayName("Resultado Bruto")]
        public decimal ResultadoBruto { get; set; }
        [DisplayName("Resultado Liquido")]
        public decimal ResultadoLiquido { get; set; }
    }
}
