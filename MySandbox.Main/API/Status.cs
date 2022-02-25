using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySandbox.Main.API
{
    public class Status
    {
        public Status()
        {

        }
        public void SetError()
        {
            this.Code = (int)ResponseCodes.Error;//.ToIntValue();
            this.Type = ResponseCodes.Error.ToString();//.ToLower();
        }
        public void SetSuccess()
        {
            this.Code = (int)ResponseCodes.Ok;//.ToIntValue
            this.Type = ResponseCodes.Ok.ToString();//ToLower();
        }

        public void AddMessage(string title, string description)
        {

            this.Messages = this.Messages ?? new List<Message>();
            this.Messages.Add(new Message() { Title = title, Description = description });

        }
        public void ClearMessages()
        {
            this.Messages = this.Messages ?? new List<Message>();
            this.Messages.Clear();
        }


        public int Code { get; set; }

        public string Type { get; set; }

        public List<Message> Messages { get; set; }
    }
}
