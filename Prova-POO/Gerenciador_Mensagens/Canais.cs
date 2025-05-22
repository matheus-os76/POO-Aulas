using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class Canal
    {
        public string Nome { get; }
        public string Tipo { get; }

        private Canal(string nome, string tipo)
        {
            if (!StringUtils.nomeValido(nome, 25, 2))
            {
                throw new ArgumentException();
            }

            this.Nome = nome;
            this.Tipo = tipo;
        }

        public static Canal Facebook => new Canal("Facebook", "arquivos");
        public static Canal Instagram => new Canal("Instagram", "arquivos");
        public static Canal Telegram => new Canal("Telegram", "universal");
        public static Canal Whatsapp => new Canal("Whatsapp", "texto");
    }
}
