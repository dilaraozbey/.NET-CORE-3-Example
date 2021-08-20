using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult(T data, string message) : base(data, success: true, message)
        {

        }
        public SuccesDataResult(string message) : base(default, success: true,message)
        {

        }
        public SuccesDataResult(T data) : base(data, success: true)
        {

        }
    }
}
