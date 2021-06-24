using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{
    public class CorrespondenciaRepository : ICorrespondencia
    {
        private ApiCorrespondenciaTest_dbContext _context;
        private DbSet<Correspondencia> _correspondencias;
        public CorrespondenciaRepository(ApiCorrespondenciaTest_dbContext context)
        {
            _context = context;
            _correspondencias = _context.Set<Correspondencia>();
        }

        public async Task Actualizar(Correspondencia entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Unchanged;
            await _context.SaveChangesAsync();
        }

        public async Task<Correspondencia> BuscarPorCodigo(object id)
        {
            return await _correspondencias.FirstOrDefaultAsync(s => s.IdCorrespondencia == id);
        }                                                                                                      

        public async Task<IEnumerable<Correspondencia>> BuscarPorParametro(Correspondencia entitySearch)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Correspondencia>> BuscarTodos()
        {
            return await _correspondencias
                .Include(s=>s.ObjIdRemitente)
                .ThenInclude(s=>s.IdRemitenteNavigation)
                .Include(s=>s.ObjIdDestinatario)
                .ThenInclude(s=>s.ObjIdDestinatario)
                .Include(s=>s.ObjIdEstado)
                .Include(s=>s.ObjIdTipoCorrespondencia)
                //.Include(s=>s.nav)
                .ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Eliminar(Correspondencia entityToDelete)
        {
            _correspondencias.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public Task EliminarPorCodigo(object id)
        {
            throw new NotImplementedException();
        }

        public async Task Insertar(Correspondencia entityToInsert)
        {
            _correspondencias.Add(entityToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
