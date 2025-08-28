namespace WorkoutApplication
{
    public class InvalidContractException : Exception
    {
        public InvalidContractException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
