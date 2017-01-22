using MVCBiblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Controllers
{
    public class RolesController : Controller
    {
        public string Create()
        {
            IdentityManager im = new IdentityManager();

            //im.DeleteRole("Administrator");
            //im.DeleteRole("Czytelnik");
            //im.DeleteRole("Pracownik");

            im.CreateRole("Administrator");
            im.CreateRole("Czytelnik");
            im.CreateRole("Pracownik");

            return "ok";
        }

        public string AddToRole()
        {
            IdentityManager im = new IdentityManager();

            im.AddUserToRoleByUsername("j.kowalski@gmail.com", "Administrator");

            return "OK";
        }
    }
}