using Aula5;

public interface IFreteResult
{
    FreteResult CalcularFrete(decimal Distancia, bool EntregaExpressa, decimal Peso);
}