using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.Message
{
    internal class MTexto : AMensagem
    {
        public DateTime DataEnvio { get; }
        public override string Mensagem { get; }

        public MTexto(string mensagem) 
        {
            if (!StringUtils.stringValida(mensagem))
            {
                throw new ArgumentException("Erro na criação da Mensagem: " +
                                           $"A mensagem \"{mensagem}\" não é uma" +
                                           $"string válida.");
            }
            
            this.Mensagem = mensagem;
            this.DataEnvio = DateTime.Now;
            Tipo = "texto";
        }

        public override List<object> listaConteudo() 
        {
            List<object> lista_conteudo = new List<object>(1);
            lista_conteudo.Add(DataEnvio);

            return lista_conteudo;
        }
    }
}
