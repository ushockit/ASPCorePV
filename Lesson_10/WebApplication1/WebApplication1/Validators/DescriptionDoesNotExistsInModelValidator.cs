using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Validators
{
    public class DescriptionDoesNotExistsInModelValidator : IModelPropertyValidator
    {
        string value;
        public DescriptionDoesNotExistsInModelValidator(string description)
        {
            value = description;
        }
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
