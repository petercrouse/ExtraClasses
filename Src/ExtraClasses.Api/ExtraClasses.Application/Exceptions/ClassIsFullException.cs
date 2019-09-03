using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Exceptions
{
    public class ClassIsFullException : Exception
    {
        public ClassIsFullException(object name, object key)
            : base($"Unable to create booking for \"{name}\" ({key}), the class is full ")
        {
        }
    }
}
