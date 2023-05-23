using Lumia.DAL;
using Lumia.Models;
using Lumia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public HomeController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async  Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                slider = await _context.Sliders.FirstOrDefaultAsync(),
                client = await _context.Clients.Include(x => x.profession).ToListAsync(),
                crud= await _context.Cruds.ToListAsync(),
                whatWeDos = await _context.WhatWeDos.ToListAsync(),
                profession = await _context.Professions.ToListAsync(),
            };
            return View(vm);
        }
    }
}