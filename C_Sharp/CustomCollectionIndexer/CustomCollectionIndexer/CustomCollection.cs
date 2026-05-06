using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCollectionIndexer
{
    public class CustomCollection
    {
        List<string> list = new List<string>();

        public string this[int index]
        {
            get
            {
                if(index <0 || index >= list.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return list[index];
            }
            set
            {
                if(index < 0)
                {
                    throw new NegitiveException("Index cannot be negative.");
                }
                if (index < list.Count)
                {
                    list[index] = value;
                }
                else
                {
                    while (list.Count <= index)
                    {
                        list.Add(null);
                    }
                    list[index] = value;
                }
            }
        }
    }

    class NegitiveException : Exception
    {
        public NegitiveException(string message): base(message) { }
    }
}
