using System;

namespace Ailurus.Service
{
    public class NoMapException: Exception
    {
        public NoMapException(string message): base(message)
        {
            
        }
        
        public NoMapException(string message, Exception innerException): base(message, innerException)
        {
            
        }
    }
}