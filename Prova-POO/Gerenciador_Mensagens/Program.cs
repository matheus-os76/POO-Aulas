using Gerenciador_Mensagens;
using Gerenciador_Mensagens.Archive;
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

List<Arquivo> arquivos = new List<Arquivo>(3);

Imagem imagem = new Imagem("meme", Formato.PNG, [5,5]);
Video video = new Video("gravacao", Formato.MP4, [6,7], new TimeSpan(0,3,4));
Documento documento = new Documento("prova", Formato.PDF, 5F);

arquivos.Add(imagem);
arquivos.Add(video);
arquivos.Add(documento);

for (int i = 0; i < arquivos.Count; i++)
{
    // Print coisas dentro da lista
    Console.WriteLine($"Arquivo ({StringUtils.Capitalizar(arquivos[i].Tipo)}):   " +
                      $"{arquivos[i].ToString()}\n");
    Console.WriteLine($"    Nome: {arquivos[i].Nome}");
    Console.WriteLine($"    Tipo: {arquivos[i].Tipo}");
    Console.WriteLine($"    Formato: {arquivos[i].Formato.Nome}\n\n");
}

// TODO:
// Refazer complementamente o jeito de enviar mensagens
// Refatorar os canais
// Algum jeito de adicionar canais, formatos

// OBS: X-X to morto

