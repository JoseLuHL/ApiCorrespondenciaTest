using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCorrespondenciaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CorrespondenciaController : ControllerBase
    {
        private ICorrespondencia _correspondencia;
        public CorrespondenciaController(ICorrespondencia correspondencia)
        {
            _correspondencia = correspondencia;
        }

        [HttpGet]
        public async Task<IEnumerable<Correspondencia>> Index()
        {
            return await _correspondencia.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<Correspondencia> Get(int id)
        {
            return await _correspondencia.BuscarPorCodigo(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Correspondencia parDatos)
        {
            await _correspondencia.Insertar(parDatos);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody] Correspondencia parDatos)
        {
            await _correspondencia.Actualizar(parDatos);
        }

        // DELETE api/<CorrespondenciaController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _correspondencia.EliminarPorCodigo(id);
        }
    }
}
