using testelinux.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testelinux.Repository.Contracts;
using System.IO;
using testelinux.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAllPendentesJson(){

            var tarefaViewModel = new TarefaPendenteViewModel(){
                ListaTarefas = await _tarefaRepository.GetAllPendentes(),
                TotalTarefasPendentes = _tarefaRepository.TotalPendentes() 
            };
            return Json(tarefaViewModel);
        }

        
        [HttpGet]
        [Authorize(Roles="admin")]
        public IActionResult Cadastrar(){
            return View();
        }

        [HttpPost,ActionName("Cadastrar")]
        public async Task<IActionResult> CreateConfirm(Tarefa tarefa){
            if(ModelState.IsValid){
                await _tarefaRepository.Insert(tarefa);
                return Json("sucesso");
            }
        
            return Json("erro");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConcluidas(){
            
            var tarefaViewModel = new TarefaConcluidaViewModel(){
                ListaTarefas = await _tarefaRepository.GetAllConcluidas(),
                ToTalTarefasConcluidas = _tarefaRepository.TotalConcluidas()
            };
            return View(tarefaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ConcluirTarefa(int id){
            var tarefaResult = await _tarefaRepository.getByid(id);
            if(tarefaResult == null){
                ViewBag.Error = "Id não encontrado";
                return RedirectToAction(nameof(GetAllPendentes));
            }else{
                await _tarefaRepository.ConcluirTarefa(tarefaResult);
                return RedirectToAction(nameof(GetAllConcluidas));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarefa(Tarefa tarefa){
            var tarefaResult = await _tarefaRepository.getByid(tarefa.Id);
            if(tarefaResult == null){
                ViewBag.Error = "Id não encontrado";
                return RedirectToAction(nameof(GetAllPendentes));
            }else{
                await _tarefaRepository.Update(tarefaResult);
                ViewBag.Sucess = "Tarefa atualizada com sucesso";
                return RedirectToAction(nameof(GetAllPendentes));  
            }
            
        }

    }
    
}