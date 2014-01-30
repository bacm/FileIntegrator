namespace ConsoleApplication1
{
    public class IntegrationStateFactory : IIntegrationStateFactory
    {
        public IIntegrationState Start(string filepath)
        {
            return new StartingState(filepath);
        }
    }
}