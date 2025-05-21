using Gerenciador_Mensagens;

Usuario usuario = new Usuario("Matheus", "11981900792");

Mensagem mensagem = new Mensagem("Eae, se liga no meme",
                                 usuario,
                                 Canal.Whatsapp,
                                 new DateTime(2000, 3, 4));

Mensagem.EnviarUsuario(mensagem);

Console.WriteLine(usuario.Caixa_Entrada.ToArray()[0]._Mensagem);