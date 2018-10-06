using eCommerceWeb.Controllers.Class;
using eCommerceWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using eCommerceWeb.Models.Entities;

namespace eCommerceWeb.Controllers
{
	[Authorized]
    public class CategoriaController : Controller
    {
        // GET: Categoria

        //Read
        public ActionResult Read()
        {
            using (CategoriaModel model = new CategoriaModel())    //Abre conexão
            {
                List<Categoria> lista = model.Read();              //Usa conexão
                ViewBag.lista = lista;
            } //==> model.Dispose();                               //Fecha conexão

            return View();
        }

        //Delete
        public ActionResult Delete(int id)
        {
            //Efetuar a exclusão da Categoria
            using (CategoriaModel model = new CategoriaModel())
                model.Delete(id);
                
                return RedirectToAction("Read");
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            string nome = form["Nome"]; // <input type="text" name="Nome" ...


            Categoria c = new Categoria();
            c.Nome = nome;


            using (CategoriaModel model = new CategoriaModel())
            {
                model.Create(c);
            }

            return RedirectToAction("Read");
        }


        //Update
        public ActionResult Update(int id)
        {
            using (CategoriaModel model = new CategoriaModel())
            {
                ViewBag.categoria = model.Read(id);
                return View();
            }               
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            
            string nome = form["Nome"]; // <input type="text" name="Nome" ...
            int id = int.Parse(form["CategoriaId"]);


            Categoria c = new Categoria();
            c.Nome = nome;
            c.CategoriaId = id;

            using (CategoriaModel model = new CategoriaModel())
            {
                model.Update(c);
            }

            return RedirectToAction("Read");
        }
    }
}