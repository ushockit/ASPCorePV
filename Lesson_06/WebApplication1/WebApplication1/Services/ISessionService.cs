using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Products;

namespace WebApplication1.Services
{
    public interface ISessionService
    {
        void AddProductToCart(HttpContext context, string key, ProductViewModel value);
        List<ProductViewModel> GetCartProducts(HttpContext context, string key);
    }
}
