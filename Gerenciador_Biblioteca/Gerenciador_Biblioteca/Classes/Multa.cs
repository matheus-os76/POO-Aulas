using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Biblioteca.Classes
{
    public class Multa
    {
        public Multa(Usuario usuario) 
        {
            Usuario = usuario;   
        }
        public Usuario Usuario { get; }
        public float Valor { get; internal set; }
    }
}
