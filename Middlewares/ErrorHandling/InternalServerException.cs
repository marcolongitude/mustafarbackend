using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mustafarbackend.Middlewares.ErrorHandling
{
    public class InternalServerException : CustomException
    {
        public InternalServerException(string message, List<string>? errors = default) : base(message, errors, HttpStatusCode.InternalServerError)
        {
        }
    }
}