using Gerenciador_Mensagens.Archive;
using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Message
{
    internal class MArquivo : AMensagem
    {
        public Arquivo Conteudo { get; }
        
        public MArquivo(string mensagem, Arquivo arquivo) : base(mensagem)
        {
            TipoConteudo = "arquivo";
            TipoEnvio = "usuario";
            Conteudo = arquivo;
        }
    }
}
