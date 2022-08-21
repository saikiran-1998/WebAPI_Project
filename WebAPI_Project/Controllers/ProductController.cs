using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project.Data;
using WebAPI_Project.HelperClasses;
using WebAPI_Project.Models;

namespace WebAPI_Project.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    // [Route("v{v:apiVersion}/products")]
    [Route("products")]
    public class ProductV1_Controller : ControllerBase
    {
        private readonly ShopContext context;

        public ProductV1_Controller(ShopContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }
        //[HttpGet]
        //public List<Product> GetAllProducts()
        //{
        //    return (this.context.Products.ToList());
        //}
        //[HttpGet]
        //public IActionResult GetAllProducts(int id)
        //{
        //    return Ok(this.context.Products.ToList());
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAllProducts()
        //{
        //    return Ok(await this.context.Products.ToListAsync());
        //}
        //[HttpGet("{id}")]
        //public Product GetProduct(int id)
        //{
        //    return this.context.Products.ToList().Where(i => i.Product_ID == id).FirstOrDefault();
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    return Ok(this.context.Products.ToList().Where(i=>i.Product_ID==id).FirstOrDefault());
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    return Ok(this.context.Products.ToList().Where(i => i.Product_ID == id).FirstOrDefault());
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return Ok(await this.context.Products.FirstOrDefaultAsync(i => i.Product_ID == id));
        }

        //Pagination
        [HttpGet]
        [Route("paginationapi")]
        public async Task<IActionResult> GetAllProducts([FromQuery] PagingParameters pagingParameters)
        {
            IQueryable<Product> products = this.context.Products;
            products = products
                .Skip(pagingParameters.Size * (pagingParameters.Page - 1))
                .Take(pagingParameters.Size);
            return Ok(await products.ToListAsync());
        }

        //Filteration
        [HttpGet]
        [Route("filterapi")]
        public async Task<IActionResult> FilterAllProducts([FromQuery] FilteringParameters filteringParameters)
        {
            IQueryable<Product> products = this.context.Products
                  .Where(p => p.Product_Cost >= filteringParameters.MinPrice &&
                  p.Product_Cost <= filteringParameters.MaxPrice);
            return Ok(await products.ToListAsync());
        }
        [HttpGet]
        [Route("searchapi")]
        public async Task<IActionResult> SearchProducts([FromQuery] FilteringParameters filteringParameters)
        {
            IQueryable<Product> products = this.context.Products;
            if (!string.IsNullOrEmpty(filteringParameters.Name))
            {
                products = products.Where(p => p.Product_Name.ToLower().Contains(filteringParameters.Name.ToLower()));
            }
            return Ok(await products.ToListAsync());
        }
        [HttpGet]
        [Route("sortapi")]
        public async Task<IActionResult> SortProducts([FromQuery] SortingParameters sortingParameters)
        {
            IQueryable<Product> products = this.context.Products;
            if (!string.IsNullOrEmpty(sortingParameters.SortBy) && (typeof(Product).GetProperty(sortingParameters.SortBy) != null))
            {
                products = products.OrderByCustom(sortingParameters.SortBy, sortingParameters.SortOrder);
            }
            return Ok(await products.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            //return CreatedAtAction(
            //               "GetProduct",
            //               new { id = product.Product_ID },
            //               product);
            return Ok("Product added with id " + product.Product_ID);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (id == product.Product_ID)
                {
                    //this.context.Entry(product).State = EntityState.Modified;
                    this.context.Update(product);
                    await context.SaveChangesAsync();
                    return Ok(product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok("product with id :" + product.Product_ID + " is Deleted");

        }
    }


    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{v:apiVersion}/products")]
    [Authorize]
    //[Route("products")]
    public class ProductV2_Controller : ControllerBase
    {
        private readonly ShopContext context;

        public ProductV2_Controller(ShopContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        [HttpGet]
        public List<Product> GetAllCostlyProducts()
        {
            return (this.context.Products.Where(p => p.Product_Cost > 50).ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return Ok(await this.context.Products.FirstOrDefaultAsync(i => i.Product_ID == id));
        }

        //Pagination
        [HttpGet]
        [Route("paginationapi")]
        public async Task<IActionResult> GetAllProducts([FromQuery] PagingParameters pagingParameters)
        {
            IQueryable<Product> products = this.context.Products;
            products = products
                .Skip(pagingParameters.Size * (pagingParameters.Page - 1))
                .Take(pagingParameters.Size);
            return Ok(await products.ToListAsync());
        }

        //Filteration
        [HttpGet]
        [Route("filterapi")]
        public async Task<IActionResult> FilterAllProducts([FromQuery] FilteringParameters filteringParameters)
        {
            IQueryable<Product> products = this.context.Products
                  .Where(p => p.Product_Cost >= filteringParameters.MinPrice &&
                  p.Product_Cost <= filteringParameters.MaxPrice);
            return Ok(await products.ToListAsync());
        }
        [HttpGet]
        [Route("searchapi")]
        public async Task<IActionResult> SearchProducts([FromQuery] FilteringParameters filteringParameters)
        {
            IQueryable<Product> products = this.context.Products;
            if (!string.IsNullOrEmpty(filteringParameters.Name))
            {
                products = products.Where(p => p.Product_Name.ToLower().Contains(filteringParameters.Name.ToLower()));
            }
            return Ok(await products.ToListAsync());
        }
        [HttpGet]
        [Route("sortapi")]
        public async Task<IActionResult> SortProducts([FromQuery] SortingParameters sortingParameters)
        {
            IQueryable<Product> products = this.context.Products;
            if (!string.IsNullOrEmpty(sortingParameters.SortBy) && (typeof(Product).GetProperty(sortingParameters.SortBy) != null))
            {
                products = products.OrderByCustom(sortingParameters.SortBy, sortingParameters.SortOrder);
            }
            return Ok(await products.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            //return CreatedAtAction(
            //               "GetProduct",
            //               new { id = product.Product_ID },
            //               product);
            return Ok("Product added with id " + product.Product_ID);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                // if (id == product.Product_ID)
                {
                    //this.context.Entry(product).State = EntityState.Modified;
                    this.context.Update(product);
                    await context.SaveChangesAsync();
                }
                // else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok("product with id :" + product.Product_ID + " is Deleted");

        }
    }
}
