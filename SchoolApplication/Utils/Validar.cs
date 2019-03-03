using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.Utils
{
    public class Validar
    {

        public static bool QuantidadeCurso(Curso curso)
        {

            if (curso.QtdVagas >=1)
            {
                curso.QtdVagas -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}