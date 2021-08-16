using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Response
{
    public class JwtResponseModel
    {
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
    }
}
