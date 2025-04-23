using Gerenciador_Biblioteca.Classes;
using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Livro
    {
        public Livro(string titulo, string autor, ISBN ISBN) 
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

            Titulo = titulo;
            Autor = autor;
            this.ISBN = ISBN;
        }
        public string Titulo { get; }
        public string Autor { get; }
        public ISBN ISBN { get; }
    }
}
