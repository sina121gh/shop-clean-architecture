using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Shop.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new();

        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(err => Errors.Add(err.ErrorMessage));
        }
    }
}
