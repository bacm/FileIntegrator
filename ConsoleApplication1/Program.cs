using System;
using System.IO;
using System.Threading;
using Ninject;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IObservableSyncronizedQueue>().To<ObservableSyncronizedQueue>().InSingletonScope();
            kernel.Bind<IFileConsumer>().To<FileConsumer>().InSingletonScope();
            kernel.Bind<IFileWatcherProducer>().To<FileWatcherProducer>().InSingletonScope();
            kernel.Bind<IIntegrationStateFactory>().To<IntegrationStateFactory>().InSingletonScope();
            kernel.Bind<IIntegrationOrchestrator>().To<IntegrationOrchestrator>();

            Directory.CreateDirectory(@"f:\temporary_directory_to_delete");

            var filename = string.Format("{0}.txt", Guid.NewGuid());
            var path = string.Format(@"f:\temporary_directory_to_delete\{0}", filename);

            var consumer = kernel.Get<IFileConsumer>();

            using (var watcher = kernel.Get<IFileWatcherProducer>())
            {
                consumer.Start();
                watcher.Start(@"f:\temporary_directory_to_delete");

                File.WriteAllText(path, "some contents");

                // detect it or die
                Thread.Sleep(1000);
            }

            while (File.Exists(path))
            {
                // wait for file every second
                Thread.Sleep(1000);
            }

            File.Delete(path);

            Directory.Delete(@"f:\temporary_directory_to_delete");
        }
    }
}