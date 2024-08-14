using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApiAdo.Model
{
    public class ProductsModel
    {
        public int ProductId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public decimal Price {get; set;}
        [Required]
        public int StockQuantity {get; set;}
        
    }
}