namespace cozinha;

public class Bolo
{
    public Bolo(string Sabor, float Raio)
    {
        if (Raio <= 0)
        {
            throw new ArgumentOutOfRangeException($"O bolo de raio {raio} não é possível");
        }
        if (Sabor is null)
        {
            throw new ArgumentNullException($"Por favor, coloque um sabor para o bolo");
        }
        sabor = Sabor;
        raio = Raio;
        total_pedacos = 18;
    }

    public string sabor { get; }
    public float raio { get; }
    public int total_pedacos { get; set; }

}