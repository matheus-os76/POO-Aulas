using Gerenciador_Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes_Biblioteca
{
    public class Emprestimo_Biblioteca : IEmprestimo
    {
        public Emprestimo_Biblioteca(Emprestimo emprestimo, 
                                     DateTime devolucao_prev, 
                                     Livro_Biblioteca livro_Emprestado)
        {
            if (DateTime.Compare(emprestimo.DataEmprestimo, devolucao_prev) > 0)
            {
                throw new ArgumentException($"A data de emprestimo é posterior " +
                    $"a data de devolução prevista");
            }

            Emprestimo = emprestimo;
            Devolucao_Prevista = devolucao_prev;
            Livro_Emprestado = livro_Emprestado;
        }
        public Emprestimo Emprestimo { get; set; }
        public DateTime Devolucao_Prevista { get; }
        public Livro_Biblioteca Livro_Emprestado { get; }

    }
}
