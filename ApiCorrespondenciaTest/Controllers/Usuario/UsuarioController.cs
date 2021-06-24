using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Repositories.Filtrar;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCorrespondenciaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuario;
        private readonly IConfiguration configuration;
        public UsuarioController(IConfiguration configuration, IUsuario usuario)
        {
            this.configuration = configuration;
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterLogin modelUsuario)
        {
            if (string.IsNullOrEmpty(modelUsuario.Login) && string.IsNullOrEmpty(modelUsuario.Password))
            {
                return NotFound();
            }

            var parUsuario = new Usuario { Login = modelUsuario.Login, Password = modelUsuario.Password };
            var usuario = await _usuario.BuscarPorParametro(parUsuario);
            if (usuario != null && usuario.Count() > 0)
            {
                var token = new { token = GenerarTokenJWT(parUsuario), perfil = usuario.First().IdPerfil };
                return Ok(token);
            }
            else
            {
                var token = new { token = "", perfil = 0 };
                return NotFound(token);
            }
        }


        private string GenerarTokenJWT(Usuario parUsuarioInfo)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _Header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, parUsuarioInfo.IdUsuario.ToString()),
                new Claim("perfil", parUsuarioInfo.IdPerfil.ToString()),
                new Claim("usuario_key", parUsuarioInfo.Login.ToString()),
                new Claim("estado_key", parUsuarioInfo.IdEstado.ToString())};

            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(24)
                );

            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }


    }
}
