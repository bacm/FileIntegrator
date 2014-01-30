namespace ConsoleApplication1
{
    public class CheckFileNameState : IIntegrationState
    {
        private readonly string _filepath;
        public EIntegratorStep IntegratorStep { get { return EIntegratorStep.CheckFileName; } }

        public CheckFileNameState(string filepath)
        {
            _filepath = filepath;
        }

        public IIntegrationState NextState()
        {
            return new OpenFileNameState(_filepath);
        }
    }
}