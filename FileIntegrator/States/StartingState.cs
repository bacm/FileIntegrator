using FileIntegrator.Interfaces;

namespace FileIntegrator.States
{
    public class StartingState : IIntegrationState
    {
        private readonly IntegratedFile _file;

        public StartingState(IntegratedFile file)
        {
            _file = file;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.StartFileProcessing; }
        }

        public void Execute()
        {
            OberthurFileIntegratorEventSource.Log.Startup();
        }

        public IIntegrationState NextState()
        {
            return new CheckFileNameState(_file);
        }
    }
}