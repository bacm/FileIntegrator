namespace ConsoleApplication1
{
    public class StartingState : IIntegrationState
    {
        private readonly string _filepath;

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.StartFileProcessing; }
        }

        public StartingState(string filepath)
        {
            _filepath = filepath;
        }

        public IIntegrationState NextState()
        {
            return new CheckFileNameState(_filepath);
        }
    }
}