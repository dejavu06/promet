using System.Collections.Generic;

namespace Core.CrossCuttingConcerns.Loging
{
    public class LogDetail
    {
        public string MethodName { get; set; }

        public List<LogParameter> LogParameters { get; set; }
    }
}