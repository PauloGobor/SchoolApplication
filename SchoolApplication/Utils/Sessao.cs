
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.Utils
{
    public class Sessao
    {
        private static string INSCRICAO_ID = "InscricaoId";

        public static string RetornarInscricaoId()
        {
            if (HttpContext.Current.Session[INSCRICAO_ID] == null)
            {
                HttpContext.Current.Session[INSCRICAO_ID] = Guid.NewGuid();
            }
            return HttpContext.Current.Session[INSCRICAO_ID].ToString();
        }

    }
}