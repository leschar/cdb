using ApiServer.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace NetFrameworkTests.Repository
{
    public class ImpostoRepositoryTests
    {
        [Fact]
        public void Imposto_Deve_Retornar_Corretamente_Com_Mock()
        {
            // Arrange
            var valoresEsperados = new Dictionary<int, decimal>
        {
            { 6, 0.225m },
            { 12, 0.2m },
            { 24, 0.175m },
            { int.MaxValue, 0.15m }
            };

            var mockImpostoRepository = new Mock<IImpostoRepository>();
            mockImpostoRepository.Setup(repo => repo.Imposto()).Returns(valoresEsperados);

            var impostoRepository = mockImpostoRepository.Object;

            // Act
            var taxValues = impostoRepository.Imposto();

            // Assert
            taxValues.Should().NotBeNull().And.HaveCount(valoresEsperados.Count);

            foreach (var expectedValue in valoresEsperados)
            {
                taxValues.Should().ContainKey(expectedValue.Key);
                taxValues[expectedValue.Key].Should().Be(expectedValue.Value);
            }
        }
    }
}
