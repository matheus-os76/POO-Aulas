using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class Telefone
    {
        public string Numero_Telefone {  get; private set; }
        public string DDD { get; private set; }

        public List<Mensagem> SMS { get; private set; } 

        public string Estado { get; private set; }

        public Telefone(string telefone) 
        {
            if (!numeroValido(telefone) || telefone.Length < 11)
            {
                throw new ArgumentException("Erro: Número de telefone inválido");
            }

            telefone = telefone.Trim().Replace("-", "").Replace(" ", "");

            DDD = telefone.Substring(0, 2);
            Numero_Telefone = telefone.Substring(2);

            int DDD_numerico = Convert.ToInt16(DDD);

            #region Definir Estado pelo DDD
            if (DDD_numerico >= 11 && DDD_numerico <= 19)
            {
                Estado = "SP";
            }
            else if (DDD_numerico >= 21 && DDD_numerico <= 24)
            {
                Estado = "RJ";
            }
            else if (DDD_numerico >= 27 && DDD_numerico <= 28)
            {
                Estado = "ES";
            }
            else if (DDD_numerico >= 31 && DDD_numerico <= 38)
            {
                Estado = "MG";
            }
            else if (DDD_numerico >= 41 && DDD_numerico <= 46)
            {
                Estado = "PR";
            }
            else if (DDD_numerico >= 47 && DDD_numerico <= 49)
            {
                Estado = "SC";
            }
            else if (DDD_numerico >= 51 && DDD_numerico <= 55)
            {
                Estado = "RS";
            }
            else if (DDD_numerico == 61 || DDD_numerico == 62 ||
                     DDD_numerico == 64)
            {
                Estado = "GO";
            }
            else if (DDD_numerico == 63)
            {
                Estado = "TO";
            }
            else if (DDD_numerico >= 65 && DDD_numerico <= 66)
            {
                Estado = "MT";
            }
            else if (DDD_numerico == 67)
            {
                Estado = "MS";
            }
            else if (DDD_numerico == 68)
            {
                Estado = "AC";
            }
            else if (DDD_numerico == 69)
            {
                Estado = "RO";
            }
            else if (DDD_numerico >= 71 && DDD_numerico <= 77)
            {
                Estado = "BA";
            }
            else if (DDD_numerico == 79)
            {
                Estado = "SE";
            }
            else if (DDD_numerico == 81 || DDD_numerico == 87)
            {
                Estado = "PE";
            }
            else if (DDD_numerico == 82)
            {
                Estado = "AL";
            }
            else if (DDD_numerico == 83)
            {
                Estado = "PR";
            }
            else if (DDD_numerico == 84)
            {
                Estado = "RN";
            }
            else if (DDD_numerico == 85 || DDD_numerico == 88)
            {
                Estado = "CE";
            }
            else if (DDD_numerico == 86 || DDD_numerico == 89)
            {
                Estado = "PI";
            }
            else if (DDD_numerico == 86 || DDD_numerico == 93 || DDD_numerico == 94 )
            {
                Estado = "PA";
            }
            else if (DDD_numerico == 95)
            {
                Estado = "RR";
            }
            else if (DDD_numerico == 96)
            {
                Estado = "AP";
            }
            else if (DDD_numerico == 97)
            {
                Estado = "AM";
            }
            else if (DDD_numerico == 98 || DDD_numerico == 99)
            {
                Estado = "MA";
            }
            else
            {
                Estado = "";
            }
            #endregion
        }

        private bool stringContemLetras(string str)
        {
            foreach (char caractere in str)
            {
                if (char.IsLetter(caractere))
                    return true;
            }

            return false;
        }

        private bool numeroValido(string telefone)
        {
            if (
                string.IsNullOrEmpty(telefone) || 
                string.IsNullOrWhiteSpace(telefone) ||
                stringContemLetras(telefone)
               )
            {
                return false;
            }

            return true;
        }
    
        public void alterarDDD(string novoDDD)
        {
            if (!numeroValido(novoDDD))
            {
                throw new ArgumentException("Erro no DDD: O novo DDD é inválido");
            }

            if (novoDDD.Length > 2)
            {
                throw new ArgumentException("Erro no DDD: O novo DDD " +
                    "contém mais de 2 digitos");
            }

            DDD = novoDDD;
        }

        public void alterarTelefone(string novoTel)
        {
            if (!numeroValido(novoTel))
            {
                throw new ArgumentException("Erro no Telefone: O novo Telefone" +
                    " é inválido");
            }

            if (novoTel.Length > 10)
            {
                throw new ArgumentException("Erro no Telefone: O novo Telefone " +
                    "contém digitos a mais");
            }

            if (novoTel.Length < 9)
            {
                throw new ArgumentException("Erro no Telefone: O novo Telefone " +
                    "contém digitos a menos");
            }

            Numero_Telefone = novoTel;
        }

        public override string ToString()
        {
            string Primeira_Parte_Tel = Numero_Telefone.Substring(0, 5);
            string Segunda_Parte_Tel = Numero_Telefone.Substring(5);
            string telefone_formatado = $"{DDD} {Primeira_Parte_Tel + "-" + Segunda_Parte_Tel}";

            return telefone_formatado;
        }
    
        public static void AdicionarSMS(Mensagem mensagem, Telefone telefoneAlvo)
        {
            if (mensagem.Canal == Canal.Whatsapp || mensagem.Canal == Canal.Telegram)
            {
                telefoneAlvo.SMS.Add(mensagem);
            }
        }
    }
}
// 98190 - 0792