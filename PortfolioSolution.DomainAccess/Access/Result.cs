using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSolution.DomainAccess.Access
{
    public class Result
    {
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
    }
    public class Result<T> : Result where T : class
    {
        public T Data { get; set; }
    }
}
