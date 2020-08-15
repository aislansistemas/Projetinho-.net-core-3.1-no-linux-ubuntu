using System;
using System.ComponentModel.DataAnnotations;

namespace testelinux.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        [Required(ErrorMessage="Campo obrigatório*"),MinLength(5,ErrorMessage="Campo deve conter no minimo 5 caracteres")]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
