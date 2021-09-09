using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCSE_IT_Project.Models
{
    public class Product
    {
        public Product()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string photoURL { get; set; }
    }
}