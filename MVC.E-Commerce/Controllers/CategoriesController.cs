﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.E_Commerce.Models;

namespace MVC.E_Commerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext Context;

        public CategoriesController(ApplicationContext _context)
        {
            Context = _context;
        }
        public IActionResult Index()
        {
            List<Category> AllCategories = Context.Categories.Include(p => p.Products).ToList();
            return View(AllCategories); ;
        }
        public IActionResult Details(int id)
        {
            Category CurrentCategory = Context.Categories.Include(p => p.Products).Where(x => x.Id == id).FirstOrDefault();
            return View(CurrentCategory);

        }
    }
}
