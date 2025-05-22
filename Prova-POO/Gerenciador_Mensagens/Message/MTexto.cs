using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.Message
{
    internal class MTexto : AMensagem
    {
        public DateTime DataEnvio { get; }
        public MTexto(string mensagem) : base(mensagem)
        {
            DataEnvio = DateTime.Now;
            TipoConteudo = "texto";
            TipoEnvio = "telefone";
        }
    }
}
