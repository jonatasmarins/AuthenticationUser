using FluentValidation.Results;

namespace AuthenticationUser.Domain.Models.Generic
{
    public class ResultResponseObject<T> : ResultResponseValidator
    {

        public ResultResponseObject()
        {

        }

        public ResultResponseObject(ValidationResult validationResult) : base(validationResult)
        {

        }

        public T Value { get; set; }
    }
}
