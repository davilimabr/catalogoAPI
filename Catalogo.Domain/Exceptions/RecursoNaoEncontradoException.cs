using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Exceptions
{
    public class RecursoNaoEncontradoException : Exception, IException
    {
        public IEnumerable<string> Mensagens { get; set; }

        public RecursoNaoEncontradoException(string mensagem = "Recurso não encontrado.") =>
           Mensagens = new List<string>()
           {
               mensagem
           };

        public RecursoNaoEncontradoException(IEnumerable<string> mensagens) =>
            Mensagens = mensagens;
    }
}
