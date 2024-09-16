using ApiServer.Domain.Interfaces;
using ApiServer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ApiServer.Controllers
{
    public class InvestimentoController : ApiController
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoController(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IHttpActionResult CalcularInvestimento([Microsoft.AspNetCore.Mvc.FromBody] InvestimentoRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetModelStateErrors(ModelState);
                return Content(HttpStatusCode.BadRequest, errors);
            }

            var result = _investimentoService.CalcularInvestimento(request);
            return Ok(result);
        }

        private object GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string[]>();

            foreach (var key in modelState.Keys)
            {
                var errorMessages = modelState[key].Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                errors.Add(key, errorMessages);
            }

            var problemDetails = new
            {
                type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                title = "One or more validation errors occurred.",
                status = (int)HttpStatusCode.BadRequest,
                errors = errors
            };

            return problemDetails;
        }
    }
}