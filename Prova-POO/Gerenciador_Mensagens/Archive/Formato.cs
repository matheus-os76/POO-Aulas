using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_Mensagens.Archive
{
    internal class Formato
    {
        public string Nome { get; }
        public string Tipo { get; }

        private Formato(string nome, string tipo) 
        {
            Nome = nome;
            Tipo = tipo;
        }

        public static Formato MP3 => new Formato("mp3", "audio");
        public static Formato MP4 => new Formato("mp4", "video");
        public static Formato WAV => new Formato("wav", "audio");
        public static Formato FLAC => new Formato("flac", "audio");
        public static Formato OGG => new Formato("ogg", "audio");
        public static Formato MKV => new Formato("mkv", "video");
        public static Formato PNG => new Formato("png", "imagem");
        public static Formato JPG => new Formato("jpg", "imagem");
        public static Formato WEBP => new Formato("webp", "imagem");
        public static Formato PDF => new Formato("pdf", "documento");
        public static Formato ZIP => new Formato("zip", "documento");
        public static Formato EXE => new Formato("exe", "documento");
    }
}
