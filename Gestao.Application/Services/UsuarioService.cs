using AutoMapper;
using Gestao.Application.Interfaces;
using Gestao.Application.ViewModels;
using Gestao.Domain.Entities;
using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly IMapper _mapper;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        void IUsuarioService.Add(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Add(mapUsuario);
        }

        async Task<IEnumerable<UsuarioViewModel>> IUsuarioService.Get()
        {
            var result = await _usuarioRepository.Get();
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(result);
        }

        async Task<UsuarioViewModel> IUsuarioService.GetBtId(int? id)
        {
            var result = await _usuarioRepository.GetBtId(id);
            return _mapper.Map<UsuarioViewModel>(result);
        }

        void IUsuarioService.Remove(int? id)
        {
            var result = _usuarioRepository.GetBtId(id).Result;
            _usuarioRepository.Remove(result.Id);
        }

        void IUsuarioService.Update(UsuarioViewModel usuario)
        {
            var mapUsuario = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Update(mapUsuario);
        }
    }
}
