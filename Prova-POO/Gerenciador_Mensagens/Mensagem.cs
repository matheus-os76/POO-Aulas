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
        public Usuario Destinatario { get; }
        public Canal Canal { get; }
        public AMensagem Conteudo { get; private set; }

        public Mensagem(MArquivo conteudo, Canal canal, Usuario destinatario)
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

            Destinatario = destinatario;
            Canal = canal;
            Conteudo = conteudo;
        }

        public Mensagem(MTexto conteudo, Canal canal, string Telefone)
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

            Destinatario = new Usuario("Desconhecido", Telefone);
            Canal = canal;
            Conteudo = conteudo;
        }
        
        //public void alterarMensagem(string novaMensagem)
        //{
        //    if (mensagemValida(novaMensagem))
        //    {
        //        this._Mensagem = novaMensagem;
        //    }
        //    else if (this._Mensagem == novaMensagem)
        //    {
        //        throw new ArgumentException("Nova mensagem é igual a antiga");
        //    }
        //    else
        //        throw new ArgumentException("Nova mensagem é inválida");
        //}

        //public static void EnviarUsuario(Mensagem mensagem)
        //{
        //    if (mensagem.Canal != Canal.Whatsapp)
        //    {
        //        Usuario.AdicionarMensagem(mensagem, mensagem.Destinatario);
        //    }
        //}

        //public static void EnviarTelefone(Mensagem mensagem)
        //{
        //    if (mensagem.Canal == Canal.Whatsapp || mensagem.Canal == Canal.Telegram)
        //        Telefone.AdicionarSMS(mensagem, mensagem.Destinatario.Telefone);
        //}
    }
}
