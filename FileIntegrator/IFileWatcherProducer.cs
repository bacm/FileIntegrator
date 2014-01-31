using System;

namespace FileIntegrator
{
    public interface IFileWatcherProducer : IDisposable
    {
        void Start(string path);
    }
}