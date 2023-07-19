using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteEmprestimos.Data;
using SiteEmprestimos.Models;

namespace SiteEmprestimos.Controllers
{
    public class EmprestimoController : Controller
    {
		private readonly ApplicationDbContext _db;
		public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
			IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimo;
            
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimo.Add(emprestimos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";

                return RedirectToAction("Index");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);  

            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo) 
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Update(emprestimo);
                _db.SaveChanges();

				TempData["MensagemSucesso"] = "Edição realizada com sucesso";

				return RedirectToAction("Index");
			}

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id) 
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}

            EmprestimosModel emprestimo = _db.Emprestimo.FirstOrDefault(emp => emp.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }

			return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if(emprestimo == null) 
            { 
                return NotFound(); 
            } 

            _db.Emprestimo.Remove(emprestimo);
            _db.SaveChanges();

			TempData["MensagemSucesso"] = "Remoção realizada com sucesso";

			return RedirectToAction("Index");
        }
	}
}
