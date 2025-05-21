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

        private Canal(string nome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentNullException("Não existe um canal com esse nome");
            }

            this.Nome = nome;
        }

        public static Canal Facebook => new Canal("Facebook");
        public static Canal Instagram => new Canal("Instagram");
        public static Canal Telegram => new Canal("Telegram");
        public static Canal Whatsapp => new Canal("Whatsapp");
    }
}
