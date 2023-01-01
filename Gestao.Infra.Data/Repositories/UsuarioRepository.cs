using Gestao.Domain.Entities;
using Gestao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Infra.Data.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        void IUsuarioRepository.Add(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        async Task<IEnumerable<Usuario>> IUsuarioRepository.Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        async Task<Usuario> IUsuarioRepository.GetBtId(int? id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        void IUsuarioRepository.Remove(int? id)
        {
            var result = _context.Usuarios.FindAsync(id);
            _context.Remove(result);
        }

        void IUsuarioRepository.Update(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}
