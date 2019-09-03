using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Exceptions
{
    public class DoubleBookingException: Exception
    {
        public DoubleBookingException(object name, object key, object studentKey)
            :base($"Entity \"{name}\" ({key}) already has a booking for student ({studentKey})")
        {

        }
    }
}
