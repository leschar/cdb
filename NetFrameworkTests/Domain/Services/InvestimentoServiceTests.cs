using ApiServer.Domain.Interfaces;
using ApiServer.Domain.Models;
using ApiServer.Domain.Services;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace NetFrameworkTests.Domain.Services
{
    public class InvestimentoServiceTests
    {
        private readonly Dictionary<int, decimal> _cdiDictionary;
        private readonly Dictionary<int, decimal> _impostoDictionary;
        private readonly Dictionary<int, decimal> _tbDictionary;

        public InvestimentoServiceTests()
        {
            _cdiDictionary = new Dictionary<int, decimal>
            {
                { 6, 0.009m },
                { 12, 0.009m },
                { 24, 0.009m },
                { int.MaxValue, 0.009m }
            };
            _impostoDictionary = new Dictionary<int, decimal>
            {
                { 6, 0.225m },
                { 12, 0.2m },
                { 24, 0.175m },
                { int.MaxValue, 0.15m }
            };
            _tbDictionary = new Dictionary<int, decimal>
            {
                { 6, 1.08m },
                { 12, 1.08m },
                { 24, 1.08m },
                { int.MaxValue, 1.08m }
            };
        }


        [Fact]
        public void CalcularInvestimento_ReturnsCorrectResultsForSixMounths()
        {
            // Arrange
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();


            cdiRepositoryMock.Setup(repo => repo.CDI()).Returns(_cdiDictionary);
            impostoRepositoryMock.Setup(repo => repo.Imposto()).Returns(_impostoDictionary);
            tbRepositoryMock.Setup(repo => repo.TB()).Returns(_tbDictionary);

            var investmentService = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object);

            var investimento = new InvestimentoRequest { Valor = 100, Meses = 6 };

            // Act
            var result = investmentService.CalcularInvestimento(investimento);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<InvestimentoResponse>();
            result.ResultadoBruto.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investimento.Valor);

            result.ResultadoLiquido.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investimento.Valor);

            Assert.Equal(105.98m, result.ResultadoBruto);
            Assert.Equal(104.63m, result.ResultadoLiquido);

        }

        [Fact]
        public void CalcularInvestimento_ReturnsCorrectResultsForTwelveMounths()
        {
            // Arrange
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();

            cdiRepositoryMock.Setup(repo => repo.CDI()).Returns(_cdiDictionary);
            impostoRepositoryMock.Setup(repo => repo.Imposto()).Returns(_impostoDictionary);
            tbRepositoryMock.Setup(repo => repo.TB()).Returns(_tbDictionary);

            var investmentService = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object);

            var investment = new InvestimentoRequest { Valor = 100, Meses = 12 };

            // Act
            var result = investmentService.CalcularInvestimento(investment);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<InvestimentoResponse>();
            result.ResultadoBruto.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            result.ResultadoLiquido.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            Assert.Equal(112.31m, result.ResultadoBruto);
            Assert.Equal(109.85m, result.ResultadoLiquido);

        }

        [Fact]
        public void CalcularInvestimento_ReturnsCorrectResultsForFoutyMounths()
        {
            // Arrange
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();

            cdiRepositoryMock.Setup(repo => repo.CDI()).Returns(_cdiDictionary);
            impostoRepositoryMock.Setup(repo => repo.Imposto()).Returns(_impostoDictionary);
            tbRepositoryMock.Setup(repo => repo.TB()).Returns(_tbDictionary);

            var investmentService = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object);

            var investment = new InvestimentoRequest { Valor = 100, Meses = 24 };

            // Act
            var result = investmentService.CalcularInvestimento(investment);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<InvestimentoResponse>();
            result.ResultadoBruto.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            result.ResultadoLiquido.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            Assert.Equal(126.13m, result.ResultadoBruto);
            Assert.Equal(121.56m, result.ResultadoLiquido);

        }

        [Fact]
        public void CalcularInvestimento_ReturnsCorrectResultsMoreThanFoutyMounths()
        {
            // Arrange
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();

            cdiRepositoryMock.Setup(repo => repo.CDI()).Returns(_cdiDictionary);
            impostoRepositoryMock.Setup(repo => repo.Imposto()).Returns(_impostoDictionary);
            tbRepositoryMock.Setup(repo => repo.TB()).Returns(_tbDictionary);

            var investmentService = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object);

            var investment = new InvestimentoRequest { Valor = 100, Meses = 25 };

            // Act
            var result = investmentService.CalcularInvestimento(investment);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<InvestimentoResponse>();
            result.ResultadoBruto.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            result.ResultadoLiquido.GetType().Should().Be(typeof(decimal));
            result.ResultadoBruto.Should().BeGreaterThan(investment.Valor);

            Assert.Equal(127.36m, result.ResultadoBruto);
            Assert.Equal(123.25m, result.ResultadoLiquido);

        }

        [Theory]
        [InlineData(6, 100)]
        [InlineData(12, 100)]
        [InlineData(18, 100)]
        [InlineData(24, 100)]
        [InlineData(36, 100)]
        [InlineData(40, 0)]
        public void GetValueForTerm_ReturnsCorrectValue(int durationMonths, decimal expectedValue)
        {
            // Arrange
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();

            var investmentService = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object); // Replace with actual instances if needed
            var dictionary = new Dictionary<int, decimal>
            {
                { 6, 100m },
                { 12, 100m },
                { 18, 100m },
                { 24, 100m },
                { 36, 100m }
            };

            // Act
            var result = investmentService.ObterVAlores(dictionary, durationMonths);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
