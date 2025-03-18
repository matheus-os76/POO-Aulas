// See https://aka.ms/new-console-template for more information
using cozinha;

Bolo chocolate = new Bolo((float) 7.5, 10, (float) 0.0015);
Bolo morango = new Bolo((float) 12, (float) 6.7, (float) 0.00102);
Bolo baunilha = new Bolo((float) 4.5, 5, (float) 0.00085);

Balanca balanca_mercado = new Balanca();

float[] volumes = new float[3];

volumes[0] = balanca_mercado.volume(chocolate);
volumes[1] = balanca_mercado.volume(morango);
volumes[2] = balanca_mercado.volume(baunilha);

Console.WriteLine($"{balanca_mercado.soma_volumes(volumes)} cm^3");

float[] pesos = new float[3];

pesos[0] = balanca_mercado.peso(chocolate);
pesos[1] = balanca_mercado.peso(morango);
pesos[2] = balanca_mercado.peso(baunilha);

Console.WriteLine($"{balanca_mercado.soma_pesos(pesos)} kg");