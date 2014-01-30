using System.Collections.Specialized;

namespace ConsoleApplication1
{
    public interface IObservableSyncronizedQueue
    {
        NotifyCollectionChangedEventHandler ElementAdded { get; set; }

        void Enqueue(string file);

        string Dequeue();
    }
}