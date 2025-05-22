using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Gerenciador_Mensagens.Utils;

namespace Gerenciador_Mensagens.User
{
    internal class Dominio
    {
        public string Nome { get; }

        private Dominio(string nome) 
        {
            if (!StringUtils.nomeValido(nome, 15, 2))
            {
                throw new ArgumentException("Erro na criação do Dominio: " +
                                           $"O dominio \"{nome}\" não é uma" +
                                           $"palavra válida.");
            }

            Nome = nome.Trim().ToLower();
        }

        public static Dominio GMAIL => new Dominio("gmail");
        public static Dominio YAHOO => new Dominio("yahoo");
        public static Dominio HOTMAIL => new Dominio("hotmail");
        public static Dominio AOL => new Dominio("aol");
        public static Dominio LIVE => new Dominio("live");
        public static Dominio TERRA => new Dominio("terra");

        public static Dominio buscarDominio(string nome)
        {
            if (StringUtils.nomeValido(nome, 15, 2))
            {
                if (nome == GMAIL.Nome)
                    return GMAIL;
                else if (nome == YAHOO.Nome)
                    return YAHOO;
                else if (nome == HOTMAIL.Nome)
                    return HOTMAIL;
                else if (nome == AOL.Nome)
                    return AOL;
                else if (nome == LIVE.Nome)
                    return LIVE;
                else if (nome == TERRA.Nome)    
                    return TERRA;
            }

            return null;
        }
    }
}
