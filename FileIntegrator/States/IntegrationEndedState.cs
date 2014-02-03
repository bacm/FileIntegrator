using System;
using FileIntegrator.Interfaces;

namespace FileIntegrator.States
{
    public class IntegrationEndedState : IIntegrationState
    {
        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.ProcessingEndedSuccessfully; }
        }

        public void Execute()
        {
            throw new StateException(this, new Exception());
        }

        public IIntegrationState NextState()
        {
            throw new StateException(this, new Exception("this is the last step"));
        }
    }
}