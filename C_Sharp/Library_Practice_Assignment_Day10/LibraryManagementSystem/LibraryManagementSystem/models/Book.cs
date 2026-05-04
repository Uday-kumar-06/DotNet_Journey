using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }

        public void Borrow()
        {
            if (IsBorrowed)
                throw new Exception("Book is already borrowed");

            IsBorrowed = true;
        }

        public void Return()
        {
            IsBorrowed = false;
        }
    }
}
