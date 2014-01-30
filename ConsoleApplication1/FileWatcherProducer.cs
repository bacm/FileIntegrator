using System.IO;

namespace ConsoleApplication1
{
    public class FileWatcherProducer : IFileWatcherProducer
    {
        private readonly IObservableSyncronizedQueue _queue;
        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();

        public FileWatcherProducer(IObservableSyncronizedQueue queue)
        {
            _queue = queue;
            _watcher.Created += WatcherOnCreated;
        }

        public void Dispose()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }

        public void Start(string path)
        {
            _watcher.Path = path;
            _watcher.EnableRaisingEvents = true;
        }

        private void WatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            _queue.Enqueue(e.FullPath);
        }
    }
}