using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_Biblioteca
{
    public class Usuario
    {

        public Usuario(int id, string nome, Email email, Telefone telefone)
        {
            // Verifica se o nome e o id inseridos são válidos
            if (nome.Length <= 1 || string.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException($"O nome inserido não é válido: " +
                    $"\"{nome}\" não possui caracteres suficiente para formar um nome");
            }
            else if (nome.Any(char.IsDigit))
            {
                throw new ArgumentException($"O nome inserido não é válido: " +
                    $"\"{nome}\" possui dígitos");
            }
            else if (id < 0)
            {
                throw new ArgumentOutOfRangeException($"Número de ID inválido: " +
                    $"{id} é um número negativo");
            }

            Nome = nome;
            ID = id;
            Email = email;
            Telefone = telefone;
        } 
        public int ID { get; }
        public string Nome { get; }
        public Email Email { get; }
        public Telefone Telefone { get; }
    }
}
