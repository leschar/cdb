using System.Collections.Generic;

namespace ApiServer.Domain.Interfaces
{
    public interface ICDIRepository
    {
        Dictionary<int, decimal> CDI();
    }
}
