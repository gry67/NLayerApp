using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryServices;

        public CategoriesController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("Action/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProduct(int categoryId)
        {
            return CreateActionResult(await _categoryServices.GetSingleCategoryByIdWithProductAsync(categoryId));
        }
    }
}
