using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Net5.Rest.Infrastructure.CrossCutting.Dtos;
using Net52.Rest.API.Construction.Contexts;
using Net52.Rest.API.Construction.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Net52.Rest.API.Controllers
{

    public class AlumnoController : Controller
    {
        private readonly ProyalumnoContext _Context;
        private readonly ILogger<AlumnoController> _logger;
        // GET: AlumnoController
        public AlumnoController(ProyalumnoContext Contexto, ILogger<AlumnoController> logger)
        {
            _Context = Contexto;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var ListaAlumnos = await _Context.People.ToListAsync();
            _logger.LogWarning("Este es un mensaje de exito de lista");
            return View(ListaAlumnos);
            //return View();
        }

        // GET: AlumnoController/Details/5
        
        public async Task<ActionResult> Details(int id)
        {
            var ListaAlumnos = await _Context.People.Where(C => C.PersonId == id).FirstOrDefaultAsync();
            if (ListaAlumnos == null) {
                _logger.LogWarning("Este es un mensaje de error");
                return BadRequest("ERROR ALUMNO NO ENCONTRADO");
            }
            return View(ListaAlumnos);
        }


        // GET: Persona/Create


        public IActionResult Create()
        {
            return View();
        }

        // POST: AlumnoController/Create
        [HttpPost]

        public async Task<ActionResult> Create([Bind("LastName,FirstName,Discriminator")] PersonaDto P)
        {
            try
            {
                var person=new Person
                {
                    FirstName = P.FirstName,
                    LastName = P.LastName,
                    Discriminator = P.Discriminator,
                    EnrollmentDate = System.DateTime.Today
                };

                await _Context.People.AddAsync(person);
                var Result = await _Context.SaveChangesAsync();
                _logger.LogWarning("Usuario creado correctamente: " + P.FirstName + " " + P.LastName);
                return View(person);

            }
            catch
            {
                return BadRequest("ERROR ALUMNO NO ENCONTRADO");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _Context.People.FirstOrDefaultAsync(a => a.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        // POST: AlumnoController/Edit/5

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind("LastName,FirstName")] PersonDtoForUpdate P)
        {
            try
            {

                Person Perso = await _Context.People.FirstOrDefaultAsync(a => a.PersonId == id);
                if (Perso is null)
                {
                    return BadRequest("Error, Alumno no encontrado");
                }
                Perso.FirstName = P.FirstName??Perso.FirstName;
                Perso.LastName = P.LastName ?? Perso.LastName;
                _Context.People.Update(Perso);
                await _Context.SaveChangesAsync();
                _logger.LogWarning("Usuario editado correctamente: " + P.FirstName + " " + P.LastName);
                return View(Perso);

            }
            catch (System.Exception e)
            {
                return BadRequest("ERROR, Algo salio mal: "+e);
            }    
           
        }
        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _Context.People
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: AlumnoController/Delete/5

       [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var ListaAlumnos = await _Context.People.Where(C => C.PersonId == id).FirstOrDefaultAsync();
                 _Context.People.Remove(ListaAlumnos);
                var result = await _Context.SaveChangesAsync();

                _logger.LogWarning("Usuario eliminado correctamente");
                //return Ok("Se elimino la persona" + ListaAlumnos.FirstName + ListaAlumnos.LastName);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogWarning("Error al borrar usuario");
                return BadRequest("Error, No se pudo eliminar" );
            }
        }
    }
}
