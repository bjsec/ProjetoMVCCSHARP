using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace ProjetoMVCCSHARP.Models
{
    public class Noticia
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }

        public string Imagem { get; set; }

        public Noticia(int iD,string titulo,string resumo,string conteudo, string imagem)
        {
            ID = iD;
            Titulo = titulo;
            Resumo = resumo;
            Conteudo = conteudo;
            Imagem = imagem;
        }
        public Noticia()
        { }

    }
}
