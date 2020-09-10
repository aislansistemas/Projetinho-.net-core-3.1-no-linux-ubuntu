using System.ComponentModel.DataAnnotations;

namespace testelinux.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Campo Requerido")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Campo Requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}