using System;

namespace FileIntegrator
{
    public class StateException : Exception
    {
        public StateException(IIntegrationState state)
        {
            State = state;
        }

        public IIntegrationState State { get; private set; }
    }
}