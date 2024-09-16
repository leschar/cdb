using ApiServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApiServer.Infra.Repositories
{
    [ExcludeFromCodeCoverage]

    public class ImpostoRepository : IImpostoRepository
    {
        /// <summary>
        /// Retorna um dicionário apenas para simular um banco de dados
        /// Os valores aqui poderiam estar parametrizados em banco de dados facilitando manutenção e correções
        /// </summary>
        /// <returns>Dictionary<int, decimal></returns>
        public Dictionary<int, decimal> Imposto() => new Dictionary<int, decimal>
            {
                { 6, 0.225m },
                { 12, 0.2m },
                { 24, 0.175m },
                { int.MaxValue, 0.15m }
            };
    }
}
