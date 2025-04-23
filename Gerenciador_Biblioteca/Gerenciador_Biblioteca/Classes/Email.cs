using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes
{
    public class Email
    {
        public Email(string endereco) 
        {
            // Gera um provedor a partir do caractere '@'
            int pos_arroba = endereco.IndexOf('@');
            string provedor = endereco.Substring(pos_arroba);

            // Verifica se o endereço e o provedor são válidos
            if (endereco.Length <= 10 || string.IsNullOrEmpty(endereco))
            {
                throw new ArgumentNullException($"O endereço inserido não é válido: " +
                    $"\"{endereco}\" é um endereço vázio");
            }
            else if (!endereco.Contains('@'))
            {
                throw new ArgumentException($"O endereço inserido não é válido: " +
                    $"\"{endereco}\" não possui \'@\'");
            }
            else if (!possui_provedor(endereco))
            {
                throw new ArgumentException($"O endereço inserido não é válido: " +
                    $"\"{endereco}\" não possui um provedor");
            }
            else if (provedor.Length < 5 || provedor == string.Empty) 
            {
                throw new ArgumentException($"O provedor do endereço inserido não é válido: " +
                    $"\"{provedor}\" não é um provedor válido");
            }

                Endereco = endereco;
                Provedor = provedor;

        }
        public string Endereco { get; private set; }
        public string Provedor { get; private set; }
        private bool possui_provedor( string endereco ) 
        {
            int pos_arroba = endereco.IndexOf('@');
            int pos_ponto = endereco.IndexOf('.');

            // Verifica se há ao menos um caractere entre o '@' e o '.'
            if (pos_ponto - pos_arroba <= 1)
                return false;
            else if (pos_arroba <= 0 || pos_ponto <= 0)
                return false;

            return true;
        }
    }
}
