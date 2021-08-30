using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utils
{
    public class AppUtils
    {
        public CultureInfo[] AvailableCultures => new CultureInfo[]
        {
            new CultureInfo("en"),
            new CultureInfo("ru"),
        };
        public string DefaultCultureName => "ru";
        public string[] ListAvailableLanguages => AvailableCultures.Select(c => c.Name).ToArray();
    }
}
