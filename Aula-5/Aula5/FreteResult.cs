namespace Aula5;

public class FreteResult
{
    public int dias { get; }
    public decimal valorFrete { get; }

    public FreteResult(int Dias, decimal ValorFrete)
    {
        dias = Dias;
        valorFrete = ValorFrete;
    }
}
