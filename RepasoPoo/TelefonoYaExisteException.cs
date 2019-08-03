using System;

namespace RepasoPoo
{
    public class TelefonoYaExisteException : Exception
    {
        public TelefonoYaExisteException(string message) : base(message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}