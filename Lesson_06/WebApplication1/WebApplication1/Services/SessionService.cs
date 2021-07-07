using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Products;

namespace WebApplication1.Services
{
    public class SessionService : ISessionService
    {
        public void AddProductToCart(HttpContext context, string key, ProductViewModel value)
        {
            if (context.Session.GetString(key) is null)
            {
                context.Session.SetString(key, JsonConvert.SerializeObject(new List<ProductViewModel>()));
            }

            var cartProducts = JsonConvert.DeserializeObject<List<ProductViewModel>>(context.Session.GetString(key));
            cartProducts.Add(value);

            context.Session.SetString(key, JsonConvert.SerializeObject(cartProducts));
        }

        public List<ProductViewModel> GetCartProducts(HttpContext context, string key)
        {
            string json = context.Session.GetString(key);
            return json is null ? new List<ProductViewModel>() : JsonConvert.DeserializeObject<List<ProductViewModel>>(json);
        }
    }
}
