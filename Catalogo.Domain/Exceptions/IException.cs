using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Exceptions
{
    public interface IException
    {
        IEnumerable<string> Mensagens { get; }
    }
}
