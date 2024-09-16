using ApiServer.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace NetFrameworkTests.Repository
{
    public class TBRepositoryTests
    {
        [Fact]
        public void TB_Deve_Retornar_Corretamente_Com()
        {
            // Arrange
            var mockTBRepository = new Mock<ITBRepository>();
            mockTBRepository.Setup(repo => repo.TB()).Returns(new Dictionary<int, decimal>
                    {
                        { 6, 1.08m },
                        { 12, 1.08m },
                        { 24, 1.08m },
                        { int.MaxValue, 1.08m }
                    });

            var tbRepository = mockTBRepository.Object;

            // Act
            var tbValues = tbRepository.TB();

            // Assert
            tbValues.Should().NotBeNull().And.HaveCount(4);

            tbValues.Should().ContainKey(6);
            tbValues[6].Should().Be(1.08m);

            tbValues.Should().ContainKey(12);
            tbValues[12].Should().Be(1.08m);

            tbValues.Should().ContainKey(24);
            tbValues[24].Should().Be(1.08m);

            tbValues.Should().ContainKey(int.MaxValue);
            tbValues[int.MaxValue].Should().Be(1.08m);
        }
    }
}
