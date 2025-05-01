using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IRRF
{
    public static class IRRF
    {
        private static Byte Numero_Dependentes;
        private static float Aliquota;
        private static float Parcela;
        public static float CalcularImposto(Tabela_INSS Ano, float Salario_Bruto, Byte Dependentes = 0)
        {
            Numero_Dependentes = Dependentes;

            float Salario_Base = (INSS.CalcularImposto(Salario_Bruto, Ano) -
                (Numero_Dependentes * 189.59F));


            if (Salario_Base < 0) Salario_Base = 0;


            if (Salario_Base <= 2428.80)
            {
                Aliquota = 0;
                Parcela = 0;
            }
            else if (Salario_Base <= 2826.65)
            {
                Aliquota = 7.5F;
                Parcela = 182.16F;
            }
            else if (Salario_Base <= 3751.05)
            {
                Aliquota = 15;
                Parcela = 394.16F;
            }
            else if (Salario_Base <= 4664.68)
            {
                Aliquota = 22.5F;
                Parcela = 675.49F;
            }
            else
            {
                Aliquota = 27.5F;
                Parcela = 908.73F;
            }

            Aliquota /= 100;
            //Console.WriteLine($"Aliquota: {Aliquota}");
            //Console.WriteLine($"Parcela: {Parcela}");
            float Salario_Aliquota = Salario_Base * Aliquota;
            Salario_Aliquota -= Parcela;
            Salario_Base -= Salario_Aliquota;
            Salario_Base = (float) Math.Round((double) Salario_Base, 2);
            //Console.WriteLine($"Salario Aliquota: {Salario_Aliquota}");
            //Console.WriteLine($"Salario Base - Salario Aliquota: {Salario_Base - Salario_Aliquota}");
            return Salario_Base;
        }
    }
}
