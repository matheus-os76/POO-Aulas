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

string geradorTelefone()
{
    Random random = new Random();

    string primeira_parte,
           segunda_parte,
           ddd;

    primeira_parte = random.Next(91000, 99999).ToString();
    segunda_parte = random.Next(9100, 9999).ToString();
    ddd = random.Next(11, 99).ToString();

    return string.Concat(ddd,primeira_parte,segunda_parte);
}

Usuario usuario1 = new Usuario("Matheus", geradorTelefone(), "matheus@gmail.com");
Usuario usuario2 = new Usuario("José", geradorTelefone(), "jose@gmail.com");
Usuario usuario3 = new Usuario("Sofia", geradorTelefone(), "sofia@gmail.com");
Usuario usuario4 = new Usuario("Vitória", geradorTelefone(), "vitoria@gmail.com");



//List<Arquivo> arquivos = new List<Arquivo>(3);

//Imagem imagem = new Imagem("meme", Formato.PNG, [5,5]);
//Video video = new Video("gravacao", Formato.MP4, [6,7], new TimeSpan(0,3,4));
//Documento documento = new Documento("prova", Formato.PDF, 5F);

//Mensagem mensagem = new Mensagem(new MTexto("Olá mundo"), 
//                                 Canal.Whatsapp, 
//                                 "11999900000");


//arquivos.Add(imagem);
//arquivos.Add(video);
//arquivos.Add(documento);

//for (int i = 0; i < arquivos.Count; i++)
//{
//    // Print coisas dentro da lista
//    Console.WriteLine($"Arquivo ({StringUtils.Capitalizar(arquivos[i].Tipo)}):   " +
//                      $"{arquivos[i].ToString()}\n");
//    Console.WriteLine($"    Nome: {arquivos[i].Nome}");
//    Console.WriteLine($"    Tipo: {arquivos[i].Tipo}");
//    Console.WriteLine($"    Formato: {arquivos[i].Formato.Nome}\n\n");
//}

// TODO:
// Refazer complementamente o jeito de enviar mensagens
// Refatorar os canais
// Algum jeito de adicionar canais, formatos

// OBS: X-X to morto

