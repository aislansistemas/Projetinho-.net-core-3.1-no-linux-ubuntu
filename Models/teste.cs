using System.ComponentModel.DataAnnotations;

namespace testelinux.Models
{
    public class teste
    {
        public int Id {get;set;}
        [Required(ErrorMessage="Campo obrigatório*"),MinLength(5,ErrorMessage="Campo deve conter no minimo 5 caracteres")]
        public string Nome {get;set;}
    }
}