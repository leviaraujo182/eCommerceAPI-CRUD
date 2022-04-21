using eCommerceAPI.Models;
using eCommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eCommerceAPI.Controllers
{
    public class CommerceController : ControllerBase
    {
        private CommerceRepository _repository;

        public CommerceController()
        {
            _repository = new CommerceRepository();
        }

        [Route("GetProduct")]
        [HttpGet]
        public Product GetProduct(long id)
        {
            Product product = new Product();

            try
            {
                product = new CommerceRepository().GetProductById(id);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                products = _repository.GetAllProduct();
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return products;
        }

        [Route("InsertProduct")]
        [HttpPost]
        public void InsertProduct(Product product)
        {
            try 
            {
                _repository.InsertProduct(product);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
