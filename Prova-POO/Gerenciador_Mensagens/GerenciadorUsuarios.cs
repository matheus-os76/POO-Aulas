using Gerenciador_Mensagens.User;
using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens
{
    internal class GerenciadorUsuarios
    {
        private List<Usuario> ListaUsuarios { get; set; }
        public string Nome { get; }

        public GerenciadorUsuarios(string Nome)
        {
            if (!StringUtils.stringValida(Nome))
            {
                throw new ArgumentException();
            }

            this.Nome = Nome;
            ListaUsuarios = new List<Usuario>();
        }

        public void adicionarUsuario(Usuario usuarioAdicionar)
        {
            ListaUsuarios.Add(usuarioAdicionar);
        }
        public override string ToString()
        {
            return Nome;
        }
        public List<String> listarUsuarios()
        {
            List<String> lista_usuarios = new List<String>();

            for (int i = 0; i < ListaUsuarios.Count; i++)
            {
                lista_usuarios.Add(ListaUsuarios[i].Nome);
            }

            return lista_usuarios;
        }
        public int quantidadeUsuarios()
        {
            return ListaUsuarios.Count();
        }
    
        public Usuario? acharUsuario(string nomeAchar, 
                                     string? telefoneAchar = null,  
                                     string? emailAchar = null)
        {

            return null;
        }

        public bool enviarMensagem(Usuario destino, Mensagem mensagem)
        {


            return false;
        }
    }
}
