using Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PersonaRepository : IPersona
    {

        private ApiCorrespondenciaTest_dbContext _context;
        private DbSet<Persona> _personas;
        public PersonaRepository(ApiCorrespondenciaTest_dbContext context)
        {
            _context = context;
            _personas = _context.Set<Persona>();
        }
      
        public async Task Actualizar(Persona entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Persona> BuscarPorCodigo(object id)
        {
            var persona = await _personas.FirstOrDefaultAsync(s => s.IdPersona == (int)id);
            if (persona!=null)
            {
                return persona;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Persona>> BuscarPorParametro(Persona entitySearch)
        {
            var personas =  await _personas.ToListAsync();

            if (!string.IsNullOrEmpty(entitySearch.Nombre))
            {
                personas = personas.Where(s => s.Nombre.Contains(entitySearch.Nombre)).ToList();
            }   
            if (!string.IsNullOrEmpty(entitySearch.Apellidos))
            {
                personas = personas.Where(s => s.Apellidos.Contains(entitySearch.Apellidos)).ToList();
            }    
            if (!string.IsNullOrEmpty(entitySearch.Identificacion.Value.ToString()))
            {
                personas = personas.Where(s => s.Nombre.Contains(entitySearch.Identificacion.Value.ToString())).ToList();
            }

            return personas;
        }

        public async Task<IEnumerable<Persona>> BuscarTodos()
        {
            return await _personas.ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Eliminar(Persona entityToDelete)
        {
            _personas.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public Task EliminarPorCodigo(object id)
        {
            throw new NotImplementedException();
        }

        public async Task Insertar(Persona entityToInsert)
        {
            _personas.Add(entityToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
