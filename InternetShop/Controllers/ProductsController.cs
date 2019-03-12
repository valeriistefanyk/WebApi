using InternetShop.BusinessLogic.Services;
using InternetShop.Domain.Models;
using InternetShop.Filters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InternetShop.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService = new ProductService();

        [HttpGet]
        //[ShopExceptionFilter]
        [ShopAuthorizationFilter]
        public IHttpActionResult GetAll()
        {
            //throw new IndexOutOfRangeException();
            return Ok(_productService.GetAll());
        }

        [HttpGet]
        [ShopExtendedActionFilter]
        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                errorMessage.Content = new StringContent("Name can't be empty");
                return errorMessage;
            }
            _productService.Add(product);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

    }
}
