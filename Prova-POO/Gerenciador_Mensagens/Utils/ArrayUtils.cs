using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Utils
{
    internal static class ArrayUtils
    {
        public static bool dimensoesValidas(int[] dimensoes)
        {
            if (dimensoes == null)
            {
                return false;
            }

            if (dimensoes.Length != 2)
            {
                return false;
            }

            if (dimensoes[0] <= 0 || dimensoes[1] <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
