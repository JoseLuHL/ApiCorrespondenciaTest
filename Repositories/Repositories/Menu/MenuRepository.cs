using Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class MenuRepository : IMenu
    {
        private ApiCorrespondenciaTest_dbContext _context;
        private DbSet<Modulo> _menu;
        public MenuRepository(ApiCorrespondenciaTest_dbContext context)
        {
            _context = context;
            _menu = _context.Set<Modulo>();
        }

        public async Task<IEnumerable<FMenuPadreVo>> ObtenerMenu(int Perfil)
        {
            var padre = _context.MenuPadre.FromSqlRaw("exec dbo.PRC_CONS_MENU_PADRE {0}", Perfil).ToList();
            padre.ForEach( s =>
            {
                var hijo = ObtenerMenuHijo(Perfil,1);
                s.submenu = hijo;
            });
            return padre;
            //return await _menu.Include(s=>s.OpcionModulos).ToListAsync();
        }

        private  List<FMenuHijoVo> ObtenerMenuHijo(int par_Perfil, int par_Modulo)
        {
            var spParams = new object[] { par_Perfil, par_Modulo };
            var hijo = _context.MenuHijo.FromSqlRaw("exec dbo.PRC_CONS_MENU_HIJO {0} , {1}", spParams).ToList();
            return hijo;
        }



    }
}
