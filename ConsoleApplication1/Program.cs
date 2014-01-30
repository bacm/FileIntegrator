using System;
using System.IO;
using System.Threading;
using FileIntegrator;
using Ninject;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            var kernel = new StandardKernel(new FileIntegratorModule());

            Directory.CreateDirectory(@"f:\temporary_directory_to_delete");

            var filename = string.Format("{0}.txt", Guid.NewGuid());
            var path = string.Format(@"f:\temporary_directory_to_delete\{0}", filename);

            var consumer = kernel.Get<IFileConsumer>();

            using (var watcher = kernel.Get<IFileWatcherProducer>())
            {
                watcher.Start(@"f:\temporary_directory_to_delete");
                consumer.Start();

                while (true)
                {
                    File.WriteAllText(path, "some contents");

                    Thread.Sleep(500);

                    File.Delete(path);

                    if (Console.KeyAvailable) break;
                }
            }


            Directory.Delete(@"f:\temporary_directory_to_delete", true);
        }
    }
}