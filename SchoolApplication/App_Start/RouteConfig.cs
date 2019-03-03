using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolApplication
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // criar um layout especificio paara cada pagina
            // onde o administrador é redirecionado para a parte de gerenciamento
            // onde o aluno é redirecionado para a home index... onde ele é redirecionado para escolher
            // o curso a ser matriculado .....
            //cadastrar no metodo seed... um adminitrador, usuario admin: admin
            // disponibilizar recurso da api, cursos, e matriculas,
            // aluno virar usuario e ter um tipo administrador ou aluno


            // fazer meus cursos ... para ele ver os cursos cadastrados

            // arrumar container curso index
            // 

        }
    }
}
