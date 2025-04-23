using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Emprestimo
    {
        public Emprestimo(Usuario usuario, DateTime emprestimo, DateTime? devolucao_efet = null) 
        {
            if (devolucao_efet != null)
            {
                if (DateTime.Compare(DataEmprestimo, Convert.ToDateTime(devolucao_efet)) > 0)
                {
                    throw new ArgumentException($"A data de devolução efetiva é anterior a data de emprestimo");
                }
            }

            this.Usuario = usuario;
            this.DataEmprestimo = emprestimo;
            this.Devolucao_Efetiva = devolucao_efet;
        }

        public Usuario Usuario { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime? Devolucao_Efetiva { get; internal set; }
    }
}
