﻿using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IPlataformaRepository
    {
        List<Plataforma> listar();
        void Cadastrar(Plataforma plataforma);
        void Atualizar(Plataforma plataforma);
        Plataforma BuscarPorId(int id);
    }
}
