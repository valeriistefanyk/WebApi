using InternetShop.BusinessLogic.Services;
using InternetShop.Domain.Models;
using InternetShop.Filters;
using System;
using System.Linq;
using System.Web.Http;

namespace InternetShop.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService = new CategoryService();

        [HttpGet]
        [ShopAuthenticationFilter]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet]
        //[SimpleActionFilter]
        [OverrideActionFilters]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Category category)
        {
            if (String.IsNullOrEmpty(category.Name))
                return Ok("can't be empty");
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult Search(string name)
        {
            var _categories = _categoryService.GetAll();
            _categories = _categories.Where(c => c.Name.ToLower().Contains(name)).ToList();
            return Ok(_categories);
        }
    }
}
