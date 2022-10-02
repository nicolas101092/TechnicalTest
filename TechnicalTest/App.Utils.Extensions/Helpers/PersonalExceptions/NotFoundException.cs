using App.Utils.Extensions.Constants;
using System.Runtime.Serialization;

namespace App.Utils.Middlewares.Core.PersonalExceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(ConstantsExceptions.MESSAGE_NOT_FOUND_EXCEPTION)
        {
        }

        public NotFoundException(string id) : base($"{ConstantsExceptions.MESSAGE_NOT_FOUND_EXCEPTION}: {id}")
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
