using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Structural_Patterns.decorator_pattern
{
    public class PlainText : IText
    {
        private string text;

        public PlainText(string text)
        {
            this.text = text;
        }

        public string Format()
        {
            return text;
        }
    }
}
