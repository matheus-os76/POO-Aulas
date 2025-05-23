using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Message;
using Gerenciador_Mensagens.User;

namespace Gerenciador_Mensagens
{
    internal class Mensagem
    {
        public Canal Canal { get; }
        public AMensagem Conteudo { get; private set; }

        public Mensagem(MArquivo conteudo, Canal canal)
        {
            if (canal.Tipo == "arquivo" && conteudo.TipoConteudo == "texto")
            {
                throw new Exception($"Erro na criação da Mensagem: O canal " +
                                    $"\"{canal.Nome}\" não suporta " +
                                    $"envio de textos.");
            }

            if (canal.Tipo == "texto" && conteudo.TipoConteudo == "arquivo")
            {
                throw new Exception($"Erro na criação da Mensagem: O canal " +
                                    $"\"{canal.Nome}\" não suporta " +
                                    $"envio de arquivos.");
            }

            Canal = canal;
            Conteudo = conteudo;
        }

        public Mensagem(MTexto conteudo, Canal canal)
        {
            if (canal.Tipo == "arquivo" && conteudo.TipoConteudo == "texto")
            {
                throw new Exception($"Erro na criação da Mensagem: O canal " +
                                    $"\"{canal.Nome}\" não suporta " +
                                    $"envio de textos.");
            }

            if (canal.Tipo == "texto" && conteudo.TipoConteudo == "arquivo")
            {
                throw new Exception($"Erro na criação da Mensagem: O canal " +
                                    $"\"{canal.Nome}\" não suporta " +
                                    $"envio de arquivos.");
            }

            Canal = canal;
            Conteudo = conteudo;
        }
    }
}
