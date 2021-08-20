using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }
        public ErrorDataResult(string message) : base(default, success: false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, success: true)
        {

        }
    }
}
