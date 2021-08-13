using Microsoft.AspNetCore.Mvc;

namespace NetfritzServices.CadastroService.Domain.Shared
{
    public static class Response
    {
        public static IActionResult CreateResponse(object body, int status)
        {
            return new ObjectResult(body)
            {
                StatusCode = status
            };
        }

    }
}