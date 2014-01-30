namespace ConsoleApplication1
{
    public interface IIntegrationStateFactory
    {
        IIntegrationState Start(string filepath);
    }
}