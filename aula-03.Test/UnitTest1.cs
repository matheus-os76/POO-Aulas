namespace aula_03.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Soma_Deve_Retornar_5()
    {
        int resultado = 2 + 3;

       Assert.AreEqual(5, resultado);
    }
}