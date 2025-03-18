using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace cozinha;

public class Bolo
{
    public Bolo(float Altura, float Raio, float Densidade)
    {
        if (Raio <= 0 | Densidade <= 0)
        {
            throw new ArgumentOutOfRangeException($"O bolo de raio {raio} não é possível");
        }
        densidade = Densidade;
        raio = Raio;
        altura = Altura;
    }

    public float densidade { get; }
    public float altura { get; }
    public float raio { get; }

}