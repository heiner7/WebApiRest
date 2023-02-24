using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.DTOs
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
