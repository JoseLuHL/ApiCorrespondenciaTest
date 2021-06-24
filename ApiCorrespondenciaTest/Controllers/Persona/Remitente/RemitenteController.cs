using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCorrespondenciaTest.Controllers.Persona.Remitente
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RemitenteController : ControllerBase
    {
        private IPersona _persona;
        private IRemitente  _remitente;
        public RemitenteController(IPersona persona, IRemitente destinatario)
        {
            _persona = persona;
            _remitente = destinatario;
        }
        [HttpGet]
        public async Task<IEnumerable<Models.Models.Persona>> Get()
        {
            return await _remitente.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<Models.Models.Persona> Get(int id)
        {
            return await _remitente.BuscarPorCodigo(id);
        }

    }
}
