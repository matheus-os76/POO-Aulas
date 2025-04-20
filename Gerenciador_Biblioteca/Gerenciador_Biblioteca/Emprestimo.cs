using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    // Classe de Empréstimo
    public class Emprestimo
    {
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoEfetiva { get; set; }
    }
}
