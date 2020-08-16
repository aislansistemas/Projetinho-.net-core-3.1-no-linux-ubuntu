using testelinux.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testelinux.Repository.Contracts;
using iTextSharp.text.pdf;
using iTextSharp;
using iTextSharp.text;

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
            var tarefaViewModel = new TarefaPendenteViewModel(){
                ListaTarefas = _tarefaRepository.GetAllPendentes(),
                TotalTarefasPendentes = _tarefaRepository.GetAllPendentes().Count,
               
            };
            return View(tarefaViewModel);
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

    }
    
}