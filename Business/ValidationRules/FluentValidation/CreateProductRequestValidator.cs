using Business.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p=>p.UnitPrice).NotEmpty().GreaterThan(0);

        }
    }
}
