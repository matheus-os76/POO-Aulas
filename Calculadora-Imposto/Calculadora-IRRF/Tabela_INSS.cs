using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IRRF
{
    public struct Tabela_INSS
    {
        private Tabela_INSS(Int16 ano, Dictionary<float, float[]> tabela, float teto)
        {
            if (ano < 1995)
                throw new ArgumentOutOfRangeException($"Não é possível adicionar uma tabela" +
                    $"anterior ao Plano Real");

            if (tabela == null)
                throw new ArgumentNullException("Tabela vázia, por favor acrescentar os" +
                    "valores");

            if (teto <= 0)
                throw new ArgumentNullException("Não é possível adicionar um valor para o teto" +
                    "menor ou igual a 0");

            Ano = ano;
            Tabela = tabela;
            Teto = teto;
        }

        public Int16 Ano { get; }
        public Dictionary<float, float[]> Tabela { get; }
        public float Teto { get; }

        public static Tabela_INSS INSS2025 => new Tabela_INSS(
            2025,
            new Dictionary<float, float[]>()
            {
                { 7.5F, new float[] { 1518F , 0 } },
                { 9F, new float[] { 2793.88F , 22.77F } },
                { 12F, new float[] { 4190.83F , 106.59F } },
                { 14F, new float[] { 8157F , 675.49F } },
            },
            951.64F
        );

        public static Tabela_INSS INSS2024 => new Tabela_INSS(
            2024,
            new Dictionary<float, float[]>()
            {
                { 7.5F, new float[] { 1412F , 0 } },
                { 9F, new float[] { 2666.68F , 21.18F } },
                { 12F, new float[] { 4000.03F , 101.18F } },
                { 14F, new float[] { 7786.02F , 181.18F } },
            },
            908.86F
        );

    }
}
