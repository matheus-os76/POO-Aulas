using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IRRF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Número de Dependentes: ");
            byte Numero_Dependentes = Convert.ToByte(Console.ReadLine());
            Console.Write("Salario Bruto: ");
            float Salario_Bruto = Convert.ToSingle(Console.ReadLine().Replace('.', ','));

            Console.WriteLine($"Salario Liquido: R$ " +
                $"{IRRF.CalcularImposto(Tabela_INSS.INSS2025, Salario_Bruto, Numero_Dependentes)} ");
        }
    }
}
