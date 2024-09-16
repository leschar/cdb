using ApiServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApiServer.Infra.Repositories
{
    [ExcludeFromCodeCoverage]

    public class CDIRepository : ICDIRepository
    {
        /// <summary>
        /// Retorna um dicionário apenas para simular um banco de dados
        /// Os valores aqui poderiam estar parametrizados em banco de dados facilitando manutenção e correções
        /// </summary>
        /// <returns>Dictionary<int, decimal></returns>
        public Dictionary<int, decimal> CDI() => new Dictionary<int, decimal>
                {
                    { 6, 0.009m },
                    { 12, 0.009m },
                    { 24, 0.009m },
                    { int.MaxValue, 0.009m }
                };
    }
}
