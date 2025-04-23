using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes
{
    public class Mensagem
    {
        public Mensagem(Usuario destinatario, string mensagem) 
        {
            Destinatario = destinatario;
            Conteudo = mensagem;
        }

        public Usuario Destinatario { get; }
        public string Conteudo { get; }
    }
}
