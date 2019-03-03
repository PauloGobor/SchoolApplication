using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Perfil";
            return View(RoleDAO.RetornaRoles());
        }

        public ActionResult CadastrarPerfil()
        {
            ViewBag.Title = "Cadastrar Perfil";
            return View();
        }

        [HttpPost] //
        public ActionResult CadastrarPerfil(Role role)
        {
            if (ModelState.IsValid)
            {
                if (RoleDAO.CadastrarRole(role))
                {
                    return RedirectToAction("Index", "Perfil");
                }
                ModelState.AddModelError("", "Essa Perfil ja esta cadastrada");

            }

            return View(role);

        }
    }
}