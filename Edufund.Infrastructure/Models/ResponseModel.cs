using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.Models
{
    public class ResponseModel<T>
    {
        public T Result { get; set; }
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}
