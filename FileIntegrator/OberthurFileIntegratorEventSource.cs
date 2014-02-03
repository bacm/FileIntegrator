using System.Diagnostics.Tracing;

namespace FileIntegrator
{
    [EventSource(Name = "Oberthur - File integrator")]
    public class OberthurFileIntegratorEventSource : EventSource
    {
        private static readonly OberthurFileIntegratorEventSource _log =
            new OberthurFileIntegratorEventSource();

        private OberthurFileIntegratorEventSource()
        {
        }

        public static OberthurFileIntegratorEventSource Log
        {
            get { return _log; }
        }

        [Event(1, Message = "Starting up.",
            Keywords = Keywords.Integrator,
            Task = Tasks.Starting,
            Level = EventLevel.Informational)]
        internal void Startup()
        {
            WriteEvent(1);
        }

        [Event(2, Message = "Analysis done: {0}",
            Keywords = Keywords.Integrator,
            Task = Tasks.Analysis,
            Level = EventLevel.Informational)]
        internal void AnalysisDone(string file)
        {
            WriteEvent(2, file);
        }

        [Event(3, Message = "Name checked: {0}",
            Keywords = Keywords.Integrator,
            Task = Tasks.NameCheck,
            Level = EventLevel.Informational)]
        internal void NameChecked(string file)
        {
            WriteEvent(3, file);
        }

        [Event(4, Message = "File is now open: {0}",
            Keywords = Keywords.Integrator,
            Task = Tasks.FileOpen,
            Level = EventLevel.Informational)]
        public void ContentHasBeenRead(string file)
        {
            WriteEvent(4, file);
        }

        public class Keywords
        {
            public const EventKeywords Integrator = (EventKeywords) 1;
        }

        public class Tasks
        {
            public const EventTask Starting = (EventTask) 1;
            public const EventTask Analysis = (EventTask) 2;
            public const EventTask NameCheck = (EventTask) 4;
            public const EventTask FileOpen = (EventTask) 8;
        }
    }
}