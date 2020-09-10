using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testelinux.Models;

namespace testelinux.Context
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        /*public DbSet<teste> Testes { get; set; }*/
        public DbSet<Tarefa> Tarefas {get;set;}
    }
}