using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mustafarbackend.Middlewares.ErrorHandling
{
    public class ErrorResultModel
    {
        public List<string> Messages { get; set; } = new();
        public string? Source { get; set; }
        public string? Exception { get; set; }
        public string? ErrorId { get; set; }
        public string? SupportMessage { get; set; }
        public int StatusCode { get; set; }
    }
}