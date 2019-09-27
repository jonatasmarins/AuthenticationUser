using AuthenticationUser.Domain.Models.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthenticationUser.Domain.Models.Generic
{
    public class ResultResponseValidator : IResultResponse
    {

        public bool Success => this.ErrorMessages == null || !this.ErrorMessages.Any();

        public IList<KeyValuePair<string, string>> ErrorMessages { get; set; }

        public ResultResponseValidator()
        {
            InitialListError();
        }

        public ResultResponseValidator(ValidationResult validationResult)
        {
            InitialListError();
            VerifyErrors(validationResult);
        }

        private void InitialListError()
        {
            ErrorMessages = new List<KeyValuePair<string, string>>();
        }

        public void AddError(string property, string message)
        {
            KeyValuePair<string, string> error = new KeyValuePair<string, string>(property, message);
            ErrorMessages.Add(error);
        }

        private void VerifyErrors(ValidationResult validationResult)
        {
            if (validationResult != null && !validationResult.IsValid && validationResult.Errors != null)
            {
                if (this.ErrorMessages == null)
                {
                    this.ErrorMessages = new List<KeyValuePair<string, string>>();
                }

                this.ErrorMessages = validationResult.Errors.Select(x => new KeyValuePair<string, string>(x.ErrorMessage, null)).ToList();
            }
        }
    }
}
