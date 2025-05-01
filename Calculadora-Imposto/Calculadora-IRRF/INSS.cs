using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IRRF
{
    public static class INSS 
    {

        private static float Aliquota;
        private static float Parcela;
        public static float CalcularImposto(float Salario_Bruto, Tabela_INSS Ano_INSS)
        {

            if (Salario_Bruto <= 0)
                throw new ArgumentOutOfRangeException("Salario inserido é " +
                    "menor ou igual a zero");

            for (int i = 0; i < Ano_INSS.Tabela.Count; i++)
            {
                if (Salario_Bruto <= Ano_INSS.Tabela.Values.ElementAt(i).ElementAt(0))
                {
                    Aliquota = Ano_INSS.Tabela.Keys.ElementAt(i);
                    Parcela = Ano_INSS.Tabela.Values.ElementAt(i).ElementAt(1);
                    break;
                }

                if (i == Ano_INSS.Tabela.Count)
                    return Ano_INSS.Teto;
            }

            float Salario_Aliquota = (Salario_Bruto * Aliquota) / 100;
            Salario_Aliquota -= Parcela;
            Salario_Bruto -= Salario_Aliquota;

            return Salario_Bruto;

        }
    }
}