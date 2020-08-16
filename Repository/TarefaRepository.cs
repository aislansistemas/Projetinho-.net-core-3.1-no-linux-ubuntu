using System.Collections.Generic;
using testelinux.Models;
using System;
using testelinux.Repository.Contracts;
using testelinux.Context;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace testelinux.Repository
{
    public class TarefaRepository : ITarefaRepository
    {   
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context)
        {
            this._context = context;
        }

        public List<Tarefa> GetAllConcluidas()
        {
            return _context.Tarefas.Where(x =>x.Status == "concluida").OrderByDescending(x => x.Id).ToList();
        }

        public List<Tarefa> GetAllPendentes()
        {
            return _context.Tarefas.Where(x =>x.Status == "pendente").OrderByDescending(x => x.Id).ToList();
        }

        public Tarefa getByid(int id)
        {
        
            return _context.Tarefas.FirstOrDefault(x => x.Id == id);
        
        }

        public void Insert(Tarefa tarefa)
        {   
            var tarefaBd = tarefa;
            tarefaBd.DataCadastrada = DateTime.Now;
            tarefaBd.Status = "pendente";

             _context.Tarefas.Add(tarefa);
             _context.SaveChanges();
        }

        public void ConcluirTarefa(Tarefa tarefa)
        {  
            tarefa.Status = "concluida";
            tarefa.DataConcluida = DateTime.Now;
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }

    }
}