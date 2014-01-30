using System.Collections;
using System.Collections.Specialized;

namespace FileIntegrator
{
    // todo: Could other source, more robust
    public class ObservableSyncronizedQueue : IObservableSyncronizedQueue
    {
        private readonly Queue _queue = new Queue();

        public NotifyCollectionChangedEventHandler ElementAdded { get; set; }

        public void Enqueue(string file)
        {
            lock (_queue.SyncRoot)
            {
                _queue.Enqueue(file);

                if (ElementAdded != null)
                {
                    ElementAdded(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        public string Dequeue()
        {
            lock (_queue.SyncRoot)
            {
                return _queue.Dequeue() as string;
            }
        }
    }
}