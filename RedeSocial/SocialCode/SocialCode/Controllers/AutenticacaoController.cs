using SocialCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialCode.Models;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace SocialCode.Controllers
{
    public class AutenticacaoController : Controller
    {

        private RedeSocialEntities _context;

        public AutenticacaoController()
        {
            _context = new RedeSocialEntities();
        }

        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar()
        {
            return View("_Logar");
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var oUsuario = _context.Usuario.FirstOrDefault(x => x.email.Equals(viewModel.Email) && x.senha.Equals(viewModel.Senha) && x.ativo.Value.Equals(true));

                if (oUsuario != null)
                {
                    FormsAuthentication.SetAuthCookie(oUsuario.email, true);
                    return RedirectToAction("Index", "Perfil");
                }
                else
                {        
                    return View("Logar");
                }
            }

            return View("Logar");

    }
        [Authorize]
        public ActionResult Logout(LoginViewModel viewModel)
        {
           
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");

        }


  }
}