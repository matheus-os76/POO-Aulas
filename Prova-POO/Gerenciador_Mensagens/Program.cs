using Gerenciador_Mensagens;
using Gerenciador_Mensagens.Message;
using Gerenciador_Mensagens.User;
using Gerenciador_Mensagens.Utils;
void mostrarUsuario(Usuario usuario)
{
    Console.WriteLine($"Usuário: {usuario.Nome}\n" +
                      $"Telefone: {usuario.Telefone.ToString()}\n" +
                      $"E-mail: {usuario.Email.ToString()}");
}

Usuario usuario = new Usuario("Matheus", "11999900000", "matheus@gmail.com");

Mensagem mensagem = new Mensagem(usuario, 
                    Canal.Telegram, 
                    new MArquivo("Olá arquivo", 
                                 new Arquivo("documento", Formato.PDF)
                    ));

// TODO:
// Refatorar a classe Arquivo e Formato
// Refazer complementamente o jeito de enviar mensagens
// Refatorar os canais
// Algum jeito de adicionar canais, formatos

// OBS: X-X to morto

