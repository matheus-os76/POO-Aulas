using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class Usuario
    {
        public string Nome { get; private set; }

        public Telefone Telefone { get; private set; }

        public List<Mensagem> Caixa_Entrada { get; private set; }

        public Usuario(string Nome, string Telefone) 
        {
            if (!nomeValido(Nome))
            {
                throw new ArgumentException("O nome inserido é inválido " +
                    "para seu usuário!");
            }

            this.Nome = Nome;
            this.Telefone = new Telefone(Telefone);
            Caixa_Entrada = new List<Mensagem>();
        }

        private bool stringContemSomenteLetras(string str)
        {
            foreach (char caractere in str)
            {
                if (char.IsLetter(caractere) || char.IsWhiteSpace(caractere))
                    continue;
                else 
                    return false;
            }

            return true;
        }

        private bool nomeValido(string Nome)
        {
            if (
                string.IsNullOrEmpty(Nome) ||
                string.IsNullOrWhiteSpace(Nome) ||
                Nome.Length < 3 ||
                !stringContemSomenteLetras(Nome)
               )
            {
                return false;
            }

            return true;
        }

        public void alterarNome(string novoNome)
        {
            if (!nomeValido(novoNome))
            {
                throw new ArgumentException("Erro: O novo nome é inválido!");
            }

            if (novoNome == Nome)
            {
                throw new ArgumentException("Erro: O novo nome é igual ao antigo!");
            }

            this.Nome = novoNome;
        }

        public override string ToString()
        {
            return Nome;
        }
    
        public static void AdicionarMensagem(Mensagem mensagem, Usuario destino)
        {
            if (!(mensagem.Canal == Canal.Whatsapp))
                destino.Caixa_Entrada.Add(mensagem);
        }
    }
}
