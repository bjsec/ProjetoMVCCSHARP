using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVCCSHARP.Models
{
    public class Noticia
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }

        public Noticia(int iD,string titulo,string resumo,string conteudo)
        {
            ID = iD;
            Titulo = titulo;
            Resumo = resumo;
            Conteudo = conteudo;
        }
        public Noticia()
        { }

    }
}
