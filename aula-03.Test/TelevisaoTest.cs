using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) n�o � suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_0_Ao_Mutar()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AlternarModoMudo();
        Assert.AreEqual(0, televisao.Volume);
    }


    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Iniciar_No_Primeiro_Canal()
    {
        Televisao televisao = new Televisao(25f);

        Assert.AreEqual(1, televisao.Canal);
    }

    [TestMethod]
    public void Canal_Subir_Funciona()
    {
        Televisao televisao = new Televisao(25f);
        
        televisao.SubirCanal();
        Assert.AreEqual(Televisao.PRIMEIRO_CANAL+1, televisao.Canal);
    }

    [TestMethod]
    public void Canal_Descer_Funciona()
    {
        Televisao televisao = new Televisao(25f);
        
        // Inicia no canal 1, sobe para o 2
        televisao.SubirCanal();

        // Desce de volta para o canal 1
        televisao.DescerCanal();
        Assert.AreEqual(Televisao.PRIMEIRO_CANAL, televisao.Canal);
    }

    [TestMethod]
    public void Subir_E_Descer_Canal_Devem_Estar_Dentro_Da_Faixa_De_Canais()
    {
        Televisao televisao = new Televisao(25f);

        // Tenta descer um canal partindo do primeiro canal
        televisao.DescerCanal();
        Assert.AreEqual(Televisao.ULTIMO_CANAL, televisao.Canal);

        // Tenta subir um canal partindo do ultimo canal
        televisao.SubirCanal();
        Assert.AreEqual(Televisao.PRIMEIRO_CANAL, televisao.Canal);
    }

    [TestMethod]
    public void Canal_Foi_Alterado_Pelo_Alterar_Canal()
    {
        Televisao televisao = new Televisao(25f);

        // Canal é iniciado no 1 e tenta mudar para o 2
        televisao.AlterarCanal(Televisao.PRIMEIRO_CANAL+1);
        Assert.AreEqual(Televisao.PRIMEIRO_CANAL+1, televisao.Canal);

        // Tenta mudar o canal para o ultimo canal
        televisao.AlterarCanal(Televisao.ULTIMO_CANAL);
        Assert.AreEqual(Televisao.ULTIMO_CANAL, televisao.Canal);
    }

    [TestMethod]
    public void Alterar_Canal_Nao_Pode_Alterar_Para_Canal_Invalido()
    {
        Televisao televisao = new Televisao(25f);

        // Tenta alterar pra um canal invalido abaixo da faixa possivel de canais
        televisao.AlterarCanal(Televisao.PRIMEIRO_CANAL-1);
        Assert.AreEqual(1, televisao.Canal);

        // Tenta alterar pra um canal invalido acima da faixa possivel de canais
        televisao.AlterarCanal(Televisao.ULTIMO_CANAL+1);
        Assert.AreEqual(1, televisao.Canal);
    }
    
}