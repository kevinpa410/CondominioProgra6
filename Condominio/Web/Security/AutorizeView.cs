using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Web.Security
{
    public class AutorizeView
    {
        public static bool IsUserInRole(string[] nombreRoles)
        {
            // Ensure that only valid role names are used
            var validRoles = new[] { "Administrador", "Residente" };
            var rolesToCheck = nombreRoles.Intersect(validRoles);

            // Convert valid roles to enum values
            IEnumerable<Rols> allowedroles = rolesToCheck
                .Select(a => (Rols)Enum.Parse(typeof(Rols), a));

            bool authorize = false;
            var oUsuario = (Usuario)HttpContext.Current.Session["User"];
            if (oUsuario != null)
            {
                foreach (var rol in allowedroles)
                {
                    if ((int)rol == oUsuario.IDRol)
                        return true;
                }
            }
            return authorize;
        }
    }
}