using Gerenciador_Biblioteca.Classes;
using Gerenciador_Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes_Biblioteca
{
    public class Multa_Biblioteca : IMulta
    {
        public Multa_Biblioteca(Multa multa, Emprestimo_Biblioteca emprestimo) 
        {
            Multa = multa;
            TimeSpan atraso = DateTime.Today - emprestimo.Devolucao_Prevista;
            Multa.Valor = atraso.Days * 1F;
        }

        public Multa Multa { get; set; }
        public Emprestimo_Biblioteca Emprestimo { get; set; }
    }
}
