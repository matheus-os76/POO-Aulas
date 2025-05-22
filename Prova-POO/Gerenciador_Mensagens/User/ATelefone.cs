using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.User
{
    internal abstract class ATelefone
    {
        public string Numero {  get; private set; }
        public string DDD { get; private set; }
        public string Tipo { get; }

        public static ATelefone criarTelefone(string Telefone)
        {
            if (!numeroValido(Telefone))
            {
                throw new ArgumentException("Erro na criação do Telefone: " +
                                           $"O telefone \"{Telefone}\" " +
                                           $"não é válido.");
            }

            if (Telefone.Length > 13)
            {
                Telefone = Telefone.Substring(2);
            }
            
            string DDD_aux = Telefone.Substring(0, 2);
            string Num_Tel_aux = Telefone.Substring(2);

            if (Num_Tel_aux.Length == 9)
            {
                return new TelefoneCelular(DDD_aux, Num_Tel_aux, "celular");
            }
            else if (Num_Tel_aux.Length == 8)
            {
                return new TelefoneFixo(DDD_aux, Num_Tel_aux, "fixo");
            }
            else
            {
                throw new ArgumentException("Erro na criação do Telefone: " +
                                           $"O telefone \"{Telefone}\" " +
                                           $"não é nem do tipo fixo " +
                                           $"nem do tipo celular");
            }
        }
        protected static bool numeroValido(string Telefone)
        {
            if (!StringUtils.stringValida(Telefone))
            {
                return false;
            }

            Telefone = Telefone.Trim().Trim('-').Trim('_');

            if ((Telefone.Length > 15 || Telefone.Length < 8) ||
                !StringUtils.stringContemSomenteNumeros(Telefone))
            { 
                return false; 
            }

            return true;
        }
    }
}