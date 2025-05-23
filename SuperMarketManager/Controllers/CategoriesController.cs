﻿using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.Models;

namespace SuperMarketManager.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        public IActionResult Create()
        {
            var category = new Category();
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id ?? 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            CategoriesRepository.DeleteCategory(id ?? 0);
            return RedirectToAction("Index");
        }
    }
}
