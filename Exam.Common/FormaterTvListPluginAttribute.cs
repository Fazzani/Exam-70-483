using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class FormaterTvListPluginAttribute : Attribute
    {
        public FormaterTvListPluginAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
