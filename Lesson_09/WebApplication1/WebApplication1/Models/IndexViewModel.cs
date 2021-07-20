using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class IndexViewModel
    {
        public string[] GenderValues { get; set; }
        public SelectList CategoriesForDropDown { get; set; }
        public MultiSelectList CategoriesForListBox { get; set; }
    }
}
