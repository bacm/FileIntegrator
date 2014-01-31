namespace FileIntegrator
{
    public interface IIntegrationStateFactory
    {
        IIntegrationState Start(string filepath);
    }
}