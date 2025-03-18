namespace cozinha;

public class Chefe
{
    public bool tem_faca { get; set; }
    public bool tem_pratos { get; set; }

    public Chefe(bool tem_faca, bool tem_pratos) {}
    
    public int Cortar(Bolo bolo_alvo)
    {
        if (bolo_alvo.total_pedacos > 0 & tem_faca & tem_pratos)
        {
            bolo_alvo.total_pedacos--;
            return 1;
        }
        else
        {
            Console.WriteLine("O bolo era uma mentira!!");
            return 0;
        }
    }
}
