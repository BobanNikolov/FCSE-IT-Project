using FCSE_IT_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCSE_IT_Project.Repositories
{
    public class OrdersRepository
    {
        private ApplicationDbContext objApplicationDbContext;
        public OrdersRepository()
        {
            objApplicationDbContext = new ApplicationDbContext();
        }

        public IEnumerable<SelectListItem> GetAllOrders()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objApplicationDbContext.Orders
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