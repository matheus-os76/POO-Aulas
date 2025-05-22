using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.User
{
    internal class Usuario
    {
        public string Nome { get; private set; }
        public ATelefone Telefone { get; private set; }
        public Email? Email { get; private set; }
        public List<Mensagem> CaixaEntrada { get; set; }

        public Usuario(string Nome, string Telefone, string? Email = null) 
        {
            if (!StringUtils.nomeValido(Nome, 120))
            {
                throw new ArgumentException("O nome inserido é inválido " +
                    "para seu usuário!");
            }

            CaixaEntrada = new List<Mensagem>();
            this.Nome = Nome;
            this.Telefone = ATelefone.criarTelefone(Telefone);

            if (Email != null)
            {
                this.Email = new Email(Email);
            }
        }
    }
}
