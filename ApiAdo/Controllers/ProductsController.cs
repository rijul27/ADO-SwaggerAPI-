using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAdo.Model;
using System.Data.SqlClient;
using System.Data;


using Microsoft.AspNetCore.Mvc;


namespace ApiAdo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            List<ProductsModel> productsModels = new List<ProductsModel>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductsModel product = new ProductsModel
                {
                    ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[i]["Price"]),
                    StockQuantity = Convert.ToInt32(dt.Rows[i]["StockQuantity"])
                };

                productsModels.Add(product);
            }

            return Ok(productsModels);
        }




        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductsModel obj)
        {
            try
            {

                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Defaultconnection"));
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (Name, Description, Price, StockQuantity) VALUES ('" + obj.Name + "', '" + obj.Description + "', '" + obj.Price + "', '" + obj.StockQuantity + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducts(ProductsModel obj)
        {
            if (obj == null)
            {
                return BadRequest("Product data is null.");
            }

            if (obj.ProductId == 0)
            {
                return BadRequest("Invalid Product ID.");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Defaultconnection")))
                {
                    string query = $"UPDATE Products SET Name = {obj.Name}, Description = {obj.Description}, Price = {obj.Price}, StockQuantity = {obj.Quantity} WHERE ProductId = {obj.ProductId}";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        con.Close();

                        if (rowsAffected == 0)
                        {
                            return NotFound($"Product with ID {obj.ProductId} not found.");
                        }
                    }
                }

                return Ok(obj);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Defaultconnection"));
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = '" + productId + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}