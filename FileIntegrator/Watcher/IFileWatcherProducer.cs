using System;

namespace FileIntegrator.Watcher
{
    public interface IFileWatcherProducer : IDisposable
    {
        void Start(string path);
    }
}