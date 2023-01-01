using Gestao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioViewModel>> Get();
        Task<UsuarioViewModel> GetBtId(int? id);
        void Add(UsuarioViewModel usuario);
        void Update(UsuarioViewModel usuario);
        void Remove(int? id);
 
    }
}
