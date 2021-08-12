using Microsoft.AspNetCore.Mvc;

namespace NetfritzCadastroService.Domain.Shared
{
    public class Response
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