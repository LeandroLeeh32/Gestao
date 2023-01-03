using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatório")]
        [MinLength(10, ErrorMessage = "Informar um nome maior que 10 caracteres.")]
        [MaxLength(60, ErrorMessage = "Informar um nome menor que 60 caracteres.")]
        [DisplayName("Nome do usuário")]
        public string? Name { get; set; }
        public int Id { get; set; }
    }
}
