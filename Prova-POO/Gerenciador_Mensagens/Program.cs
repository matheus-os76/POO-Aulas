using Gerenciador_Mensagens;
using Gerenciador_Mensagens.User;
using Gerenciador_Mensagens.Utils;

void mostrarUsuario(Usuario usuario)
{
    Console.WriteLine($"Usuário: {usuario.Nome}\n" +
                      $"Telefone: {usuario.Telefone.ToString()}\n" +
                      $"E-mail: {usuario.Email.ToString()}");
}

Usuario usuario = new Usuario("Matheus", "11999900000", "matheus@gmail.com");

mostrarUsuario(usuario);

