using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using FileIntegrator;
using FileIntegrator.Consumer;
using FileIntegrator.Interfaces;
using FileIntegrator.Watcher;
using FileIntegratorWorkFlow;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Ninject;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            Watcher();
        }

        static void WF()
        {
            var syncEvent = new AutoResetEvent(false);

            var inputs = new Dictionary<string, object> { { "Filepath", @"C:\Users\Bruno\Watcher\KNR1673.ext" } };

            var wfApp = new WorkflowApplication(new Activity1(), inputs)
            {
                Completed = e => syncEvent.Set(),
                Aborted = delegate(WorkflowApplicationAbortedEventArgs e)
                {
                    Console.WriteLine(e.Reason);
                    syncEvent.Set();
                },
                OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
                {
                    Console.WriteLine(e.UnhandledException.ToString());
                    return UnhandledExceptionAction.Terminate;
                }
            };

            wfApp.Run();

            syncEvent.WaitOne();
        }

        static void Watcher()
        {
            const string folder = @"C:\Users\Bruno\Watcher";

            var listener = new ObservableEventListener();

            listener.EnableEvents(
                OberthurFileIntegratorEventSource.Log,
                EventLevel.LogAlways,
                Keywords.All);

            listener.LogToConsole();
            //listener.LogToSqlDatabase("Integrator", "Server=(local);Database=SemanticLogging;Trusted_Connection=True;");

            //var listener = SqlDatabaseLog.CreateListener("Integrator",
            //                              "Server=(local);Database=SemanticLogging;Trusted_Connection=True;");
            //listener.EnableEvents(
            //    OberthurFileIntegratorEventSource.Log, 
            //    EventLevel.LogAlways, 
            //    OberthurFileIntegratorEventSource.Keywords.Integrator);

            var kernel = new StandardKernel(new FileIntegratorModule());

            var consumer = kernel.Get<IFileConsumer>();

            var config = ConfigurationSourceFactory.Create();
            var factory = new ExceptionPolicyFactory(config);
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());

            Logger.SetLogWriter(new LogWriterFactory().Create());
            ExceptionPolicy.SetExceptionManager(factory.CreateManager());

            var start = kernel.Get<>()

            using (var watcher = kernel.Get<IFileWatcherProducer>())
            {
                watcher.Start(folder);
                Console.WriteLine(@"watcher started");

                consumer.Start();
                Console.WriteLine(@"consumer started");

                Console.ReadLine();

                consumer.Stop();
            }

            listener.DisableEvents(OberthurFileIntegratorEventSource.Log);
        }
    }
}