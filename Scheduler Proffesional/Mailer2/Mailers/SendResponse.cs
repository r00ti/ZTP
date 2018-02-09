using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer2
{
    public class SendResponse
    {
        public List<string> ErrorMessages { get; set; }
        public bool Successful => !ErrorMessages.Any();

        public SendResponse()
        {
            ErrorMessages = new List<string>();
        }
    }

    public class SendResponse<T> : SendResponse
    {
        public T Data { get; set; }
    }
}
