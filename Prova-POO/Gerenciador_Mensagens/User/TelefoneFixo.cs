using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.User
{
    internal class TelefoneFixo : ATelefone
    {
        public string Numero { get; private set; }
        public string DDD { get; private set; }
        public string Tipo { get; }

        public TelefoneFixo(string ddd, string telefone, string tipo)
        {
            this.Numero = telefone;
            this.DDD = ddd;
            this.Tipo = tipo;
        }
    }
}
