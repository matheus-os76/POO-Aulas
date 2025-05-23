using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.User;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.User
{
    internal class Usuario
    {
        public string Nome { get; private set; }
        public ATelefone Telefone { get; private set; }
        public Email? Email { get; private set; }
        internal List<Mensagem> CaixaEntrada { get; set; }

        public Usuario(string nome, string telefone, string? email = null) 
        {
            if (!StringUtils.nomeValido(nome, 120))
            {
                throw new ArgumentException($"O nome inserido \"{nome}\" " +
                                            $"é inválido para seu usuário!");
            }

            CaixaEntrada = new List<Mensagem>();
            Nome = nome;
            Telefone = ATelefone.criarTelefone(telefone);

            if (email != null)
            {
                Email = new Email(email);
            }
        }
    }
}
