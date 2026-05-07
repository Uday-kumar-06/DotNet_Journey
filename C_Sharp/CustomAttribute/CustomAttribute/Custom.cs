using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class Custom: Attribute
    {
        public string Description { get; set; }
        public int Version { get; set; }
        public Custom() { }
        public Custom(string description, int version)
        {
            Description = description;
            Version = version;
        }
    }
}
