using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministradorCafeteriaVirtual.Models.ViewModels
{
    public class CoffeShopUser
    {
        public int loginStatus { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int userId { get; set; }
    }
}