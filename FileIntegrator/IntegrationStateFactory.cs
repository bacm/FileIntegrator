namespace FileIntegrator
{
    public class IntegrationStateFactory : IIntegrationStateFactory
    {
        public IIntegrationState Start(string filepath)
        {
            return new StartingState(filepath);
        }
    }
}