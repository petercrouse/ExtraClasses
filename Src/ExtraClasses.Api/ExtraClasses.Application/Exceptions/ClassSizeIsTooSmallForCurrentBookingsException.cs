using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Exceptions
{
    public class ClassSizeIsTooSmallForCurrentBookingsException : Exception
    {
        public ClassSizeIsTooSmallForCurrentBookingsException(object name, object key, int currentSize, int newSize)
            : base($"Entity \"{name}\" ({key}) cant be updated to a class size of {newSize} because there are {newSize} bookings for the class.")
        {
        }
    }
}
