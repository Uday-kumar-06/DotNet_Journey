using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern
{
    public class BoldDecorator : TextDecorator
    {
        public BoldDecorator(IText text) : base(text) { }

        public override string Format()
        {
            return "<b>" + text.Format() + "</b>";
        }
    }
}
