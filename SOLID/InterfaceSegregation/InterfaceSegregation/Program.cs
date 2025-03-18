// Pergunta se o usuario vai querer bebida, caso não, nem mostra pra ele as opções

using menu;

Pratos pratos_1 = new Pratos("Parmegiana de Frango", (float) 45, (float) 750);
Pratos pratos_2 = new Pratos("Bife Acebolado", (float) 35, (float) 670);
Pratos pratos_3 = new Pratos("Omelete com Fritas", (float) 30, (float) 500);
Pratos pratos_4 = new Pratos("Picanha", (float) 65, (float) 800);

Bebidas bebidas_1 = new Bebidas("Suco de Uva", (float) 600, "suco");
Bebidas bebidas_2 = new Bebidas("Coca-Cola", (float) 350, "refrigerante");
Bebidas bebidas_3 = new Bebidas("Guaraná", (float) 2000, "refrigerante");
Bebidas bebidas_4 = new Bebidas("Água", (float) 500, "agua");

Console.WriteLine("Olá, você vai querer bebida? (S/N)");

if (Console.ReadKey().Key == ConsoleKey.S)
{
    Console.WriteLine("\n");
    Console.WriteLine("Bebidas: \n");
    Console.WriteLine($"{bebidas_1.nome}");
    Console.WriteLine($"{bebidas_2.nome}");
    Console.WriteLine($"{bebidas_3.nome}");
    Console.WriteLine($"{bebidas_4.nome}");
} 
Console.WriteLine("");
Console.WriteLine("Pratos: \n");
Console.WriteLine($"{pratos_1.nome}");
Console.WriteLine($"{pratos_2.nome}");
Console.WriteLine($"{pratos_3.nome}");
Console.WriteLine($"{pratos_4.nome}");
