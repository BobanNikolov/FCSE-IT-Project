using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCSE_IT_Project.Models
{
    public class Order
    {
        public Order()
        {
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Име на нарачка")]
        public string Name { get; set; }
       // public virtual List<tmpProduct> order { get; set; }
    }
}