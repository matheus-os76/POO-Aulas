using Gerenciador_Biblioteca.Interfaces;
using Gerenciador_Biblioteca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes_Biblioteca
{
    public class Mensagem_Biblioteca : IMensagem
    {
        public Mensagem_Biblioteca(Mensagem mensagem, string? assunto = null)
        {
            if (assunto == null)
            {
                tipo = mensagem.Destinatario.Telefone;
            }
            else
            {
                tipo = mensagem.Destinatario.Email;
                Assunto = assunto;
            }

            this.mensagem = mensagem;
        }
        public Mensagem mensagem { get; set; }
        public object tipo { get; set; }
        public string? Assunto { get; set; }
    }
}
