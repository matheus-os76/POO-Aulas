using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Emprestimo
    {
        public Emprestimo(Livro livro, Usuario usuario, DateTime emprestimo, DateTime devolucao_prev) 
        {
            // Verifica se as datas de emprestimo faz sentido com as datas de devolução prevista e efetiva
            if (DateTime.Compare(emprestimo, devolucao_prev) > 0)
            {
                throw new ArgumentException($"A data de emprestimo é posterior a data de devolução prevista");
            }

            this.Livro = livro;
            this.Usuario = usuario;
            this.DataEmprestimo = emprestimo;
            this.DataDevolucaoPrevista = devolucao_prev;
        }

        public Livro Livro { get; }
        public Usuario Usuario { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime DataDevolucaoPrevista { get; }
        public DateTime? DataDevolucaoEfetiva { get; private set; }
        public bool Devolvido { get; private set;  }

        public void Devolver_Livro(DateTime devolucao_efet)
        {
            if (DateTime.Compare(DataEmprestimo, (DateTime)devolucao_efet) > 0)
            {
                throw new ArgumentException($"A data de devolução efetiva é anterior a data de emprestimo");
            }

            DataDevolucaoEfetiva = devolucao_efet;
            Devolvido = true;
            Livro.adicionar_quantidade(1);
        }
    }
}
