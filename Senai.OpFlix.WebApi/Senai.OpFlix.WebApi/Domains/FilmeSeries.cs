using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class FilmeSeries
    {
        public int IdFs { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataLancamento { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdIdentificacao { get; set; }
        public string Sinopse { get; set; }
        public int TempoDuracao { get; set; }
        public string Veiculo { get; set; }
        public int? IdClassificacao { get; set; }
        public int? IdPlataforma { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Classificacao IdClassificacaoNavigation { get; set; }
        public Identificacao IdIdentificacaoNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
    }
}
