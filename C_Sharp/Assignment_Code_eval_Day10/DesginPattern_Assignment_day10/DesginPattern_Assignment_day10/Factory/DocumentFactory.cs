using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10.Factory
{
    internal class DocumentFactory
    {
        public static Interface1 GetDocument(string documentType)
        {
            if (documentType.Equals("ConcreteClass1", StringComparison.OrdinalIgnoreCase))
            {
                return new ConcreteClasses1();
            }
            else if (documentType.Equals("ConcreteClass2", StringComparison.OrdinalIgnoreCase))
            {
                return new ConcreteClasses2();
            }
            else
            {
                throw new ArgumentException("Invalid document type");
            }
        }
    }
}
