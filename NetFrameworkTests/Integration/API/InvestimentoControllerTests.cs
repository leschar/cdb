using Xunit;
using ApiServer.Domain.Interfaces;
using ApiServer.Controllers;
using ApiServer.Domain.Models;
using System.Net;
using ApiServer.Domain.Services;
using System.Web.Http.Results;
using Moq;
using System.Collections.Generic;

namespace NetFrameworkTests
{
    public class InvestimentoControllerTests
    {
        private readonly InvestimentoController _controller;
        private readonly IInvestimentoService _service;

        public InvestimentoControllerTests()
        {
            var cdiRepositoryMock = new Mock<ICDIRepository>();
            var impostoRepositoryMock = new Mock<IImpostoRepository>();
            var tbRepositoryMock = new Mock<ITBRepository>();

            cdiRepositoryMock.Setup(repo => repo.CDI())
                             .Returns(new Dictionary<int, decimal>
                             {
                                 { 6, 0.225m },
                                 { 12, 0.2m },
                                 { 24, 0.175m },
                                 { int.MaxValue, 0.15m }
                             });

            impostoRepositoryMock.Setup(repo => repo.Imposto())
                                 .Returns(new Dictionary<int, decimal>
                                 {
                                     { 6, 0.1m },
                                     { 12, 0.08m },
                                     { 24, 0.05m },
                                     { int.MaxValue, 0.01m }
                                 });

            tbRepositoryMock.Setup(repo => repo.TB())
                            .Returns(new Dictionary<int, decimal>
                            {
                                { 6, 0.05m },
                                { 12, 0.07m },
                                { 24, 0.1m },
                                { int.MaxValue, 0.12m }
                            });

            _service = new InvestimentoServices(cdiRepositoryMock.Object, impostoRepositoryMock.Object, tbRepositoryMock.Object);

            _controller = new InvestimentoController(_service);
        }

        [Fact]
        public void CalcularInvestimento_WithValidInput_ReturnsOk()
        {
            // Arrange
            var request = new InvestimentoRequest { Valor = 100m, Meses = 6 };

            // Act
            var actionResult = _controller.CalcularInvestimento(request);

            // Assert
            Assert.IsType<OkNegotiatedContentResult<InvestimentoResponse>>(actionResult);
            var contentResult = (OkNegotiatedContentResult<InvestimentoResponse>)actionResult;
            Assert.NotNull(contentResult.Content);
        }

        [Fact]
        public void CalcularInvestimento_WithInvalidInput_ReturnsBadRequest()
        {
            // Arrange
            var request = new InvestimentoRequest { Valor = 0, Meses = 1 };
            _controller.ModelState.AddModelError("key", "message");

            // Act
            var actionResult = _controller.CalcularInvestimento(request);

            // Assert
            Assert.IsType<NegotiatedContentResult<object>>(actionResult);
            var contentResult = (NegotiatedContentResult<object>)actionResult;
            Assert.Equal(HttpStatusCode.BadRequest, contentResult.StatusCode);
            Assert.NotNull(contentResult.Content);
        }
    }
}

