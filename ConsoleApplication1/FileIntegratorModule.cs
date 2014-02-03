using FileIntegrator;
using FileIntegrator.Consumer;
using FileIntegrator.Interfaces;
using FileIntegrator.Watcher;
using Ninject.Modules;

namespace ConsoleApplication1
{
    internal class FileIntegratorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IObservableSyncronizedQueue>().To<ObservableSyncronizedQueue>().InSingletonScope();
            Bind<IFileConsumer>().To<FileConsumer>().InSingletonScope();
            Bind<IFileWatcherProducer>().To<FileWatcherProducer>().InSingletonScope();
            Bind<IIntegrationStateFactory>().To<IntegrationStateFactory>().InSingletonScope();
            Bind<IIntegrationOrchestrator>().To<IntegrationOrchestrator>();
            Bind<ILogCollection>().To<LogCollection>();
        }
    }
}