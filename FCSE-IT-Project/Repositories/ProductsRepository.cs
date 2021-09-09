using FCSE_IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCSE_IT_Project.Repositories
{
    public class ProductsRepository
    {
        private ApplicationDbContext objApplicationDbContext;
        public ProductsRepository()
        {
            objApplicationDbContext = new ApplicationDbContext();
        }

        public IEnumerable<SelectListItem> GetAllProducts()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objApplicationDbContext.Products
                                  select new SelectListItem()
                                  {
                                      Text = obj.Name,
                                      Value = obj.Id.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}