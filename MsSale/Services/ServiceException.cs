using System;

namespace MsSale.Services
{
    public class ServiceException : Exception
    {
        public ServiceException(string message = "An internal service error occured")
            : base(message) { }
    }
}
