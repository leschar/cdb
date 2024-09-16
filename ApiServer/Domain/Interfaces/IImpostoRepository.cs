using System.Collections.Generic;

namespace ApiServer.Domain.Interfaces
{
    public interface IImpostoRepository
    {
        Dictionary<int, decimal> Imposto();
    }
}
