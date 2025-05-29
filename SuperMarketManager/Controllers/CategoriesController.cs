using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        private readonly IEditCategoryUseCase _editCategoryUseCase;
        private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;

        public CategoriesController(
            ICategoryRepository categoryRepository,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IAddCategoryUseCase addCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            _categoryRepository = categoryRepository;
            _viewCategoriesUseCase = viewCategoriesUseCase;
            _viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            _addCategoryUseCase = addCategoryUseCase;
            _editCategoryUseCase = editCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
        }

        public IActionResult Index()
        {
            var categories = _viewCategoriesUseCase.Execute();
            return View(categories);
        }
        public IActionResult Create()
        {
            ViewBag.Action = "create";

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            ViewBag.Action = "edit";
            var category = _viewSelectedCategoryUseCase.Execute(id ?? 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _editCategoryUseCase.Execute(category.Id, category);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            _deleteCategoryUseCase.Execute(id ?? 0);
            return RedirectToAction(nameof(Index));
        }
    }
}
