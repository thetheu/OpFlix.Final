using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Classificacao
    {
        public Classificacao()
        {
            FilmeSeries = new HashSet<FilmeSeries>();
        }

        public int IdClassificacao { get; set; }
        public string Classificacao1 { get; set; }

        public ICollection<FilmeSeries> FilmeSeries { get; set; }
    }
}
