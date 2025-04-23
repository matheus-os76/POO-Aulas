using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Gerenciador_Biblioteca.Classes_Biblioteca;
using Gerenciador_Biblioteca.Classes;

namespace Gerenciador_Biblioteca
{
    public class GerenciadorBiblioteca 
    {
        private List<Livro_Biblioteca> Livros = new List<Livro_Biblioteca> { }; 
        private List<Usuario_Biblioteca> Usuarios = new List<Usuario_Biblioteca> { }; 
        private List<Emprestimo_Biblioteca> Emprestimos = new List<Emprestimo_Biblioteca> { };
        
        private Livro_Biblioteca? BuscarLivro(ISBN isbn_buscar)
        {
            var resultado_busca = Livros.Find(l => l.Livro.ISBN == isbn_buscar);

            if (resultado_busca == null)
                return null;

            return resultado_busca;
        }

        private Usuario_Biblioteca? BuscarUsuario(int? id_buscar = null, Telefone ? telefone_buscar = null)
        {
            if ((id_buscar == null && telefone_buscar == null) || id_buscar < 0)
                throw new ArgumentNullException("Coloque algum parâmetro para a busca");

            var resultado_busca = Usuarios.Find(u =>
                                                u.Usuario.Telefone == telefone_buscar ||
                                                u.Usuario.ID == id_buscar);

            if (resultado_busca == null)
                return null;

            return resultado_busca;
        }

        public bool AdicionarLivro(Livro livro_adicionar, int quantidade = 0)
        {
            var livro_existente = BuscarLivro(livro_adicionar.ISBN);

            if (livro_existente != null)
                return false;

            Livro_Biblioteca Novo_Livro = new(livro_adicionar, quantidade);
            Livros.Add(Novo_Livro);

            Console.WriteLine($"O livro \"{Novo_Livro.Livro.Titulo}\" foi adicionado a biblioteca.");
            return true;
        }

        public bool AdicionarUsuario(Usuario usuario_adicionar)
        {
            var usuario_existente = BuscarUsuario(usuario_adicionar.ID, usuario_adicionar.Telefone);

            if (usuario_existente != null)
                return false;

            Usuario_Biblioteca Novo_Usuario = new(usuario_adicionar);
            Usuarios.Add(Novo_Usuario);

            Console.WriteLine($"O usuário \"{usuario_adicionar.Nome}\" foi adicionado a biblioteca.");
            return true;
        }

        public bool RealizarEmprestimo(int usuario_id, ISBN isbn, int diasEmprestimo)
        {
            var livro_emprestimo = BuscarLivro(isbn);
            var usuario_emprestimo = BuscarUsuario(usuario_id);

            if (livro_emprestimo != null && usuario_emprestimo != null)
            { 
                if (livro_emprestimo.Disponivel)
                {
                    livro_emprestimo.RemoverQuantidade(1);

                    Emprestimo_Biblioteca emprestimo = new(

                        new Emprestimo(usuario_emprestimo.Usuario, DateTime.Today), 
                        DateTime.Today.AddDays(diasEmprestimo),
                        livro_emprestimo

                    );

                    EnviarMensagem(usuario_id, string.Format($"Você realizou um empréstimo " +
                        $"do livro \"{livro_emprestimo.Livro.Titulo}\" com devolução" +
                        $"prevista para " +
                        $"{emprestimo.Devolucao_Prevista.Day}/" +
                        $"{emprestimo.Devolucao_Prevista.Month}/" +
                        $"{emprestimo.Devolucao_Prevista.Year}"));

                    EnviarMensagem(usuario_id, string.Format($"Você realizou um empréstimo " +
                        $"do livro \"{livro_emprestimo.Livro.Titulo}\" com devolução" +
                        $"prevista para " +
                        $"{emprestimo.Devolucao_Prevista.Day}/" +
                        $"{emprestimo.Devolucao_Prevista.Month}/" +
                        $"{emprestimo.Devolucao_Prevista.Year}"), 
                        "Emprestimo");

                    return true;
                }
                Console.WriteLine($"O livro \"{livro_emprestimo.Livro.Titulo}\" está indísponível no momento");
                return false;
            }

            return false;
        }

        public bool RealizarDevolucao(int usuario_id, ISBN isbn)
        {
            var emprestimo = Emprestimos.Find(e =>
                                              e.Livro_Emprestado.Livro.ISBN == isbn &&
                                              e.Emprestimo.Usuario.ID == usuario_id &&
                                              e.Emprestimo.Devolucao_Efetiva == null);

            if (emprestimo != null)
            {
                var usuario_emprestimo = Usuarios.Find(u => u.Usuario.ID == usuario_id);

                emprestimo.Emprestimo.Devolucao_Efetiva = DateTime.Today;
                emprestimo.Livro_Emprestado.AdicionarQuantidade(1);

                if (emprestimo.Emprestimo.Devolucao_Efetiva > emprestimo.Devolucao_Prevista)
                {
                    Multa_Biblioteca multa_emprestimo = new(
                        new(emprestimo.Emprestimo.Usuario),
                        emprestimo
                    );

                    usuario_emprestimo.Lista_Multas.Add( multa_emprestimo );
                    usuario_emprestimo.Saldo -= multa_emprestimo.Multa.Valor;

                    EnviarMensagem(usuario_id, string.Format($"Uma multa de valor " +
                        $"R$ {multa_emprestimo.Multa.Valor} foi registrada na sua conta "),
                        "Multa");
                }

                return true;
            }

            return false;
        }
        
        public bool EnviarMensagem(int usuario_id, string mensagem, string? assunto = null)
        {
            var usuario_destinatario = BuscarUsuario(usuario_id);

            if (usuario_destinatario != null)
            {
                string tipo;

                if (assunto == null)
                    tipo = "Telefone";
                else
                    tipo = "E-mail";

                    Mensagem_Biblioteca mensagem_enviar = new(
                        new(usuario_destinatario.Usuario, mensagem),
                        assunto
                    );
                usuario_destinatario.Caixa_Entrada.Add( mensagem_enviar );
                Console.WriteLine($"Uma mensagem foi enviada para o {tipo} do(a) " +
                    $"{usuario_destinatario.Usuario.Nome}");

                return true;
            }

            return false;
        }

        public List<Livro_Biblioteca> TodosLivros() { return Livros; }

        public List<Usuario_Biblioteca> TodosUsuarios() { return Usuarios; }

        public List<Emprestimo_Biblioteca> TodosEmprestimos() { return Emprestimos; }

        public List<Livro_Biblioteca> Busca(string? titulo, ISBN isbn)
        {
            List<Livro_Biblioteca> Resultado = Livros.FindAll(l => l.Livro.Titulo == titulo || 
                                                              l.Livro.ISBN == isbn);

            return Resultado;
        }
    }
}

//public bool AdicionarEmprestimo(Emprestimo_Biblioteca emprestimo_passado)
//{
//    var livro_emprestimo = BuscarLivro(emprestimo_passado.Livro_Emprestado.Livro.ISBN);
//    var usuario_emprestimo = BuscarUsuario(emprestimo_passado.Emprestimo.Usuario.ID, 
//                                           emprestimo_passado.Emprestimo.Usuario.Telefone);

//    if (emprestimo_passado.Emprestimo.Devolucao_Efetiva == null)
//    {
//        throw new ArgumentNullException("O emprestimo adicionado não teve devolução");            
//    }

//    if (livro_emprestimo != null && usuario_emprestimo != null)
//    {

//    }

//    return false;
//}