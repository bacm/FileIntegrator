using FileIntegrator.Interfaces;

namespace FileIntegrator.States
{
    public class CheckFileNameState : IIntegrationState
    {
        private readonly IntegratedFile _file;

        public CheckFileNameState(IntegratedFile file)
        {
            _file = file;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.CheckFileName; }
        }

        public void Execute()
        {
            OberthurFileIntegratorEventSource.Log.NameChecked(_file.Filepath);
        }

        public IIntegrationState NextState()
        {
            return new OpenFileNameState(_file);
        }
    }
}