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
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome do usuário")]
        public string? Name { get; set; }
        public int Id { get; set; }
    }
}
