using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer2
{
    public interface ITemplateRenderer
    {
        string Parse<T>(string template, T model, bool isHtml = true);
    }
}
