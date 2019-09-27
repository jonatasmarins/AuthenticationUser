using AuthenticationUser.Domain.Models.Interface;
using FluentValidation.Results;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationUser.Domain.Models.Generic
{
    public class ResultResponse : ResultResponseValidator
    {

        public ResultResponse()
        {

        }

        public ResultResponse(ValidationResult validationResult) : base (validationResult)
        {            
        }
    }
}
