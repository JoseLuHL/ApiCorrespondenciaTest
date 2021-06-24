using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGenericService<TModel> : IDisposable where TModel : class
    {
        Task<IEnumerable<TModel>> BuscarTodos();
        Task<IEnumerable<TModel>> BuscarPorParametro(TModel entitySearch);
        Task<TModel> BuscarPorCodigo(object id);
        Task Insertar(TModel entityToInsert);
        Task EliminarPorCodigo(object id);
        Task Eliminar(TModel entityToDelete);
        Task Actualizar(TModel entityToUpdate);
    }
}
