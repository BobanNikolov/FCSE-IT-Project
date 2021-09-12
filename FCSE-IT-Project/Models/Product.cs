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
        [Display(Name="Име")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Фотографија")]
        public string photoURL { get; set; }
    }
}