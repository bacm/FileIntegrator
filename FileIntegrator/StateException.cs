using System;
using FileIntegrator.Interfaces;
using FileIntegrator.States;

namespace FileIntegrator
{
    public class StateException : Exception
    {
        private readonly Exception _exception;

        public StateException(IIntegrationState state, Exception exception)
        {
            _exception = exception;
            State = state;
        }

        public IIntegrationState State { get; private set; }
    }
}