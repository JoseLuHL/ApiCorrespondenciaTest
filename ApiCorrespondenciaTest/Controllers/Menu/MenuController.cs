using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Repositories.Filtrar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiCorrespondenciaTest.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MenuController : ControllerBase
    {
        private IMenu _menu;
        public MenuController(IMenu menu)
        {
            _menu = menu;
        }

        [HttpGet]
        public async Task<IEnumerable<FMenuPadreVo>> Get(int filterMenu)
        {
            return await _menu.ObtenerMenu(filterMenu);
        }


    }
}
