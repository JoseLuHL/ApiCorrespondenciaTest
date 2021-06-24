using Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Repositories.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private ApiCorrespondenciaTest_dbContext _context;
        private DbSet<Usuario> _usuarios;
        public UsuarioRepository(ApiCorrespondenciaTest_dbContext context)
        {
            _context = context;
            _usuarios = _context.Set<Usuario>();
        }


        public async Task Actualizar(Usuario entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> BuscarPorCodigo(object id)
        {
            var usuario = await _usuarios.FirstOrDefaultAsync(s => s.IdUsuario == (int)id);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Usuario>> BuscarPorParametro(Usuario entitySearch)
        {
            if (!string.IsNullOrEmpty(entitySearch.Login) && !string.IsNullOrEmpty(entitySearch.Password))
            {
                var usuario = await _usuarios.Where(s => s.Login == entitySearch.Login && s.Password == Utility.Utility.MD5(entitySearch.Password)).ToListAsync();
                if (usuario.Count > 0)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Usuario>> BuscarTodos()
        {
            return await _usuarios.ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Eliminar(Usuario entityToDelete)
        {
            _usuarios.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPorCodigo(object id)
        {
            var usuario = await _usuarios.FirstOrDefaultAsync(s => s.IdUsuario == (int)id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Insertar(Usuario entityToInsert)
        {
            _usuarios.Add(entityToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
