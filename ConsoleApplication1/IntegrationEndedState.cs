namespace ConsoleApplication1
{
    public class IntegrationEndedState : IIntegrationState
    {
        public EIntegratorStep IntegratorStep { get { return EIntegratorStep.ProcessingEndedSuccessfully;} }

        public IIntegrationState NextState()
        {
            return null;
        }
    }
}