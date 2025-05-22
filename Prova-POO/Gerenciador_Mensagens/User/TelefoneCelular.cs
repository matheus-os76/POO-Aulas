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
        public override void alterarDDD(string novoDDD)
        {
            if (!StringUtils.stringValida(novoDDD))
            {
                throw new ArgumentException("Erro em alterar DDD: " +
                                           $"O novo DDD \"{novoDDD}\" não é uma" +
                                           $" string válida.");
            }

            if (StringUtils.stringContemSomenteLetras(novoDDD))
            {
                throw new ArgumentException("Erro em alterar DDD: " +
                                           $"O novo DDD \"{novoDDD}\" não contem" +
                                           $" somente digitos.");
            }

            novoDDD = novoDDD.Trim();

            if (novoDDD.Length != 2)
            {
                throw new ArgumentException("Erro em alterar DDD: " +
                                           $"O novo DDD \"{novoDDD}\" não contem" +
                                           $" somente 2 digitos.");
            }

            if (novoDDD == this.DDD)
            {
                throw new ArgumentException("Erro em alterar DDD: " +
                                           $"O novo DDD \"{novoDDD}\" é igual ao" +
                                           $" antigo DDD \"{DDD}\"");
            }

            int DDD_numerico = Convert.ToInt16(novoDDD);

            if (DDD_numerico > 99 || DDD_numerico < 11)
            {
                throw new ArgumentException("Erro em alterar DDD: " +
                                           $"O novo DDD \"{novoDDD}\" está fora da" +
                                           $" faixa de DDD disponíveis.");
            }

            this.DDD = novoDDD;
        }
        public override void alterarNumero(string novoNumero)
        {
            if (!ATelefone.numeroValido(string.Concat("11",novoNumero)))
            {
                throw new ArgumentException();
            }

            Numero = novoNumero;
        }
    }
}
