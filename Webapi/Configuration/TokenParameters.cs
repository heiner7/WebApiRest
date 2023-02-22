using Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Configuration
{
    public class TokenParameters : ITokenParamaters
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
        public string Rol { get; set; }
    }
}
