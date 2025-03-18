namespace menu;

public class Pratos
{
    public Pratos(string Nome, float Preco, float Peso)
    {
        nome = Nome;
        preco = Preco;
        peso = Peso; 
    }
    public string nome { get; set; }
    public float preco { get; set; }
    public float peso { get; set; }

}