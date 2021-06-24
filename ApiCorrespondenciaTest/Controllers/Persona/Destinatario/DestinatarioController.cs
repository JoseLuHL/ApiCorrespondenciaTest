using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiCorrespondenciaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DestinatarioController : ControllerBase
    {
        private IPersona _persona;
        private IDestinatario _destinatario;
        public DestinatarioController(IPersona persona, IDestinatario destinatario)
        {
            _persona = persona;
            _destinatario = destinatario;
        }
        [HttpGet]
        public async Task<IEnumerable<Models.Models.Persona>> Get()
        {
            return await _destinatario.BuscarTodos();
        }

        [HttpGet("{id}")]
        public async Task<Models.Models.Persona> Get(int id)
        {
            return await _destinatario.BuscarPorCodigo(id);
        }
    }
}
