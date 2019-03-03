using SchoolApplication.DAL;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolApplication.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Title = "Gerenciamento de Usuarios";
            return View(UsuarioDAO.RetornarUsuarios());
        }

        public ActionResult CadastrarUsuario()
        {
            ViewBag.Title = "Cadastrar Usuario";
            ViewBag.Perfil = new SelectList(
                RoleDAO.RetornaRoles(), "RoleId", "RoleName");
            return View();
        }

        [HttpPost] //
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario(Usuario usuario,int? perfil)
        {
            ViewBag.Perfil = new SelectList(
                RoleDAO.RetornaRoles(), "RoleId", "RoleName");
            if (ModelState.IsValid)
            {
                if (perfil != null)
                {
                    usuario.Role = RoleDAO.BuscarRolePorId(perfil);
                    if (UsuarioDAO.CadastrarUsuario(usuario))
                    {
                        
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Esse Usuario ja está cadastrado");
                }else
                {
                    ModelState.AddModelError("", "Selecione um perfil para o usuario");
                }
            }

            return View(usuario);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, bool conectado)
        {

            if (UsuarioDAO.RelizarLongin(usuario) != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, conectado);
                return RedirectToAction("RedirectToDefault");


            }


            return View();
        }

        public ActionResult RedirectToDefault()
        {
            String[] roles = Roles.GetRolesForUser();
            if (roles.Contains("Adm"))
            {
                return RedirectToAction("Index", "Curso");
            }
            else if (roles.Contains("Aluno"))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}