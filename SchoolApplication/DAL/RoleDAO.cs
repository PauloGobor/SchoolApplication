using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.DAL
{
    public class RoleDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarRole(Role role)
        {
            if (BuscarRolePorNome(role) == null)
            {
                ctx.Roles.Add(role);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<Role> RetornaRoles()
        {
            return ctx.Roles.ToList();
        }

        public static Role BuscarRolePorNome(Role role)
        {
      
            return ctx.Roles.FirstOrDefault(x => x.RoleName.Equals(role.RoleName));
        }

        public static Role BuscarRolePorId(int? id)
        {
            return ctx.Roles.Find(id);
        }
    }
}