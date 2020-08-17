using System.Collections.Generic;
using System.Threading.Tasks;
using testelinux.Models;
namespace testelinux.Repository.Contracts
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllPendentes();
        Task<List<Tarefa>> GetAllConcluidas();
        Task Insert(Tarefa tarefa);
        Task ConcluirTarefa(Tarefa tarefa);
        Task<Tarefa> getByid(int id);

        Task Update(Tarefa tarefa);

        int TotalPendentes();

        int TotalConcluidas();
    }
}