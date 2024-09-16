using ApiServer.Domain.Models;

namespace ApiServer.Domain.Interfaces
{
    public interface IInvestimentoService
    {
        InvestimentoResponse CalcularInvestimento(InvestimentoRequest investimento);
    }
}
