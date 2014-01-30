namespace FileIntegrator
{
    public class StartingState : IIntegrationState
    {
        private readonly string _filepath;

        public StartingState(string filepath)
        {
            _filepath = filepath;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.StartFileProcessing; }
        }

        public IIntegrationState NextState()
        {
            return new CheckFileNameState(_filepath);
        }
    }
}