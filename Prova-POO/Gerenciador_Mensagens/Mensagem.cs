using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class Mensagem
    {

        //public Usuario Destinatario { get; }
        //public Canal Canal { get; }
        //public DateTime Data_Envio { get; }
        //public Arquivo Arquivo { get; }
        //public string _Mensagem { get; private set; }

        //public Mensagem(string mensagem, Usuario destinatario, Canal canal, Arquivo arquivo) 
        //{
        //    if (mensagemValida(mensagem))
        //    {
        //        _Mensagem = mensagem;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Mensagem inválida");
        //    }

        //    this.Destinatario = destinatario;
        //    this.Arquivo = arquivo;
        //    this.Canal = canal;
        //}

        //public Mensagem(string mensagem, Usuario destinatario, Canal canal, DateTime data_envio)
        //{
        //    if (mensagemValida(mensagem)) 
        //    {
        //        _Mensagem = mensagem;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Mensagem inválida");
        //    }

        //    this.Destinatario = destinatario;
        //    this.Data_Envio = data_envio;
        //    this.Canal = canal;
        //}


        

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
