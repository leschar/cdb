using ApiServer.Infra.Repositories;
using Xunit;

namespace NetFrameworkTests.Repository
{
    public class CDIRepositoryTests
    {
        [Fact]
        public void TB_Deve_Retornar_Com_Valores_Corretos()
        {
            // Arrange
            var tbRepository = new TBRepository();

            // Act
            var tbValues = tbRepository.TB();

            // Assert
            Assert.NotNull(tbValues);
            Assert.Equal(4, tbValues.Count);

            Assert.True(tbValues.ContainsKey(6));
            Assert.Equal(1.08m, tbValues[6]);

            Assert.True(tbValues.ContainsKey(12));
            Assert.Equal(1.08m, tbValues[12]);

            Assert.True(tbValues.ContainsKey(24));
            Assert.Equal(1.08m, tbValues[24]);

            Assert.True(tbValues.ContainsKey(int.MaxValue));
            Assert.Equal(1.08m, tbValues[int.MaxValue]);
        }
    }
}
