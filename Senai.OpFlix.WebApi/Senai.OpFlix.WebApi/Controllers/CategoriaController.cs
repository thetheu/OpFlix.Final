using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }
        public CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar" + ex.Message});
                
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Categoria categoria)
        {
            try
            {
                Categoria CategoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (CategoriaBuscada == null)
                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro Ao Atualizar Categoria"});       
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categoria Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }
    }
}