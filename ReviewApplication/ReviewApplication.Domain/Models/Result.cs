using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Domain
{
    public class Result<T>
    {
        public Result()
        {
            Success = false;


        }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
