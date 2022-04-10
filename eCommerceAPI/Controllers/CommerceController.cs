using eCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerceAPI.Controllers
{
    public class CommerceController : ControllerBase
    {
        [Route("GetProduct")]
        [HttpGet]
        public Product GetProduct()
        {
            return null;
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return null;
        }
    }
}
