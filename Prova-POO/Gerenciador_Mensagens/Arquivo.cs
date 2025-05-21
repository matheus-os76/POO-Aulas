using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class Arquivo
    {
        public string Nome { get; private set; }

        public Formato Formato { get; private set; }

        public DateTime? Duracao { get; private set; }

        public Arquivo(string nome, Formato formato) 
        {
            if (!stringValida(nome))
            {
                throw new ArgumentNullException("Nome do arquivo inválido");
            }

            this.Nome = nome;  
            this.Formato = formato;
            Duracao = null;
        }

        public Arquivo(string nome, Formato formato, DateTime duracao)
        {
            if (!stringValida(nome))
            {
                throw new ArgumentNullException("Nome do arquivo inválido");
            }

            if (formato.Tipo != "video")
            {
                throw new ArgumentNullException("Esse formato não suporta vídeos");
            }

            this.Nome = nome;
            this.Formato = formato;
            this.Duracao = duracao;
        }

        private bool stringValida(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
                return false;
            else if (string.IsNullOrWhiteSpace(mensagem))
                return false;

            return true;
        }
    }
}
