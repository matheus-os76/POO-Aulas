using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.User
{
    internal class Email
    {
        // Corpo: É tudo que vem antes do @ 
        // Dominio: Provedor do servidor, fica entre o @ até o próximo .
        // TLD: Top-Level Domain é o dominio superior, como (.com) ou (.org)

        public string Corpo { get; set; }
        public Dominio Dominio_Email { get; set; }
        public string TLD { get; set; }

        public Email(string email) 
        {
            if (!StringUtils.stringValida(email))
            {
                throw new ArgumentException("Erro na criação do E-mail: " +
                    $"O E-mail inserido \"{email}\" não é uma string válida.");
            }

            email = email.Trim();

            if (!char.IsLetter(email.First()) || !char.IsLetter(email.Last())) 
            {
                throw new ArgumentException("Erro na criação do E-mail: " +
                    $"O E-mail inserido \"{email}\" não possui letras nos extremos.");
            }

            if (!email.Contains('.') || !email.Contains('@'))
            {
                throw new ArgumentException("Erro na criação do E-mail: " +
                    $"O E-mail inserido \"{email}\" não contém \'.\' nem \'@\'");
            }

            // Se a função achar um dominio igual ao que está no e-mail ele retorna
            // o objeto desse dominio, senão ele crasha.

            Dominio? dominio = acharDominio(email);

            if (dominio == null)
            {
                throw new ArgumentNullException("Erro na criação do E-mail: " +
                    $"O E-mail inserido \"{email}\" não contém um domínio válido.");
            }

            Corpo = acharCorpo(email);
            Dominio_Email = dominio;
            TLD = acharTopLevelDomain(email);
        }

        private string acharCorpo(string email)
        {
            return email.Substring(0, email.IndexOf('@'));
        }
        private Dominio? acharDominio(string email)
        {
            string nome_dominio = email.Remove(0, email.IndexOf('@') + 1);

            nome_dominio = nome_dominio.Substring(0, nome_dominio.IndexOf('.')).ToLower();

            return Dominio.buscarDominio(nome_dominio);
        }
        private string acharTopLevelDomain(string email)
        {
            email = email.Remove(0, email.IndexOf('@') + 1);
            email = email.Substring(email.IndexOf('.') + 1);

            return email;
        }
        public void alterarEmail(string novoEmail)
        {
            Email novo_email = new Email(novoEmail);

            Corpo = novo_email.Corpo;
            Dominio_Email = novo_email.Dominio_Email;
            TLD = novo_email.TLD;
        }
        public override string? ToString()
        {
            return string.Concat(Corpo, '@', Dominio_Email.Nome, '.', TLD);
        }
    }
}
