using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Message
{
    internal abstract class AMensagem
    {
        public string Mensagem { get; }
        public string TipoConteudo { get; protected set; }
        public string TipoEnvio { get; protected set; }

        public AMensagem(string mensagem)
        {
            if (!StringUtils.stringValida(mensagem))
            {
                throw new ArgumentException();
            }

            Mensagem = mensagem;
        }
    }
}
