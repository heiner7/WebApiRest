using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface ITokenParamaters
    {
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string Id { get; set; }
        public string Rol { get; set; }
    }
}
