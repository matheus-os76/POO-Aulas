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
        //public Usuario Ultimo { get; private set; }           Ideia
        //public DateTime DataAdicao { get; private set; }      Ideia

        public GerenciadorUsuarios(string Nome)
        {
            if (!StringUtils.stringValida(Nome))
            {
                throw new ArgumentException();
            }

            this.Nome = Nome;
            ListaUsuarios = new List<Usuario>();
        }

        public void adicionarUsuario(string telefone, string? nome = null, string? email = null)
        {
            if (telefone == null)
            {
                throw new ArgumentNullException("Erro ao criar Usuário: " +
                                                "Telefone não pode ser nulo.");
            }

            Usuario usuarioAdicionar;

            if (nome == null)
            {
                usuarioAdicionar = new Usuario("Desconhecido", telefone);
            }
            else
            {
                usuarioAdicionar = new Usuario(nome, telefone, email);
            }

            if (usuarioExiste(usuarioAdicionar))
            {
                if (nome == null)
                {
                    throw new Exception($"O usuário com o telefone " +
                                        $"\"{telefone}\" já existe dentro do " +
                                        $"sistema \"{Nome}\"");
                }

                throw new Exception($"O(A) usuário(a) \"{nome}\" " +
                                    $"já existe dentro do Gerenciador \"{Nome}\"");
            }

            ListaUsuarios.Add(usuarioAdicionar);

            if (nome == null)
            {
                Console.WriteLine($"[ChatBot]: Um usuário desconhecido " +
                                  $"({usuarioAdicionar.Telefone.ToString()}) " +
                                  $"foi adicionado ao sistema.");
            }
            else
            {
                Console.WriteLine($"[ChatBot]: Usuário \"{usuarioAdicionar.Nome}\" " +
                                  $"foi adicionado ao sistema.");
            }
        }
        public bool enviarMensagem(Mensagem mensagem, ATelefone telefoneBuscar, Email? emailBuscar)
        {
            Usuario? user_achado = acharUsuario(telefoneBuscar, emailBuscar);

            if (user_achado == null)
            {
                Console.WriteLine($"[ChatBot]: Usuário não achado dentro do " +
                                  $"sistema \"{Nome}\".");
                return false;
            }

            int qntd_mensagens_antiga = user_achado.CaixaEntrada.Count();
            user_achado.CaixaEntrada.Add(mensagem);

            if (qntd_mensagens_antiga != user_achado.CaixaEntrada.Count())
            {
                Console.WriteLine($"[ChatBot]: A mensagem foi entregue para " +
                                  $"\"{user_achado.Nome}\".");
                return true;
            }

            Console.WriteLine($"[ChatBot]: Falha ao entregar uma mensagem para " +
                              $"\"{user_achado.Nome}\"."); 
            return false;
        }
        public List<string> listarUsuarios()
        {
            List<string> lista_nomes = new List<string>(quantidadeUsuarios());

            foreach (Usuario user in ListaUsuarios)
            {
                lista_nomes.Add(user.Nome);
            }

            return lista_nomes;
        }
        public int quantidadeUsuarios()
        {
            return ListaUsuarios.Count();
        }
        private bool usuarioExiste(Usuario usuarioProcurado)
        {
            if (ListaUsuarios.Exists(u => u.Telefone.ToString() ==
                                          usuarioProcurado.Telefone.ToString()))
            {
                return true;
            }

            if (usuarioProcurado.Email != null)
            {
                if (ListaUsuarios.Exists(u => u.Email.ToString() ==
                                          usuarioProcurado.Email.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
        private Usuario? acharUsuario(ATelefone telefoneBuscar, Email? emailBuscar)
        {
            if (telefoneBuscar == null)
            {
                throw new ArgumentNullException();
            }

            var user_achar = ListaUsuarios.Find(
                    u => u.Telefone == telefoneBuscar
                );

            if (user_achar == null && emailBuscar != null)
            {
                user_achar = ListaUsuarios.Find(
                    u => u.Email == emailBuscar
                );
            }

            return user_achar;
        }
        public override string ToString()
        {
            return Nome;
        }
        //public Usuario ultimoUsuarioAdicionado()              Ideia
    }
}
