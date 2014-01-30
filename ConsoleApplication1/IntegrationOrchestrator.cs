namespace ConsoleApplication1
{
    public class IntegrationOrchestrator : IIntegrationOrchestrator
    {
        private readonly IIntegrationStateFactory _factory;

        public IntegrationOrchestrator(IIntegrationStateFactory factory)
        {
            _factory = factory;
        }

        public void Start(string filepath)
        {
            var currentState = _factory.Start(filepath);

            do { currentState = currentState.NextState(); }
            while (currentState != null);
        }
    }
}