using System;

using Entities.Abstract;
using FluentValidation;

namespace Core.CrossCuttingConcern.Validation
{
	public static class ValidationTool
	{
		public static void Validation(IValidator productValidator, object entity)
		{

            var context = new ValidationContext<object>(entity);
            
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
	}
}

