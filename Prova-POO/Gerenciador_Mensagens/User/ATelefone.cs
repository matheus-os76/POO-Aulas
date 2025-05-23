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
        public string Numero { get; private set; }
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

            string ddd = Telefone.Substring(0, 2);
            string numero = Telefone.Substring(2);

            if (numero.Length == 9)
            {
                return new TelefoneCelular(ddd, numero, "celular");
            }
            else if (numero.Length == 8)
            {
                return new TelefoneFixo(ddd, numero, "fixo");
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

            Telefone.Trim(new Char[] { ' ', '-', '.', '_' });

            if (Telefone.Length > 15 || Telefone.Length < 8)
            {
                return false; 
            }

            if (!StringUtils.stringContemSomenteNumeros(Telefone))
            {
                return false;
            }

            return true;
        }
        public abstract void alterarDDD(string novoDDD);
        public abstract void alterarNumero(string novoNum);
    }
}