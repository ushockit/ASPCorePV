using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Validators.Attributes
{
    public class BadWordsAttribute: ValidationAttribute
    {
        string[] words;
        public BadWordsAttribute(string[] badWords)
        {
            words = badWords;
        }

        public override bool IsValid(object value)
        {
            string pattern = string.Join('|', words);
            return !Regex.IsMatch(value.ToString().ToLower(), pattern);
        }
    }
}
