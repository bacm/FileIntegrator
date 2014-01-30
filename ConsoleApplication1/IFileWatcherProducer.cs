using System;

namespace ConsoleApplication1
{
    public interface IFileWatcherProducer : IDisposable
    {
        void Start(string path);
    }
}