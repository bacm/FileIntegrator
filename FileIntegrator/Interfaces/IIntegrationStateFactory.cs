using FileIntegrator.States;

namespace FileIntegrator.Interfaces
{
    public interface IIntegrationStateFactory
    {
        IIntegrationState Start(string filepath);
    }
}