using System.Collections.Specialized;

namespace FileIntegrator.Interfaces
{
    public interface IObservableSyncronizedQueue
    {
        NotifyCollectionChangedEventHandler ElementAdded { get; set; }

        void Enqueue(string file);

        string Dequeue();
    }
}