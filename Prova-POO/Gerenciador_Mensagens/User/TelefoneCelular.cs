using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.User
{
    internal class TelefoneCelular : ATelefone
    {
        public string Numero { get; private set; }
        public string DDD { get; private set; }
        public string Tipo { get; }

        public TelefoneCelular(string ddd, string telefone, string tipo) 
        {
            this.Numero = telefone;
            this.DDD = ddd;
            this.Tipo = tipo;
        }

        public override string ToString()
        {
            string numero_formatado = string.Concat(Numero.Substring(0, 5), '-', Numero.Substring(5));
            return string.Concat(DDD, ' ', numero_formatado);
        }

    }
}
