using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Message;

namespace Gerenciador_Mensagens
{
    internal class Mensagem
    {
        public Usuario Destinatario { get; }
        public Canal Canal { get; }
        public AMensagem Conteudo { get; private set; }

        public Mensagem(Usuario destinatario, Canal canal, AMensagem conteudo)
        {
            Destinatario = destinatario;
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
