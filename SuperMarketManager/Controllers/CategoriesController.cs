using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;

namespace SuperMarketManager.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        private readonly IEditCategoryUseCase _editCategoryUseCase;
        private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;

        public CategoriesController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IAddCategoryUseCase addCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            _viewCategoriesUseCase = viewCategoriesUseCase;
            _viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            _addCategoryUseCase = addCategoryUseCase;
            _editCategoryUseCase = editCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _viewCategoriesUseCase.ExecuteAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            ViewBag.Action = "create";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _addCategoryUseCase.ExecuteAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            ViewBag.Action = "edit";
            var category = await _viewSelectedCategoryUseCase.ExecuteAsync(id ?? 0);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _editCategoryUseCase.ExecuteAsync(category.Id, category);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _deleteCategoryUseCase.ExecuteAsync(id ?? 0);
            return RedirectToAction(nameof(Index));
        }
    }
}
