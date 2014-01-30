namespace FileIntegrator
{
    public class OpenFileNameState : IIntegrationState
    {
        private readonly string _filepath;

        public OpenFileNameState(string filepath)
        {
            _filepath = filepath;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.OpenFile; }
        }

        public IIntegrationState NextState()
        {
            return new IntegrationEndedState();
        }
    }
}