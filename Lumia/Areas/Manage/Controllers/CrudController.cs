using Lumia.DAL;
using Lumia.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lumia.DAL;
using Lumia.Models;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CrudController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CrudController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var procedur = await _context.Cruds.ToListAsync();
            return View(procedur);
        }



        //--------------------------------------------CREATE-------------------------------------------------//


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Crud Crud)
        {
            if (!ModelState.IsValid) return View(Crud);

            await _context.Cruds.AddAsync(Crud);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        //----------------------------------------------EDIT-------------------------------------------------//


        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Cruds.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Crud Crud)
        {
            Crud? exists = await _context.Cruds.FirstOrDefaultAsync(x => x.Id == Crud.Id);

            if (exists == null)
            {
                ModelState.AddModelError("", "Crud not found");
                return View(Crud);
            }

            

            exists.Title = Crud.Title;
            exists.Description = Crud.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //---------------------------------------------DELETE-------------------------------------------//



        public async Task<IActionResult> Delete(int id)
        {
            Crud? exist = await _context.Cruds.FirstOrDefaultAsync(x => x.Id == id);
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Cruds.Remove(exist);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}
