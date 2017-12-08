using SocialCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SocialCode.ViewModels;
using SocialCode.Tipo_Conta;
using System.Web.Services.Description;

namespace SocialCode.Controllers
{
    public class HomeController : Controller
    {


        private RedeSocialEntities _context;

        public HomeController()
        {
            _context = new RedeSocialEntities();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Registrar()
        {
            var viewModel = new RegisterViewModel();
            return PartialView("_Registrar", viewModel);
        }

        [HttpPost]
        public PartialViewResult Registrar(RegisterViewModel viewModel)
        {
            try {
            if (ModelState.IsValid)
            {
                var model = new Usuario()
                    {
                        nome = viewModel.Nome,
                        senha = viewModel.Senha,
                        email = viewModel.Email,
                        dt_nascimento = viewModel.dtnascimento,
                        tipo_conta = (int)Tipo_Conta.Tipo.Normal,
                        dt_cadastro = DateTime.Now,
                        ativo = true
                    };
                _context.Usuario.Add(model);
                _context.SaveChanges();

                ModelState.Clear();
                viewModel = null;
            }
            }

            catch (System.TypeInitializationException)
                {
                    Console.WriteLine("");

                }
            catch (System.Data.Entity.Core.EntityException)
                {
                    Console.WriteLine("Conecte-se ao servidor ");

                }
            return PartialView("_Registrar", viewModel);
            }
            
        }



    }


