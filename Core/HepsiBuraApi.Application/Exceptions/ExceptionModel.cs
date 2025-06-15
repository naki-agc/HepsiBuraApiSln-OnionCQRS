using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Exceptions
{
    public class ExceptionModel:ErrorStatusCode // Dönmek istediğim durumlar için bir model
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString() // Hata mesajlarını string olarak döndürmek için
        {
            return JsonConvert.SerializeObject(Errors);
        }
    }
    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }

}
