namespace cozinha;

public class Balanca
{
    public float volume(Bolo bolo_alvo)
    {
        return (float) 3.14 * bolo_alvo.raio * bolo_alvo.raio * bolo_alvo.altura; 
    }

    public float peso(Bolo bolo_alvo)
    {
        return bolo_alvo.densidade * volume(bolo_alvo);
    }

    public float soma_volumes(float[] volumes)
    {
        float soma_volumes = 0;
        foreach (float volume in volumes)
        {
            soma_volumes += volume;
        }
        return soma_volumes;
    }

    public float soma_pesos(float[] pesos)
    {
        float soma_pesos = 0;
        foreach (float peso in pesos)
        {
            soma_pesos += peso;
        }
        return soma_pesos;
    }
}