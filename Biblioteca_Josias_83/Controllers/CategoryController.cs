using System;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public IActionResult IndexCategorias()
        {
            var result = _categoryServices.GetCategories();
            return View(result);
        }
        [HttpGet]
        public IActionResult CrearCategoria()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearCategoria(Categoria request)
        {
            _categoryServices.CreateCategory(request);

            return RedirectToAction("IndexCategorias");
        }

        [HttpGet]
        public IActionResult EditarCategoria(int id)
        {
            var categoria = _categoryServices.GetCategory(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EditarCategoria(Categoria request)
        {
            bool isUpdated = _categoryServices.UpdateCategory(request);
            if (isUpdated)
            {
                return RedirectToAction("IndexCategorias");
            }
            return View(request);
        }



        [HttpDelete]
        public IActionResult EliminarCategoria(int id)
        {
            bool result = _categoryServices.DeleteCategory(id);
            if (result == true)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}

