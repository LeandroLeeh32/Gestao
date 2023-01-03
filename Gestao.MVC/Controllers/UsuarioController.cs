using Gestao.Application.Interfaces;
using Gestao.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _usuarioService.Get();
            return View(result.OrderByDescending(x => x.Name));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var UsuarioVM = await _usuarioService.GetBtId(id);

            if (UsuarioVM == null) return NotFound();
            return View(UsuarioVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id,Name")] UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioService.Update(usuario);
                }
                catch (System.Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return NotFound(); 
     
            var usuario = await _usuarioService.GetBtId(Id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
                return NotFound();
            

            var usuario = await _usuarioService.GetBtId(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost(),ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _usuarioService.Remove(id);
            return RedirectToAction("Index");
        }




    }
}
