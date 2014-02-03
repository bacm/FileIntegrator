using FileIntegrator.Interfaces;
using FileIntegrator.States;

namespace FileIntegrator
{
    public class IntegrationStateFactory : IIntegrationStateFactory
    {
        private readonly IntegratedFileFactory _factory;

        public IntegrationStateFactory(IntegratedFileFactory factory)
        {
            _factory = factory;
        }

        public IIntegrationState Start(string filepath)
        {
            var file = _factory.Create(filepath);
            return new StartingState(file);
        }
    }
}