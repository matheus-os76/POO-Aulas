using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Archive
{
    internal class Documento : Arquivo
    {
        public float Tamanho { get; } 
        public Documento(string nome, Formato formato, float tamanho) : base(nome, formato)
        {
            if (tamanho <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Tamanho = tamanho;
        }
    }
}
