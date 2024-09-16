using ApiServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApiServer.Infra.Repositories
{
    [ExcludeFromCodeCoverage]

    public class TBRepository : ITBRepository
    {
        /// <summary>
        /// Retorna um dicionário apenas para simular um banco de dados
        /// Os valores aqui poderiam estar parametrizados em banco de dados facilitando manutenção e correções
        /// </summary>
        /// <returns>Dictionary<int, decimal></returns>
        public Dictionary<int, decimal> TB() => new Dictionary<int, decimal>
                {
                    { 6, 1.08m },
                    { 12, 1.08m },
                    { 24, 1.08m },
                    { int.MaxValue, 1.08m }
                };
    }
}
