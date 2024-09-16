using ApiServer.Domain.Interfaces;
using ApiServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("NetFrameworkTests")]
namespace ApiServer.Domain.Services
{
    public class InvestimentoServices : IInvestimentoService
    {
        private readonly ICDIRepository _cdiRepository;
        private readonly IImpostoRepository _impostoRepository;
        private readonly ITBRepository _tbRepository;

        public InvestimentoServices(ICDIRepository cdiRepository, IImpostoRepository impostoRepository, ITBRepository tbRepository)
        {
            _cdiRepository = cdiRepository;
            _impostoRepository = impostoRepository;
            _tbRepository = tbRepository;
        }


        /// <summary>
        /// Retorna valor calculado do investimento, valor final aplicado e valor descontando os impostos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>InvestimentoResponse {ResultadoBruto e ResultadoLiquido}</returns>
        public InvestimentoResponse CalcularInvestimento(InvestimentoRequest request)
        {
            decimal VI = request.Valor;
            decimal VF = 0;

            for (int i = 0; i < request.Meses; i++)
            {
                VF = VI * (1 + (ObterCDIPorMes(request.Meses) * ObterTBPorMes(request.Meses)));
                VI = VF;
            }

            decimal resultadoBruto = VF;

            decimal resultadoLiquido = resultadoBruto - ((resultadoBruto - request.Valor) * ObterImpostoPorMes(request.Meses));

            return new InvestimentoResponse
            {
                ResultadoBruto = Math.Round(resultadoBruto, 2, MidpointRounding.AwayFromZero),
                ResultadoLiquido = Math.Round(resultadoLiquido, 2, MidpointRounding.AwayFromZero)
            };
        }



        private decimal ObterCDIPorMes(int duracaoMeses)
        {
            var cdiDict = _cdiRepository.CDI();
            return ObterVAlores(cdiDict, duracaoMeses);
        }

        private decimal ObterTBPorMes(int duracaoMeses)
        {
            var tbDict = _tbRepository.TB();
            return ObterVAlores(tbDict, duracaoMeses);
        }

        private decimal ObterImpostoPorMes(int durationMonths)
        {
            var impostoDict = _impostoRepository.Imposto();
            return ObterVAlores(impostoDict, durationMonths);
        }

        protected internal decimal ObterVAlores(Dictionary<int, decimal> dictionary, int duracaoMeses)
        {
            foreach (var term in dictionary)
            {
                if (duracaoMeses <= term.Key)
                {
                    return term.Value;
                }
            }
            return 0;
        }

    }
}
