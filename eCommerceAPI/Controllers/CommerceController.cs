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

        [Route("GetProductById")]
        [HttpGet]
        public Product GetProductById(long id)
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

        [Route("DeleteProduct")]
        [HttpDelete]
        public object DeleteProduct(long productId)
        {
            try
            {
                _repository.DeleteProduct(productId);
            }
            catch
            {

                return new { Success = "false", Message = "Não foi possivel deletar o produto" };
            }

            return new { Success = "true", Message = "Produto deletado com sucesso!" };
        }

        [Route("UpdateProduct")]
        [HttpPut]
        public object UpdateProduct(Product product)
        {
            try
            {
                _repository.UpdateProduct(product);
            } 
            catch
            {
                return new { success = "false", message = "Não foi possivel atualizar o produto" };
            }

            return new { success = "true", message = "Produto atualizado com sucesso!" };
        }
    }
}
