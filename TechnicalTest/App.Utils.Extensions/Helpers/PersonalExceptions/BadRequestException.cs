using App.Utils.Extensions.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.Serialization;


namespace App.Utils.Extensions.Helpers.PersonalExceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public ModelStateDictionary Errors { get; set; }

        public BadRequestException() : base($"{ConstantsExceptions.MESSAGE_NOT_VALID_EXCEPTION} {ConstantsExceptions.MESSAGE_ITEM_NULL_EXCEPTION}")
        {
            Errors = new ModelStateDictionary();
        }

        public BadRequestException(string id) : base($"{ConstantsExceptions.MESSAGE_NOT_VALID_EXCEPTION} {id}")
        {
            Errors = new ModelStateDictionary();
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
            Errors = new ModelStateDictionary();
        }

        public BadRequestException(ModelStateDictionary errors, string message = ConstantsExceptions.MESSAGE_SEVERAL_ERRORS) : base(message)
        {
            Errors = errors;
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Errors = new ModelStateDictionary();
        }
    }
}
