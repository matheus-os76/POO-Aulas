using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes
{
    public class ISBN
    {
        public ISBN(string codigo)
        {
            // Verifica se o código ISBN inserido não é vázio e tem a quantia certa de digitos
            if (codigo.Any(char.IsAsciiLetter))
            {
                throw new ArgumentOutOfRangeException($"Código inválido: " +
                    $"O código {codigo} possui letras");
            } 
            else if (string.IsNullOrEmpty(codigo) || codigo.Length < 13) 
            {
                throw new ArgumentNullException($"Código inválido: " +
                    $"Lembre-se de colocar um código ISBN-13 composto de 13 digitos");
            }

            // Limpa o parametro codigo inserido de qualquer
            // espaços em branco, barras, contra barras, traços e underlines
            codigo = codigo.Trim();
            codigo = Regex.Replace(codigo, "[_\\-\\(\\)]", "");

            // Atribui o digito verificador a uma variável e usa ele para testar se o código ISBN é válido
            digito_verificador = codigo.Last();
            if (!verificador(codigo, digito_verificador))
            {
                throw new ArgumentException($"Código Inválido: " +
                    $"Verificação acusou erro");
            }

            codigo_GTIN = codigo.Substring(0, 3);
            codigo_Pais = codigo.Substring(3, 2);
            elemento_registrante = codigo.Substring(5, 5);
            publicao = codigo.Substring(10, 2);

            // Formata o código ISBN 
            Codigo = string.Format($"{codigo_GTIN}-{codigo_Pais}-{elemento_registrante}-{publicao}-{digito_verificador}");

        }

        private string codigo_GTIN { get; }
        private string codigo_Pais { get; }
        private string elemento_registrante { get; }
        private string publicao { get; }
        private char digito_verificador { get; }
        public string Codigo { get; }
        private bool verificador(string codigo, char digito_verificador)
        {
            // Essa função verifica se o código ISBN é válido através de um algoritmo de modulo 10
            var digito = Convert.ToByte(char.GetNumericValue(digito_verificador));
            int soma = 0;
            int resto_10;

            for (int i = 0; i < codigo.Length-1; i++)
            {
                if (i % 2 == 0)
                    soma += Convert.ToInt32(char.GetNumericValue(codigo[i]));
                else
                    soma += Convert.ToInt32(char.GetNumericValue(codigo[i]) * 3);
            }

            do {
                resto_10 = soma % 10;
                soma /= 10;
            } while (resto_10 > 9);

            if (digito != 0)
            {
                if (10 - resto_10 == digito)
                    return true;
                
                return false;
            }
            else if (resto_10 == 0 && digito == 0)
            {
                return true;
            }

            return false;

        }
    }
}
