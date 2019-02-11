using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.ViewModels
{
    public class ApiResponse
    {


        public bool HasError { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }
    }

    public class GenericApiResponse<T>
    {
        public T Result { get; set; }

    }
}
