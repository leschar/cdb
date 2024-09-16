using System.ComponentModel.DataAnnotations;

namespace ApiServer.Domain.Models
{
    /// <summary>
    /// Modelo de dados para calculo do CDB
    /// </summary>
    public class InvestimentoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser um valor positivo e maior que 0.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(2, 1200, ErrorMessage = "A duração em meses deve ser entre 2 e 1200.")]
        public short Meses { get; set; }
    }
}
