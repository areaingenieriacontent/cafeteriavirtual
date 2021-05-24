using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using AdministradorCafeteriaVirtual.Models;
using AdministradorCafeteriaVirtual.Models.ViewModels;

namespace AdministradorCafeteriaVirtual.Controllers
{

    [RoutePrefix("api/cafeteria")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServicioLoginController : ApiController
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();
        static string MD5PASS = "AreacAFEVIRTuaL";

        [HttpPost]
        [Route("loginattemp")]
        public CoffeShopUser LoginManager(string userName, string userPassword)
        {
            User user = cafeteriaDbContext.Users.Where(x => x.username == userName && x.password == userPassword).FirstOrDefault();
            CoffeShopUser userToReturn = new CoffeShopUser();
            if (user != null)
            {
                if (user.enable)
                {
                    userToReturn = new CoffeShopUser
                    {
                        loginStatus = 200,
                        firstName = user.name,
                        lastName = user.lastName,
                        userId = user.id
                    };
                    if (user.firstlog == null)
                    {
                        user.firstlog = DateTime.Now;
                    }
                    Login log = new Login
                    {
                        userid = user.id,
                        logDate = DateTime.Now,
                        ip = null,
                        city = null
                    };
                    cafeteriaDbContext.Logins.Add(log);
                    cafeteriaDbContext.SaveChanges();
                }
                else
                {
                    userToReturn.loginStatus = 110;
                }
            }
            else
            {
                userToReturn.loginStatus = 100;
            }
            
            return userToReturn;
        }

        [HttpGet]
        [Route("loginattemp2")]
        public CoffeShopUser LoginManagerGet(string userName, string userPassword)
        {
            User user = cafeteriaDbContext.Users.Where(x => x.username == userName && x.password == userPassword).FirstOrDefault();
            CoffeShopUser userToReturn = new CoffeShopUser();
            if (user != null)
            {
                if (user.enable)
                {
                    userToReturn = new CoffeShopUser
                    {
                        loginStatus = 200,
                        firstName = user.name,
                        lastName = user.lastName,
                        userId = user.id
                    };
                    if (user.firstlog == null)
                    {
                        user.firstlog = DateTime.Now;
                    }
                    Login log = new Login
                    {
                        userid = user.id,
                        logDate = DateTime.Now,
                        ip = null,
                        city = null
                    };
                    cafeteriaDbContext.Logins.Add(log);
                    cafeteriaDbContext.SaveChanges();
                }
                else
                {
                    userToReturn.loginStatus = 110;
                }
            }
            else
            {
                userToReturn.loginStatus = 100;
            }
            
            return userToReturn;
        }
    }
}