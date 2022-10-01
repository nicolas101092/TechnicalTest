using App.Utils.Extensions.Constants;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace App.Utils.Extensions.Helpers.PersonalExceptions.Extensions
{
    public static class BadRequestExtension
    {
        /// <summary>
        /// Throw a BadRequest if the object is null and print the content of var message
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="item">a object to validate if is null</param>
        /// <param name="message">the error message</param>
        /// <exception cref="BadRequestException">throw the personal BadRequestException for convert the result of api in a badrequest</exception>
        public static void ThrowIfNull<T>(T item, string message)
        {
            if (item == null)
                throw new BadRequestException(message);
        }

        /// <summary>
        /// Throw a BadRquest if a ModelStateDictionary count 0
        /// </summary>
        /// <param name="messages">a object ModelStateDictionary with a error validation</param>
        /// <param name="detail">detail of message</param>
        /// <exception cref="BadRequestException">throw the personal BadRequestException for convert the result of api in a badrequest</exception>
        public static void ThrowIfIsNotValid(ModelStateDictionary messages, string detail = ConstantsExceptions.MESSAGE_SEVERAL_ERRORS)
        {
            if (messages != null && messages.Count > 0)
                throw new BadRequestException(messages, detail);
        }

        /// <summary>
        /// Throw a BadRequest if a bool valid is false
        /// </summary>
        /// <param name="valid">a bool with the validation</param>
        /// <param name="message">the error message</param>
        /// <exception cref="BadRequestException">throw the personal BadRequestException for convert the result of api in a badrequest</exception>
        public static void ThrowIfIsNotValid(bool valid, string message = ConstantsExceptions.GENERIC_MESSAGE_VALIDATION)
        {
            if (!valid)
                throw new BadRequestException(message);
        }

        /// <summary>
        /// Throw a BadRequest if the object is null and print the content of var message
        /// </summary>
        /// <typeparam name="T">a generic object</typeparam>
        /// <param name="item">a object to validate if is null</param>
        /// <param name="message">the error message</param>
        /// <exception cref="BadRequestException">throw the personal BadRequestException for convert the result of api in a badrequest</exception>
        public static void ThrowIfFluentValidation<T>(T item, AbstractValidator<T> validator, string message = ConstantsExceptions.GENERIC_MESSAGE_VALIDATION)
        {
            ValidationResult results = validator.Validate(item);

            if (!results.IsValid)
            {
                ModelStateDictionary errors = new();
                results.Errors.ForEach(x => errors.AddModelError(x.PropertyName, x.ErrorMessage));
                throw new BadRequestException(errors, message);
            }
        }
    }
}
