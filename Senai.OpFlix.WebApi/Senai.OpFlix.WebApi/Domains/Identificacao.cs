using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Identificacao
    {
        public Identificacao()
        {
            FilmeSeries = new HashSet<FilmeSeries>();
        }

        public int IdIdentificacao { get; set; }
        public string Nome { get; set; }

        public ICollection<FilmeSeries> FilmeSeries { get; set; }
    }
}
