namespace aula_03;

public class Televisao
{
    //O método construtor possui o mesmo nome da classe. 
    // Ele não possui retorno (nem mesmo o void)
    //Este método é executado sempre que uma instancia da classe
    //é criada.
    //Por padrão, o C# cria um método construtor publico vazio,
    //mas podemos criar métodos construtores com outras
    //visibilidades e recebendo parametros, se necessário.
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            throw new ArgumentOutOfRangeException($"O tamanho({tamanho}) não é suportado!");
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        Canal = PRIMEIRO_CANAL;
    }

    //Optamos pela utilização da constante para tornar o código mais legível.
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;
    public const int VOLUME_MAXIMO = 12;
    public const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;
    private int _ultimoVolume = VOLUME_PADRAO;
    public const int PRIMEIRO_CANAL = 1;
    public const int ULTIMO_CANAL = 10;

    //Get: permite que seja executada a 
    //leitura do valor atual da propriedade
    //Set: permite que seja atibuído um 
    //valor para a propriedade

    //classes, propriedades e métodos possuem modificadores de acesso
    //public: visiveis a todo o projeto
    //internal: visiveis somente no namespace - padrão
    //protected: visiveis somente na classe e nas classes que herdam
    //private: visiveis somente na classe que foram criados
    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get; set; }
    public bool Estado { get; set; }
    private bool Tv_mutada { get; set; }

    public void AumentarVolume()
    {
        if (Volume < VOLUME_MAXIMO && !Tv_mutada)
        {
            Volume++;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume máximo permitido");
        }
    }

    public void DiminuirVolume()
    {
        if (Volume > VOLUME_MINIMO && !Tv_mutada)
        {
            Volume--;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume mínimo permitido");
        }
    }

    //1 botao de mudo -  toggle (on/off)
    //Volume = x; Volume = 0; Volume = x;
    public void AlternarModoMudo()
    {
        if (Volume > VOLUME_MINIMO)
        {
            _ultimoVolume = Volume;
            Tv_mutada = true;
            Volume = VOLUME_MINIMO;
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else
        {
            Tv_mutada = false;
            Volume = _ultimoVolume;
            Console.WriteLine($"O volume da TV é: {Volume}.");
        }
    }

    public void SubirCanal()
    {
        if (Canal < ULTIMO_CANAL)
        {
            Canal++;
        } else {
            Canal = PRIMEIRO_CANAL;
        }
    }

    public void DescerCanal()
    {
        if (Canal > PRIMEIRO_CANAL)
        {
            Canal--;
        } else {
            Canal = ULTIMO_CANAL;
        }
    }

    public void AlterarCanal(int canal_alvo)
    {
        if (canal_alvo >= PRIMEIRO_CANAL && canal_alvo <= ULTIMO_CANAL)
        {
            if (Canal != canal_alvo)
            {
                Canal = canal_alvo;
            } else {
                Console.WriteLine("A TV já está sintonizada neste canal!");
            }
        }
    }
}