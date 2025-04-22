using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Gerenciador_Biblioteca
{
    public class GerenciadorBiblioteca
    {
        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public void AdicionarLivro(Livro livro_adicionar)
        {
            foreach (var livro in livros)
            {
                if (livro.ISBN.Codigo == livro_adicionar.ISBN.Codigo)
                {
                    throw new ArgumentException($"O livro \"{livro_adicionar.Titulo}\" " +
                        $"possui o ISBN ({livro_adicionar.ISBN}) duplicado");
                }
            }

            Livro livro_biblioteca = new(livro_adicionar.Titulo, livro_adicionar.Autor, livro_adicionar.ISBN, livro_adicionar.Disponivel, livro_adicionar.Quantidade);
            livros.Add(livro_biblioteca);

            Console.WriteLine($"O livro \"{livro_biblioteca.Titulo}\" foi adicionado a biblioteca.");
        }

        public void AdicionarUsuario(Usuario usuario_adicionar)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.ID == usuario_adicionar.ID)
                {
                    throw new ArgumentException($"O usuário \"{usuario_adicionar.Nome}\" " +
                        $"possui o mesmo ID do usuário \"{usuario.Nome}\"");
                }

                if (usuario.Telefone.Num_Telefone == usuario_adicionar.Telefone.Num_Telefone)
                {
                    throw new ArgumentException($"O usuário \"{usuario_adicionar.Nome}\" " +
                        $"possui o mesmo Telefone do usuário \"{usuario.Nome}\"");
                }

            }

            Usuario usuario_biblioteca = new(usuario_adicionar.ID, usuario_adicionar.Nome, usuario_adicionar.Email, usuario_adicionar.Telefone);
            usuarios.Add(usuario_biblioteca);

            Console.WriteLine($"O usuário \"{usuario_adicionar.Nome}\" foi adicionado a biblioteca.");
        }
        
        public bool RealizarEmprestimo(Usuario usuario, Livro livro, int diasEmprestimo)
        {
            var livro_biblioteca = livros.Find(l => l.ISBN == livro.ISBN);
            var usuario_biblioteca = usuarios.Find(u => u.ID == usuario.ID);

            if (livro_biblioteca != null && usuario_biblioteca != null && livro_biblioteca.Disponivel)
            {
                livro_biblioteca.retirar_quantidade(1);

                Emprestimo emprestimo = new(livro_biblioteca, usuario_biblioteca, DateTime.Today, DateTime.Today.AddDays(diasEmprestimo));
                emprestimos.Add(emprestimo);

                Console.WriteLine($"O livro \"{livro_biblioteca.Titulo}\" foi emprestado ao usuário \"{usuario_biblioteca.Nome}\", " +
                    $"com data prevista de devolução para " +
                    $"{emprestimo.DataDevolucaoPrevista.Day}/" +
                    $"{emprestimo.DataDevolucaoPrevista.Month}/" +
                    $"{emprestimo.DataDevolucaoPrevista.Year}");

                EnviarEmail(usuario_biblioteca.Email,
                "Empréstimo Realizado",
                $"Você pegou emprestado o livro: {livro_biblioteca.Titulo} ");

                EnviarSMS(usuario_biblioteca.Telefone, $"Você pegou emprestado o livro: {livro_biblioteca.Titulo} ");


                return true;
            }

            Console.WriteLine($"O livro \"{livro.Titulo}\" está indísponível no momento");
            return false;

        }

        public void EnviarEmail(Email email_destino, string assunto, string mensagem)
        {
            if (string.IsNullOrEmpty(assunto) || string.IsNullOrEmpty(mensagem))
            {
                throw new ArgumentNullException("A mensagem ou o assunto estão vázios");
            }

            Console.WriteLine($"A mensagem sobre \"{assunto}\" foi enviada para o e-mail {email_destino.Endereco}");
            Console.WriteLine($"\n\n Para: {email_destino.Endereco}\n   {mensagem}\n\n");
        }

        public void EnviarSMS(Telefone telefone_destino, string mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
            {
                throw new ArgumentNullException("A mensagem está vázia");
            }

            Console.WriteLine($"Biblioteca: {mensagem}");
        }

        //// Método que realiza devolução e calcula multa
        //public double RealizarDevolucao(string isbn, int usuarioId)
        //{
        //    var emprestimo = emprestimos.Find(e =>
        //        e.Livro.ISBN == isbn &&
        //        e.Usuario.ID == usuarioId &&
        //        e.DataDevolucaoEfetiva == null);

        //    if (emprestimo != null)
        //    {
        //        emprestimo.DataDevolucaoEfetiva = DateTime.Now;
        //        emprestimo.Livro.Disponivel = true;

        //        // Calcular multa (R$ 1,00 por dia de atraso)
        //        double multa = 0;
        //        if (DateTime.Now > emprestimo.DataDevolucaoPrevista)
        //        {
        //            TimeSpan atraso = DateTime.Now - emprestimo.DataDevolucaoPrevista;
        //            multa = atraso.Days * 1.0;

        //            // Enviar email sobre multa
        //            EnviarEmail(emprestimo.Usuario.Nome, "Multa por Atraso",
        //                "Você tem uma multa de R$ " + multa);
        //        }

        //        return multa;
        //    }

        //    return -1; // Código de erro
        //}

        //// Método para buscar todos os livros
        //public List<Livro> BuscarTodosLivros()
        //{
        //    return livros;
        //}

        //// Método para buscar todos os usuários
        //public List<Usuario> BuscarTodosUsuarios()
        //{
        //    return usuarios;
        //}

        //// Método para buscar todos os empréstimos
        //public List<Emprestimo> BuscarTodosEmprestimos()
        //{
        //    return emprestimos;
        //}
    }
}
