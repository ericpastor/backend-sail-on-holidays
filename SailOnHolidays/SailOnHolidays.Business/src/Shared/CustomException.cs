namespace SailOnHolidays.Core.src.Shared
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }

        public CustomException(int statusCode, string msg) : base(msg)
        {
            StatusCode = statusCode;
        }

        public static CustomException NotFoundException(string msg)
        {
            return new CustomException(404, msg);
        }

        public static CustomException ConflictException(string msg = "Email is already in use")
        {
            return new CustomException(400, msg);
        }

        public static CustomException MatchingException(string msg)
        {
            return new CustomException(400, msg);
        }

        public static CustomException ListEmptyException(string msg = "List cannot be empty")
        {
            return new CustomException(400, msg);
        }
        public static CustomException InvalidValueException(string msg = "Must be non-negative values.")
        {
            return new CustomException(400, msg);
        }

        public static CustomException NullException(string msg)
        {
            return new CustomException(404, msg);
        }

        public static CustomException MethodErrorException(string msg = "Something went wrong during the operation")
        {
            return new CustomException(417, msg);
        }

        public static CustomException MappingErrorException(string msg)
        {
            return new CustomException(417, msg);
        }
    }
}