using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.General
{
    public interface IGeneralPersonas<TModel> : IDisposable where TModel : class
    {
        public Task<IEnumerable<TModel>> BuscarTodos();
        public Task<IEnumerable<TModel>> BuscarPorParametro(TModel entitySearch);
        public Task<TModel> BuscarPorCodigo(object id);
    }
}
