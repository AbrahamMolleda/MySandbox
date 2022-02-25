using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.API
{
    public class Response <T>
    {
        public Response()
        {

        }

        public Error Error { get; set; }
        public Status Status { get; set; }
        public T Data { get; set; }

        public void setError(string title, string description)
        {
            this.Status = this.Status ?? new Status();
            //seteamos valores
            this.Status.SetError();
            this.Status.ClearMessages();
            this.Status.AddMessage(title, description);
            this.Error = new Error();
            //Falta directivas para que reconozca ToIint sin cast
            this.Error.ErrorCode = (int)ResponseCodes.Error;
            this.Error.Message = title;
            this.Error.Source = description;

        }
        /// <summary>
        /// Establece una respuesta de exito
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// 
        public void SetSuccess(string title, string description)
        {
            this.Status = this.Status ?? new Status();
            this.Status.SetError();
            this.Status.SetSuccess();
            this.Status.AddMessage(title, description);

        }
    }
}
