using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }
        public Result(bool success, string message)
        {
            Message = message;
            Success = success;
        }
        public Result(bool success)
        {

            Success = success;
        }


    }
}
