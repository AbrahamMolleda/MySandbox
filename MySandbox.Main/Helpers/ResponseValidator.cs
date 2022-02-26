using MySandbox.Main.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.Helpers
{
    public static class ResponseValidator<T>
    {
        
        public static Response<T> ValidateData(T parameter, string successMessage, string failMessage)
        {
            Response<T> response = new Response<T>();
            if(parameter == null)
            {
                response.setError("ups", failMessage);
                return response;
            }

            response.SetSuccess("Success!!", successMessage);
            response.Data = parameter;
            return response;
        }
        
    }
}
