using eCommerceWeb.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using eCommerceWeb.Models;
using eCommerceWeb.Controllers.Class;

namespace eCommerceWeb.Controllers
{

	
	public class ClienteController : Controller
    {
		// GET: Cliente
		//TODO: Desenvolver as pages de create, update de Cliente
		
		public ActionResult Index()
        {
			ViewBag.NaoExiste = true;
			return View();
        }
		[HttpPost]
		public ActionResult Index(FormCollection form)
		{
			string email = form["Email"];
			string senha = form["Senha"];

			using (var model = new ClienteModel())
			{
				Cliente cli = model.Read(email, senha);
				if (cli != null)
				{
					Session["Cliente"] = cli;
					return RedirectToAction("Index", "HomeLogin");
				}
				else
				{
					ViewBag.NaoExiste = true;
					return View();
				}
			}
		}
		public ActionResult Read()
		{
			using (ClienteModel model = new ClienteModel())    //Abre conexão
			{
				List<Cliente> lista = model.Read();              //Usa conexão
				ViewBag.lista = lista;
			} //==> model.Dispose();                               //Fecha conexão

			return View();
		}


		[HttpGet]
		public ActionResult Create()
		{
			using (var model = new ClienteModel())
				ViewBag.Cliente = model.Read();
			return View();
		}

		[HttpPost]
		public ActionResult Create(Cliente p)
		{
			using (var model = new ClienteModel())
			{
				model.Create(p);
			}

			return RedirectToAction("Index");
		}





		public ActionResult Delete(int id)
		{
			//Efetuar a exclusão da Categoria
			using (ClienteModel model = new ClienteModel())
				model.Delete(id);

			return RedirectToAction("Read");
		}

		
		
		//Update
		public ActionResult Update(int id)
		{
			using (ClienteModel model = new ClienteModel())
			{
				ViewBag.Cliente = model.Read(id);
				return View();
			}
		}

		[HttpPost]
		public ActionResult Update(FormCollection form)
		{

			string nome = form["Nome"]; // <input type="text" name="Nome" ...
			string email = form["Email"];
			string senha = form["Senha"];
			int id = int.Parse(form["ClienteID"]);


			Cliente c = new Cliente();
			c.Nome = nome;
			c.Email = email;
			c.Senha = senha;
			c.ClienteID = id;

			using (ClienteModel model = new ClienteModel())
			{
				model.Update(c);
			}

			return RedirectToAction("Read");
		}

	}
}