using FileIntegrator.Interfaces;
using FileIntegrator.States;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace FileIntegrator
{
    public class IntegrationOrchestrator : IIntegrationOrchestrator
    {
        private readonly IIntegrationStateFactory stateFactory;

        public IntegrationOrchestrator(IIntegrationStateFactory stateFactory)
        {
            this.stateFactory = stateFactory;
        }

        public void Start(string filepath)
        {
            var currentState = stateFactory.Start(filepath);

            do
            {
                TryToExecuteState(currentState);
                currentState = currentState.NextState();
            } while (currentState.IntegratorStep != EIntegratorStep.ProcessingEndedSuccessfully);
        }

        private static void TryToExecuteState(IIntegrationState currentState)
        {
            try
            {
                currentState.Execute();
            }
            catch (StateException se)
            {
                var rethrow = ExceptionPolicy.HandleException(se, "Dev");

                if (rethrow)
                {
                    throw;
                }
            }
        }
    }
}