using Contracts;
using Contracts.General;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DestinatarioRepository : IDestinatario
    {
        private ApiCorrespondenciaTest_dbContext _context;
        private DbSet<Persona> _destinatarios;
        private IPersona _personas;
        public DestinatarioRepository(ApiCorrespondenciaTest_dbContext context, IPersona persona)
        {
            _context = context;
            _destinatarios = _context.Set<Persona>();
            _personas = persona;
        }

        public async Task<Persona> BuscarPorCodigo(object id)
        {
            var destinatario = await _context.Personas.FromSqlRaw($@"SELECT * FROM [View_Destinatarios] WHERE [IdPersona] = {(int)id}").FirstOrDefaultAsync();
            if (destinatario != null)
            {
                return destinatario;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Persona>> BuscarPorParametro(Persona entitySearch)
        {

            var destinatario = await _context.Personas.FromSqlRaw($@"SELECT * FROM [View_Destinatarios] WHERE [Identificacion] LIKE '%{entitySearch.Identificacion}%' OR Nombre+Apellidos LIKE '%{entitySearch.Nombre}{entitySearch.Apellidos}%'").ToListAsync();
            if (destinatario != null)
            {
                return destinatario;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<Persona>> BuscarTodos()
        {
            return await _context.Personas.FromSqlRaw($@"SELECT * FROM [View_Destinatarios]").ToListAsync();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
