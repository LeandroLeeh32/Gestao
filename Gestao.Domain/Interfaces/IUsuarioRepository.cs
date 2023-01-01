using Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> GetBtId(int? id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(int? id);
    }
}
