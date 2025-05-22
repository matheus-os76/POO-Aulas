using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Message
{
    internal abstract class AMensagem
    {
        public abstract string Mensagem { get; }
        public string Tipo { get; protected set; }
        public abstract List<object> listaConteudo(); 
    }
}
