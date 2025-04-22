using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca
{
    public class Telefone
    {
        public Telefone(string telefone) 
        {
            // Verifica se o Telefone inserido é válido
            if (string.IsNullOrEmpty(telefone) || telefone.Length < 10)
            {
                throw new ArgumentException($"O número de telefone inserido é inválido: " +
                    $"{telefone} não possui a quantidade mínima de digitos para um telefone");
            }
            else if (telefone.Any(char.IsAsciiLetter))
            {
                throw new ArgumentException($"O número de telefone inserido é inválido: " +
                    $"{telefone} não pode possuir letras");
            }

            // Limpa o parametro telefone inserido de qualquer
            // espaços em branco, barras, contra barras, traços e underlines
            telefone = telefone.Trim();
            telefone = Regex.Replace(telefone, "[_\\-\\(\\)]", "");

            DDD = telefone.Substring(0,2);
            Num_Telefone = telefone.Substring(2);

            if (Num_Telefone.Length == 8) Tipo = 'F';
            else Tipo = 'M';
        }

        public string DDD { get; }
        public string Num_Telefone { get; }
        private char Tipo;

    }
}
