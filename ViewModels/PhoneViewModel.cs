using AMobile.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AMobile.ViewModels
{
    public class PhoneViewModel
    {
        public string Search { get; set; }
        public string Category { get; set; }
        public IQueryable<Phone> Phones { get; set; }
        public IEnumerable<CategoryWithCount> CategoriesWithCount { get; set; }
        public IEnumerable<SelectListItem> CategoryFilterItems
        {
            get
            {
                var allCategories = CategoriesWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CategoriesNameWithCount
                });
                return allCategories;
            }
        }
    }

    public class CategoryWithCount
    {
        public int PhoneCount { get; set; }
        public string CategoryName { get; set; }
        public string CategoriesNameWithCount
        {
            get
            {
                return CategoryName + " (" + PhoneCount.ToString() + ")";
            }
        }

    }
}