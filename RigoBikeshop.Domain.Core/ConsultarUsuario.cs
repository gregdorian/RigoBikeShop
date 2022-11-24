using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Entities;
using Infrastructure.Data;

namespace RigoBikeshop.Domain.Core
{
    public static class ConsultarUsuario
    {
        public static bool LoginUsuario(string usr, string pass)
        {
            DataTable dtUser = UserPersistence.GetAllUsuarios();

            var exist = dtUser.Select("NombreUsuario = '" + usr + "' and Clave = '" + pass + "'");

            if (dtUser != null && exist.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
