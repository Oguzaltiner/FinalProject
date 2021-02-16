using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this result yani bu clasın tek parametreli olan const. da çalıştır.
        public Result(bool success, string message) : this(success)
        {
           
            this.Message = message;
        }
        public Result(bool success)
        {
            this.Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
