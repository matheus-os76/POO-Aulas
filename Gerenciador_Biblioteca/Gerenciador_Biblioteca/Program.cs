using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var biblioteca = new GerenciadorBiblioteca();

            //// Adicionar livros
            //biblioteca.AdicionarLivro("Clean Code", "Robert C. Martin", "978-0132350884");
            //biblioteca.AdicionarLivro("Design Patterns", "Erich Gamma", "978-0201633610");

            //// Adicionar usuários
            //biblioteca.AdicionarUsuario("João Silva", 1);
            //biblioteca.AdicionarUsuario("Maria Oliveira", 2);

            //// Realizar empréstimo
            //biblioteca.RealizarEmprestimo(1, "978-0132350884", 7);

            //// Realizar devolução (com atraso simulado)
            //// Note: Em uma aplicação real, você não manipularia as datas desta forma
            //double multa = biblioteca.RealizarDevolucao("978-0132350884", 1);
            //Console.WriteLine($"Multa por atraso: R$ {multa}");

            //Console.ReadLine();

            Livro[] livros_teste = new Livro[3];

            livros_teste[0] = new("Meridiano de Sangue", "Cormac McCarthy", new isbn("978-8556521095"), false, 0);
            livros_teste[1] = new("Mob Psycho 100 - Volume 1", "ONE", new isbn("978-8542608656"), true, 100);
            livros_teste[2] = new("Não Tenhais Medo", "Elton Mesquita", new isbn("978-8594261076"), true, 12);

            Usuario[] usuarios_teste = new Usuario[2];
            usuarios_teste[0] = new(1, "Matheus", new Email("matheusosmedio@gmail.com"), new Telefone("1234-56789"));
            usuarios_teste[1] = new(2, "Sofia", new Email("sofia_carmo@gmail.com"), new Telefone("01234-5678"));

            //Emprestimo teste = new(
            //    livros_teste[0], 
            //    usuarios_teste[0], 
            //    DateTime.Today, 
            //    new DateTime(2025, 6, 4), 
            //    DateTime.Today.AddDays(4));

            GerenciadorBiblioteca teste = new();

            foreach (var livro in livros_teste)
            {
                teste.AdicionarLivro(livro);   
            }

            foreach (var usuario in usuarios_teste)
            {
                teste.AdicionarUsuario(usuario);
            }

            teste.RealizarEmprestimo(usuarios_teste[0], livros_teste[2], 7);
        }
    }
}