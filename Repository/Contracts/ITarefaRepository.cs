using System.Collections.Generic;
using testelinux.Models;
namespace testelinux.Repository.Contracts
{
    public interface ITarefaRepository
    {
        List<Tarefa> GetAllPendentes();
        List<Tarefa> GetAllConcluidas();
        void Insert(Tarefa tarefa);
        void ConcluirTarefa(Tarefa tarefa);
        Tarefa getByid(int id);
    }
}