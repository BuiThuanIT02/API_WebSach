using API_WebSach.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsRepository : ControllerBase
    {
        private readonly ISachRepository _sachRepository;
        public ProductsRepository(ISachRepository sachRepository)
        {
            _sachRepository = sachRepository;
        }
        [HttpGet]
        public IActionResult GetAllProduct(string search,string price_desc,int page=1)
        {
            try
            {

                var products = _sachRepository.GetAllProduct(search, price_desc,page);

                return Ok(products);



            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
