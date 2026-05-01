using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern
{
    public abstract class TextDecorator : IText
    {
        protected IText text;
        public TextDecorator(IText text)
        {
            this.text = text;
        }
        public virtual string Format()
        {
            return text.Format();
        }
    }
}
