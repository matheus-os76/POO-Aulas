using Gerenciador_Mensagens.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Archive
{
    internal class Imagem : Arquivo
    {
        public int[] Dimensoes { get; }
        public Imagem(string nome, Formato formato, int[] dimensoes) : base(nome, formato) 
        {
            if (!ArrayUtils.dimensoesValidas(dimensoes))
            {
                throw new ArgumentException($"Erro na criação da Imagem: " +
                                            $"As dimensões inseridas " +
                                            $"não são válidas.");
            }

            if (formato.Tipo != "imagem")
            {
                throw new ArgumentException($"Erro na criação da Imagem: " +
                                            $"O formato escolhido \"{formato.Nome}\" " +
                                            $"não suporta imagens!");
            }

            this.Dimensoes = dimensoes;
            Nome = nome;
            Formato = formato;
        }

        public string Resolucao() 
        { 
            return $"{Dimensoes[0]} x {Dimensoes[1]}";
        }
    }
}
