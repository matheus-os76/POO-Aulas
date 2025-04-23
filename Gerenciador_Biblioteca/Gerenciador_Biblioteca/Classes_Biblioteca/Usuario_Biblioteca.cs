using Gerenciador_Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes_Biblioteca
{
    public class Usuario_Biblioteca : IUsuario
    {
        public Usuario_Biblioteca(Usuario usuario) 
        {
            Usuario = usuario;
            Lista_Multas = new List<Multa_Biblioteca>();
            Caixa_Entrada = new List<Mensagem_Biblioteca>();

            if (Lista_Multas.Count > 0)
            {
                foreach (var multa in Lista_Multas)
                {
                    Saldo -= multa.Multa.Valor;
                }
            }
        }
        public Usuario Usuario { get; set; }
        public List<Mensagem_Biblioteca> Caixa_Entrada { get; }
        public List<Multa_Biblioteca> Lista_Multas { get; }
        public float Saldo { get; internal set; }
    }
}
