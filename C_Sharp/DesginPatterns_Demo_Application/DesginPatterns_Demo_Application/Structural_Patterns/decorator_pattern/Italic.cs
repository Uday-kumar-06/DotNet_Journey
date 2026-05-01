using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern
{
    public class ItalicDecorator : TextDecorator
    {
        public ItalicDecorator(IText text) : base(text) { }

        public override string Format()
        {
            return "<i>" + text.Format() + "</i>";
        }
    }
}
