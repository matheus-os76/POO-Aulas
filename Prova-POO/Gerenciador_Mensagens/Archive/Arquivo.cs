using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Archive
{
    internal abstract class Arquivo
    {
        public string Nome { get; protected set; }
        public Formato Formato { get; protected set; }
        public string Tipo { get; protected set; }

        public Arquivo(string nome, Formato formato)
        {
            if (!stringValida(nome) || nome.Contains(" "))
            {
                throw new ArgumentException($"Erro na criação do Arquivo: " +
                                            $"O nome \"{nome}\" é uma string " +
                                            $"inválida para um arquivo.");
            }

            if (formato == null)
            {
                throw new ArgumentNullException($"Erro na criação do Arquivo: " +
                                                $"Formato nulo.");
            }

            Nome = nome;
            Formato = formato;
            Tipo = formato.Tipo;
        }

        private bool stringValida(string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
                return false;
            else if (string.IsNullOrWhiteSpace(mensagem))
                return false;

            return true;
        }
        public override string ToString()
        {
            return string.Concat(Nome,'.',Formato.Nome);
        }
    }
}
