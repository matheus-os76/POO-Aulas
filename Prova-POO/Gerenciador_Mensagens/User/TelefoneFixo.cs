using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.User
{
    internal class TelefoneFixo : ATelefone
    {
        // To deixando essa classe existir mas só por enfeite mesmo
        // Pra escalabilidade deve ser bom fazer uma classe assim
        // Mas para os propositos desse programa ela existir é só um enfeito mesmo
        
        public string Numero { get; private set; }
        public string DDD { get; private set; }
        public string Tipo { get; }

        public TelefoneFixo(string ddd, string telefone, string tipo)
        {
            this.Numero = telefone;
            this.DDD = ddd;
            this.Tipo = tipo;
        }

        public override void alterarDDD(string ddd)
        {
            DDD = ddd;
        }
        public override void alterarNumero(string num)
        {
            Numero = num;
        }
    }
}
