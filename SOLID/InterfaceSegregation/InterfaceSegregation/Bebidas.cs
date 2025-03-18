namespace menu;

public class Bebidas
{
    public Bebidas(string Nome, float Litragem, string Tipo)
    {
        nome = Nome;
        litragem = Litragem;
        tipo = Tipo; 
    }
    public float litragem { get; set; }
    public string ?tipo { get; set; }
    public string ?nome { get; set; }
}