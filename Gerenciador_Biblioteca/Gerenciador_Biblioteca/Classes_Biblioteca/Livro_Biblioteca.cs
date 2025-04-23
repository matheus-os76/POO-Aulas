using Gerenciador_Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes_Biblioteca
{
    public class Livro_Biblioteca : ILivro
    {
        public Livro_Biblioteca(Livro livro, int quantidade = 0, bool disponivel = false) 
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException($"Não é possível ter um livro com " +
                    $"quantidade de {quantidade}");

            if (disponivel && quantidade == 0)
                throw new ArgumentException("Não é possível adicionar um livro que esteja" +
                    "disponível mas que não tenha o mesmo em nenhuma quantidade");

            if (quantidade > 0 && !disponivel)
                Disponivel = true;
            else
                Disponivel = disponivel;

            Livro = livro;
            Quantidade = quantidade;
        }
        public Livro Livro { get; set; }
        public int Quantidade { get; private set; }
        public bool Disponivel { get; private set; }

        internal bool AdicionarQuantidade(int quantidade_adicionar)
        {
            if (quantidade_adicionar < 0)
                throw new ArgumentOutOfRangeException($"Não é possível adicionar " +
                    $"{quantidade_adicionar} deste livro");

            if (quantidade_adicionar > 0)
            {
                if (Quantidade == 0)
                    Disponivel = true;

                Quantidade += quantidade_adicionar;
                return true;
            }

            return false;
        }

        internal bool RemoverQuantidade(int quantidade_remover)
        {
            if (quantidade_remover < 0)
                quantidade_remover *= -1;

            if (quantidade_remover != 0)
            {
                Quantidade -= quantidade_remover;

                if (Quantidade < 0)
                    Quantidade = 0;

                if (Quantidade == 0)
                    Disponivel = false; 

                return true;
            }

            return false;
        }
    }
}
