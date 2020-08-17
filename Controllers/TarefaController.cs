using testelinux.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testelinux.Repository.Contracts;
using System.IO;
using testelinux.ViewModels;


namespace testelinux.Controllers
{
    public class TarefaController:Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            this._tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public IActionResult GetAllPendentes(){
            
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPendentesJson(){
            var tarefaViewModel = new TarefaPendenteViewModel(){
                ListaTarefas = _tarefaRepository.GetAllPendentes(),
                TotalTarefasPendentes = _tarefaRepository.GetAllPendentes().Count,
               
            };
            return Json(tarefaViewModel);
        }

        [HttpGet]
        public IActionResult Cadastrar(){
            return View();
        }

        [HttpPost,ActionName("Cadastrar")]
        public IActionResult CreateConfirm(Tarefa tarefa){
            if(ModelState.IsValid){
                _tarefaRepository.Insert(tarefa);
                return RedirectToAction(nameof(GetAllPendentes));
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAllConcluidas(){
            var tarefaViewModel = new TarefaConcluidaViewModel(){
                ListaTarefas = _tarefaRepository.GetAllConcluidas(),
                ToTalTarefasConcluidas = _tarefaRepository.GetAllConcluidas().Count
            };
            return View(tarefaViewModel);
        }

        [HttpGet]
        public IActionResult ConcluirTarefa(int id){
            var tarefaResult = _tarefaRepository.getByid(id);
            if(tarefaResult == null){
                ViewBag.Error = "Id não encontrado";
                return RedirectToAction(nameof(GetAllPendentes));
            }else{
                _tarefaRepository.ConcluirTarefa(tarefaResult);
                return RedirectToAction(nameof(GetAllConcluidas));
            }
        }

        [HttpPost]
        public IActionResult EditarTarefa(Tarefa tarefa){
            var tarefaResult = _tarefaRepository.getByid(tarefa.Id);
            if(tarefaResult == null){
                ViewBag.Error = "Id não encontrado";
                return RedirectToAction(nameof(GetAllPendentes));
            }else{
                _tarefaRepository.Update(tarefaResult);
                ViewBag.Sucess = "Tarefa atualizada com sucesso";
                return RedirectToAction(nameof(GetAllPendentes));  
            }
            
        }

    }
    
}