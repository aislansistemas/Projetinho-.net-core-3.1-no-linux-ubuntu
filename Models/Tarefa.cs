using System;
using System.ComponentModel.DataAnnotations;

namespace testelinux.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string NomeTarefa { get; set; }
        public StatusTarefa Status {get;set;}
        public DateTime Data { get; set; }
    }
}