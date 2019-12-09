using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuario usuario = ctx.Usuario.Include(x => x.IdTipoNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);   
                if (usuario == null)
                    return null;
                return usuario;
            }
        }


    }
}
