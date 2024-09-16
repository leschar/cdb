using System.Collections.Generic;

namespace ApiServer.Domain.Interfaces
{
    public interface ITBRepository
    {
        Dictionary<int, decimal> TB();
    }
}
