using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public interface ITemplateRenderer
    {
        string Parse<T>(string template, T model, bool isHtml = true);
    }
}
