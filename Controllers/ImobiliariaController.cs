using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;

//video aula https://www.youtube.com/watch?v=aRoYqITZSHU

namespace WebApplication1.Controllers
{
    public class ImobiliariaController : Controller
    {
        public IActionResult PageHome()
        {
            return View();
        }

        public IActionResult PageCadastroFuncionario()
        {
            return View();
        }

        public IActionResult PageLogin()
        {
            return View();
        }

        public IActionResult PageAreaAdministrativa()
        {
            if (HttpContext.Session.GetString("nome") == null) {
				return View("PageLogin");
			}
			return View();
		}

        public IActionResult PageGerenciarFuncionario()
        {
			if (HttpContext.Session.GetString("nome") == null)
			{
				return View("PageLogin");
			}
			return View();
        }
        public IActionResult PageGerenciarImoveis()
        {
			if (HttpContext.Session.GetString("nome") == null)
			{
				return View("PageLogin");
			}
			return View();
        }     
    }
}
