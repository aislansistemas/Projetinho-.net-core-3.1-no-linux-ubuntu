using System.Collections.Generic;
using testelinux.Models;
using System;
using testelinux.Repository.Contracts;
using testelinux.Context;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testelinux.Repository
{
    public class TarefaRepository : ITarefaRepository
    {   
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Tarefa>> GetAllConcluidas()
        {
            return await _context.Tarefas.AsNoTracking().Where(x =>x.Status == "concluida").OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<List<Tarefa>> GetAllPendentes()
        {
            return await _context.Tarefas.AsNoTracking().Where(x =>x.Status == "pendente").OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Tarefa> getByid(int id)
        {
        
            return await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        
        }

        public async Task Insert(Tarefa tarefa)
        {   
            var tarefaBd = tarefa;
            tarefaBd.DataCadastrada = DateTime.Now;
            tarefaBd.Status = "pendente";

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task ConcluirTarefa(Tarefa tarefa)
        {  
            tarefa.Status = "concluida";
            tarefa.DataConcluida = DateTime.Now;
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public int TotalPendentes(){
            return _context.Tarefas.AsNoTracking().Count(x =>x.Status == "pendente");
        }

        public int TotalConcluidas(){
            return _context.Tarefas.AsNoTracking().Count(x =>x.Status == "concluida");
        }
    }
}