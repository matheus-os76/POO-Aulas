using Gerenciador_Biblioteca.Classes;
using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Program
    {
        static void Main(string[] args)
        {

            //// Realizar empréstimo
            //biblioteca.RealizarEmprestimo(1, "978-0132350884", 7);

            //// Realizar devolução (com atraso simulado)
            //// Note: Em uma aplicação real, você não manipularia as datas desta forma
            //double multa = biblioteca.RealizarDevolucao("978-0132350884", 1);
            //Console.WriteLine($"Multa por atraso: R$ {multa}");

            //Console.ReadLine();

            // Criação Biblioteca
            var Biblioteca = new GerenciadorBiblioteca();

            // Criação Livros
            Livro[] livros_teste = new Livro[5];

            livros_teste[0] = new("Meridiano de Sangue", "Cormac McCarthy", new ISBN("978-8556521095"));
            livros_teste[1] = new("Mob Psycho 100 - Volume 1", "ONE", new ISBN("978-8542608656"));
            livros_teste[2] = new("Não Tenhais Medo", "Elton Mesquita", new ISBN("978-8594261076"));
            livros_teste[3] = new("Clean Code", "Robert C. Martin", new ISBN("978-0132350884"));
            livros_teste[4] = new("Design Patterns", "Erich Gamma", new ISBN("978-0201633610"));

            // Criação Usuários
            Usuario[] usuarios_teste = new Usuario[3];

            usuarios_teste[0] = new(1, "Matheus", new Email("matheusosmedio@gmail.com"), new Telefone("1234-56789"));
            usuarios_teste[1] = new(2, "Sofia", new Email("sofia_carmo@gmail.com"), new Telefone("01234-5678"));
            usuarios_teste[2] = new(3, "José", new Email("jose45@gmail.com"), new Telefone("97993-3999"));

            //Adição dos usuários e dos livros dentro da Biblioteca 
            Biblioteca.AdicionarLivro(livros_teste[0], 0);
            Biblioteca.AdicionarLivro(livros_teste[1], 100);
            Biblioteca.AdicionarLivro(livros_teste[2], 12);
            Biblioteca.AdicionarLivro(livros_teste[3], 7);
            Biblioteca.AdicionarLivro(livros_teste[4], 2);

            //Adição dos usuários e dos livros dentro da Biblioteca 
            foreach (var usuario in usuarios_teste)
                Biblioteca.AdicionarUsuario(usuario);

            //Ver todos os livros e usuários
            Console.WriteLine("Todos os Livros: \n");
                foreach (var livros in Biblioteca.TodosLivros())
                    Console.WriteLine($"\"{livros.Livro.Titulo}\" - {livros.Livro.Autor}");


            Console.WriteLine("\nTodos os Usuários \n");
                foreach (var usuario in Biblioteca.TodosUsuarios())
                    Console.WriteLine($"ID: {usuario.Usuario.ID} - Nome: {usuario.Usuario.Nome}");
            
            // Emprestimos
            Biblioteca.RealizarEmprestimo(1, livros_teste[1].ISBN, 10);

            // Todas as mensagens dos Usuários

            // E-mails
            Console.WriteLine("\n\nTodas as Caixa de Mensagens: ");

            Console.WriteLine("\nE-mail:");
            foreach (var user in Biblioteca.TodosUsuarios())
            {
                foreach (var msg in user.Caixa_Entrada)
                { 
                    if (msg.Assunto != null)
                        Console.WriteLine($"Dest: {user.Usuario.Nome} - Assunto: {msg.Assunto} - \"{msg.mensagem.Conteudo}\"");
                }

            }

            // SMS por Telefone
            Console.WriteLine("\nTelefone:");
            foreach (var user in Biblioteca.TodosUsuarios())
            {
                foreach (var msg in user.Caixa_Entrada)
                {
                    if (msg.Assunto == null)
                        Console.WriteLine($"Dest: {user.Usuario.Nome} - \"{msg.mensagem.Conteudo}\"");
                }
            }
        }
    }
}