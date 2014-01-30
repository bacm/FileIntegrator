namespace ConsoleApplication1
{
    public class OpenFileNameState : IIntegrationState
    {
        private readonly string _filepath;

        public EIntegratorStep IntegratorStep { get { return EIntegratorStep.OpenFile; } }

        public OpenFileNameState(string filepath)
        {
            _filepath = filepath;
        }

        public IIntegrationState NextState()
        {
            return new IntegrationEndedState();
        }
    }
}