using SocialCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SocialCode.ViewModels;

namespace SocialCode.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {

        private RedeSocialEntities _context;
        public PerfilController()
        {
            _context = new RedeSocialEntities();
        }

        // GET: Perfil
        [Authorize]
        public ActionResult Index()
        {

            var usuario = _context.Usuario.Include("Sexo1").FirstOrDefault(x => x.email.Equals(User.Identity.Name));

            return View(usuario);
        }


        public ActionResult Editar(RegisterViewModel Email)
        {

            var model = _context.Usuario.Include("Sexo1").FirstOrDefault(x => x.email.Equals(User.Identity.Name));
            {
                var viewModel = new RegisterViewModel
                {
                    Nome = model.nome,
                    Sexo = model.Sexo1.id_sexo,
                    Interesses = model.interesses
                };

                return View("Index");
            }
        }
    }
}
