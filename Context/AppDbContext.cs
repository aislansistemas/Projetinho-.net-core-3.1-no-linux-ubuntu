using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using testelinux.Models;

namespace testelinux.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<teste> Testes { get; set; }
        public DbSet<Tarefa> Tarefas {get;set;}
    }
}