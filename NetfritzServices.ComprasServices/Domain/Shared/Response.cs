using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Domain.Shared
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
