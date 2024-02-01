namespace Core.CrossCuttingConcerns.Loging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}