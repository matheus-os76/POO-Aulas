using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Archive
{
    internal class Video : Arquivo
    {
        public int[] Dimensoes { get; }
        public TimeSpan Duracao { get; }
        public Video(string nome,
                     Formato formato,
                     int[] dimensoes,
                     TimeSpan duracao) : base(nome, formato)
        {

            if (!ArrayUtils.dimensoesValidas(dimensoes))
            {
                throw new ArgumentException($"Erro na criação do Video: " +
                                            $"As dimensões inseridas " +
                                            $"não são válidas.");
            }

            if (formato.Tipo != "video")
            {
                throw new ArgumentException($"Erro na criação do Video: " +
                                            $"O formato escolhido \"{formato.Nome}\" " +
                                            $"não suporta videos!");
            }

            Dimensoes = dimensoes;
            Duracao = duracao;
        }
        public string Resolucao()
        {
            return $"{Dimensoes[0]} x {Dimensoes[1]}";
        }
        public string tempoDuracao()
        {
            return Duracao.ToString();
        }
    }
}
