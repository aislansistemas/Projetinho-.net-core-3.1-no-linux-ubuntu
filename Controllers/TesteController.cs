using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testelinux.Context;
using testelinux.Models;

namespace testelinux.Controllers
{
    public class TesteController : Controller
    {       
        private readonly AppDbContext _context;
        public TesteController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index(){
           // var listaTestes = _context.Testes.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar(){
            return View();
        }

        [HttpPost,ActionName("Cadastrar")]
        public IActionResult CadastrarConfirm(teste teste){
            if(ModelState.IsValid){
            _context.Add(teste);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            }else{
                return View();
            }
        }

        [HttpGet]
        public IActionResult Lista(){
            return Json(_context.Testes.ToList());
        }

        [HttpPost,ActionName("Deletar")]
        public IActionResult Deletar(int id){
            var teste = _context.Testes.FirstOrDefault(x => x.Id == id);
            _context.Remove(teste);
            _context.SaveChanges();
            return Json("Usuario(a) "+teste.Nome+" deletado com sucesso");
        }

    }
}
