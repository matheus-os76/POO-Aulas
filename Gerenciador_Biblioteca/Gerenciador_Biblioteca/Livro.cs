using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Livro
    {
        public Livro(string titulo, string autor, isbn ISBN, bool disponivel = false, int quantidade = 0 ) 
        {
            // Verifica se o livro inserido é válido
            if (string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentNullException("Titulo inválido");
            }
            else if (string.IsNullOrEmpty(autor))
            {
                throw new ArgumentNullException("Autor inválido");
            }
            else if (quantidade < 0)
            {
                throw new ArgumentOutOfRangeException("Quantidade inválida");
            }
            else if ((quantidade == 0 && disponivel) || (quantidade > 0 && disponivel == false))
            {
                throw new ArgumentException("A disponibilidade e a quantidade do livro não são compativeis");
            }

            Titulo = titulo;
            Autor = autor;
            this.ISBN = ISBN;
            Disponivel = disponivel;
            Quantidade = quantidade;

        }
        public string Titulo { get; }
        public string Autor { get; }
        public isbn ISBN { get; }
        public bool Disponivel { get; private set; }
        public int Quantidade { get; private set; }
    
        public bool alterar_quantidade(int nova_quantidade)
        {
            if (nova_quantidade < 0 || nova_quantidade == Quantidade)
                return false;

            Quantidade = nova_quantidade;

            if (Quantidade > 0)
                Disponivel = true;

            return true;
        }

        public bool adicionar_quantidade(int quantidade_adicionar)
        {
            if (quantidade_adicionar <= 0)
                return false;

            return alterar_quantidade(Quantidade + quantidade_adicionar);
        }

        public bool retirar_quantidade(int quantidade_retirar)
        {
            if (quantidade_retirar == 0)
                return false;

            if (quantidade_retirar < 0)
                quantidade_retirar *= -1;

            return alterar_quantidade(Quantidade - quantidade_retirar);
        }
    }
}
