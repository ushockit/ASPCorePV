using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Validators.Attributes;

namespace WebApplication1.Models.Home
{
    // https://metanit.com/sharp/tutorial/22.2.php
    // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-5.0
    public class CreateElementViewModel : IValidatableObject
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле 'Имя' обязательно к заполнению")]
        // [RegularExpression("^[A-ZА-Я]", ErrorMessage = "...")]
        [BadWords(new string[] { "дурак", "дебил" }, ErrorMessage = "Следите за лексикой")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Range(0, 100_000, ErrorMessage = "Цена должна бытьь в диапазоне от 0 - 100000")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        //[Required]
        public string Description { get; set; }

        [Display(Name = "Активировать")]
        [Required]
        public bool IsEnable { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Description))
            {
                errors.Add(new ValidationResult("Some error text", new List<string> { nameof(Description) }));
            }

            return errors;
        }
    }
}
