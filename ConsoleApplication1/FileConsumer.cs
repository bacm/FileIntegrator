using System.Collections.Specialized;
using System.Threading;

namespace ConsoleApplication1
{
    public class FileConsumer : IFileConsumer
    {
        private static readonly Semaphore Semaphore = new Semaphore(0, 500);
        private readonly IObservableSyncronizedQueue _queue;
        private readonly IIntegrationOrchestrator _orchestrator;

        public FileConsumer(IObservableSyncronizedQueue queue, IIntegrationOrchestrator orchestrator)
        {
            _queue = queue;
            _orchestrator = orchestrator;
            _queue.ElementAdded += ElementAdded;
        }

        public void Start()
        {
            var thread = new Thread(Consume);
            thread.Start(new ParameterizedThreadStart(Consume));
        }

        private void Consume(object o)
        {
            while (true)
            {
                Semaphore.WaitOne();
                var item = _queue.Dequeue();

                _orchestrator.Start(item);
            }
        }

        private static void ElementAdded(object sender, NotifyCollectionChangedEventArgs e)
        {
            Semaphore.Release();
        }
    }
}