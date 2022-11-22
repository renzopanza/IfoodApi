using Ifood.Data;
using Ifood.Models;
using Microsoft.EntityFrameworkCore;

namespace Ifood.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly RobinContext context;

        public UsuarioService(RobinContext context)
        {
            this.context = context;
        }

        public async Task<UsuarioModel> BuscarPorLogin(string login)
        {
            return await context.Usuarios.FirstOrDefaultAsync(x => x.LoginUser == login);
        }

        public async Task<UsuarioModel> CadastrarUsuario(UsuarioModel user)
        {
            foreach(UsuarioModel usuario in await context.Usuarios.ToListAsync())
            {
                if (usuario.LoginUser == user.LoginUser || usuario.Email == user.Email || usuario.Celular == user.Celular)
                {
                    return null;
                }
            }

            user.DataCadastro = DateTime.Now;
            context.Usuarios.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

    }
}
