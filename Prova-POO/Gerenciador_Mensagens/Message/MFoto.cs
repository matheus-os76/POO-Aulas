using Gerenciador_Mensagens.Archive;
using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Message
{
    internal class MFoto : AMensagem
    {
        public Arquivo Arquivo { get; }
        public override string Mensagem { get; }

        public MFoto(string mensagem, Arquivo arquivo)
        {
            if (!StringUtils.stringValida(mensagem))
            {
                throw new ArgumentException("Erro na criação da Mensagem: " +
                                           $"A mensagem \"{mensagem}\" não é uma" +
                                           $"string válida.");
            }

            this.Mensagem = mensagem;
            this.Arquivo = arquivo;
            Tipo = "foto";
        }

        public override List<object> listaConteudo()
        {
            List<object> lista_conteudo = new List<object>(1);
            lista_conteudo.Add(Arquivo);

            return lista_conteudo;
        }
    }
}
