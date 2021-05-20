using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AdministradorCafeteriaVirtual.Models;
using System.Data.Entity;


namespace AdministradorCafeteriaVirtual.Controllers
{
    [RoutePrefix("api/cafeteria")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ServiciosCategoriaController : ApiController
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();
        [HttpGet]
        [Route("Categories")]
        public Category GetCategory(int id) {
            Category categoria = cafeteriaDbContext.Categories.Where(o => o.id == id).ToList()[0];
            return categoria;
        }
        [HttpPost]
        [Route("addCategory")]
        public void addategory(string image, string name, string descripcion)
        {
            Category newCategory = new Category();
            newCategory.description = descripcion;
            newCategory.image = image;
            newCategory.name = name;
            cafeteriaDbContext.Categories.Add(newCategory);
            cafeteriaDbContext.SaveChanges();
        }
        [HttpPost]
        [Route("RemoveCategory")]
        public void RemoveCategory(int id)
        {
            Category categoriaeliminar = GetCategory(id);
            cafeteriaDbContext.Categories.Remove(categoriaeliminar);
            cafeteriaDbContext.SaveChanges();
        }
        [HttpGet]
        [Route("AllCategories")]
        public List<Category> GetAllCategories() {
            List<Category> categorias = cafeteriaDbContext.Categories.Where(o => o.enable == true).ToList();
            return categorias;
        }
    }
}