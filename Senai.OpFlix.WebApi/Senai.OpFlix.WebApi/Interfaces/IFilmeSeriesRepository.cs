using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IFilmeSeriesRepository
    {
        List<FilmeSeries> Listar();
        void Cadastrar(FilmeSeries filmeSeries);
        void Atualizar(FilmeSeries filmeSeries);
        FilmeSeries BuscarPorId(int id);
        void Deletar(int id);
    }
}
