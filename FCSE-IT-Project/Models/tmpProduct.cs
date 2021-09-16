using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCSE_IT_Project.Models
{
    public class tmpProduct
    {
        public tmpProduct()
        {

        }
        [Key]
        public int id { get; set; }
        public int OrderID { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}