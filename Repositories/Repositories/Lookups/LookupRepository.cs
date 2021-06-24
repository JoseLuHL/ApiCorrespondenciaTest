using Contracts.lookups;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Looks
{
    public class LookupRepository : ILookup
    {
        public Task Actualizar(Lookup entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<Lookup> BuscarPorCodigo(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lookup>> BuscarPorParametro(Lookup entitySearch)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lookup>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(Lookup entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task EliminarPorCodigo(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insertar(Lookup entityToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
