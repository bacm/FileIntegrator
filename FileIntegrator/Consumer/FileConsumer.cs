using System.Collections.Specialized;
using System.Threading;
using FileIntegrator.Interfaces;

namespace FileIntegrator.Consumer
{
    public class FileConsumer : IFileConsumer
    {
        private static readonly Semaphore Semaphore = new Semaphore(0, 500);
        private readonly IIntegrationOrchestrator _orchestrator;
        private readonly IObservableSyncronizedQueue _queue;
        private bool _stopConsumingRequested;

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

        public void Stop()
        {
            _stopConsumingRequested = true;
            Semaphore.Release();
        }

        private void Consume(object o)
        {
            while (true)
            {
                Semaphore.WaitOne();

                if (_stopConsumingRequested)
                {
                    return;
                }

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