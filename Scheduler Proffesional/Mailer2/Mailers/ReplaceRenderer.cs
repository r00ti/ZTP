﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentEmail.Core.Interfaces;

namespace Mailer2
{
    public class ReplaceRenderer : ITemplateRenderer
    {
        public string Parse<T>(string template, T model, bool isHtml = true)
        {
            foreach (PropertyInfo pi in model.GetType().GetRuntimeProperties())
            {
                template = template.Replace($"##{pi.Name}##", pi.GetValue(model, null).ToString());
            }

            return template;
        }
    }
}
