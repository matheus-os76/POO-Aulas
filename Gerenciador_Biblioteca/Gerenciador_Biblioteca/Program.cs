using System;
using System.Collections.Generic;

namespace Gerenciador_Biblioteca
{
    public class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new GerenciadorBiblioteca();

            // Adicionar livros
            biblioteca.AdicionarLivro("Clean Code", "Robert C. Martin", "978-0132350884");
            biblioteca.AdicionarLivro("Design Patterns", "Erich Gamma", "978-0201633610");

            // Adicionar usuários
            biblioteca.AdicionarUsuario("João Silva", 1);
            biblioteca.AdicionarUsuario("Maria Oliveira", 2);

            // Realizar empréstimo
            biblioteca.RealizarEmprestimo(1, "978-0132350884", 7);

            // Realizar devolução (com atraso simulado)
            // Note: Em uma aplicação real, você não manipularia as datas desta forma
            double multa = biblioteca.RealizarDevolucao("978-0132350884", 1);
            Console.WriteLine($"Multa por atraso: R$ {multa}");

            Console.ReadLine();
            Console.WriteLine("Teste");
        }
    }
}