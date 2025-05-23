// Nota pro Professor: (22/05/2025)

// Eu sei que há commits aqui que são de Quinta-Feira (dia depois da prova),
// mas a primeira versão que eu fiz no dia da prova estava muito ruim,
// não que essa não esteja, e o professor tinha deixado entregar até Quinta-Feira
// por causa que alguns que trabalhavam durante o dia, então decidi
// refatorar o código entre a noite de Quarta e Quinta.
//
// Essa aqui é a versão final do meu código e gostaria muito que o professor
// me avaliasse por ela, mas caso o professor queira me avaliar
// com base em apenas código feito no dia exato da prova, aqui está o commit:
//
// https://github.com/matheus-os76/POO-Aulas/commit/cf14f572ae670e3447cca3ad24d618d16239537b
//
// Desde já, agradeço pelas aulas e exercícios que o professor passou durante o 
// semestre, esse aqui em particular me animou bastante e fez aprender muito =)

using Gerenciador_Mensagens;
using Gerenciador_Mensagens.Archive;
using Gerenciador_Mensagens.Message;
using Gerenciador_Mensagens.User;
using System.Reflection.Metadata;

string geradorNome()
{
    List<string> lista_nomes_possiveis = new List<string>() 
    { "José", "Maria", "João", "Ana", "Antônio", 
      "Francisca", "Francisco", "Antônia", "Carlos",
      "Adriana", "Paulo", "Juliana", "Pedro", "Márcia", 
      "Lucas", "Fernanda", "Luiz", "Patricia", "Marcos", 
      "Luis", "Aline", "Gabriel", "Sandra", "Rafael", 
      "Daniel", "Camila", "Marcelo", "Amanda", "Bruno",
      "Jéssica", "Eduardo", "Leticia", "Felipe", 
      "Julia", "Raimundo", "Luciana", "Rodrigo", "Vanessa",
      "Manoel", "Mariana", "Matheus", "Vera", "Mateus", 
      "André", "Vitória", "Fernando", "Larissa", 
      "Gustavo", "Cláudia", "Leonardo", "Beatriz", 
      "Guilherme", "Luana", "Tiago", "Renata", "Vitor"};
    List<string> lista_sobrenomes_possiveis = new List<string>()
    { "Silva", "Almeida", "Alves", "Araujo", "Andrade", 
      "Barbosa", "Barros", "Batista", "Campos",
      "Campos", "Cardoso", "Carvalho", "Castro",
      "Costa", "Dias", "Duarte", "Freitas",
      "Fernandes", "Garcia", "Gomes", "Gonçalves",
      "Lima", "Lopes", "Machado", "Marques", 
      "Martins", "Medeiros", "Melo", "Mendes",
      "Miranda", "Monteiros", "Moraes", "Moreira",
      "Moura", "Nascimento", "Nunes", "Oliveira",
      "Freire", "Pereira", "Ramos", "Reis",
      "Ribeiro", "Rocha", "Santana", "Santos",
      "Silva", "Soares", "Souza", "Teixeira", 
      "Viera"
    };

    Random random = new Random();
    string nome_escolhido = lista_nomes_possiveis.ElementAt(random.Next(0, lista_nomes_possiveis.Count));

    for (int i = 0; i < random.Next(1, 3); i++)
    {
        nome_escolhido = string.Concat(nome_escolhido, 
                                       ' ', 
                                       lista_sobrenomes_possiveis.ElementAt(random.Next(0, lista_sobrenomes_possiveis.Count)));
    }

    return nome_escolhido;
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
string geradorEmail(string email)
{
    Random random = new Random();
    
    List<Dominio> dominios_possiveis = new List<Dominio>()
    { Dominio.GMAIL, Dominio.YAHOO, Dominio.HOTMAIL,
      Dominio.AOL, Dominio.LIVE, Dominio.TERRA};

    Dominio dominio_escolhido = dominios_possiveis.ElementAt(random.Next(0, dominios_possiveis.Count));

    return string.Concat(email.ToLower(), '@', dominio_escolhido.Nome.ToLower(), ".com");
}
void mostrarTodosUsuarios(GerenciadorUsuarios sistema)
{
    string[] lista_nomes = sistema.listarUsuarios().ToArray();
    
    Console.WriteLine($"\n    [Lista de Todos Usuários - \"{sistema.Nome}\"]:\n");
    
    for (int i = 0; i < sistema.quantidadeUsuarios(); i++)
    {
        if (lista_nomes[i] != "Desconhecido")
            Console.WriteLine($"    {i + 1} - {lista_nomes[i]}");
        else
            Console.WriteLine($"    {i + 1} - ???");

        if (i == sistema.quantidadeUsuarios() - 1)
            Console.WriteLine();
    }
}

GerenciadorUsuarios teste = new GerenciadorUsuarios("Teste Gerenciador");

teste.adicionarUsuario("11980009555", "Matheus", "matheus@gmail.com");
mostrarTodosUsuarios(teste);

Mensagem mensagem = new Mensagem(new MTexto("Olá mundo"), Canal.Whatsapp);
Mensagem meme = new Mensagem(new MArquivo("Se liga nesse meme", 
                             new Imagem("trollface", Formato.PNG, [256, 128])), 
                             Canal.Telegram);

teste.enviarMensagem(mensagem, ATelefone.criarTelefone("11980009555"), null);

// TODO:
// Algum jeito de adicionar canais, formatos
// Refatorar (denovo??) todo o sistema de telefones 
// Documentação... T_T

//  "Professor, o ChatGPT comeu minha lição de casa"
//  Siga para mais piadas ;)

