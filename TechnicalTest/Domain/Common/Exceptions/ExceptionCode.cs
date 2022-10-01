namespace Domain.Common.Exceptions
{
    public class ExceptionCode : Exception
    {
        public string CodeException { get; internal set; }


        public ExceptionCode(string CodeException) : base()
        {
            this.CodeException = CodeException;
        }

        public ExceptionCode(string CodeException, string? message) : base(message)
        {
            this.CodeException = CodeException;
        }


        public ExceptionCode(string CodeException, string? message, Exception? innerException) : base(message, innerException)
        {
            this.CodeException = CodeException;
        }

    }
}
