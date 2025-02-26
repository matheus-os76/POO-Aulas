using aula_03;

[TestClass]
public class TelevisaoTest
{
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Televisao(21f), Assert.AssertNonStrictThrowsInterpolatedStringHandler<ArgumentOutOfRangeException>);
    }
}