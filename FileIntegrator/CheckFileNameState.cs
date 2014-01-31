namespace FileIntegrator
{
    public class CheckFileNameState : IIntegrationState
    {
        private readonly string _filepath;

        public CheckFileNameState(string filepath)
        {
            CheckFileName();
            _filepath = filepath;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.CheckFileName; }
        }

        public IIntegrationState NextState()
        {
            return new OpenFileNameState(_filepath);
        }

        private void CheckFileName()
        {
            throw new StateException(this);
        }
    }
}