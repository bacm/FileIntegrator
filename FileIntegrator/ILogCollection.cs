using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FileIntegrator
{
    public interface ILogCollection
    {
        void Append(IIntegrationState currentState);
    }

    internal class LogCollection : ILogCollection
    {
        private readonly ICollection<Log> _logs = new Collection<Log>();

        public void Append(IIntegrationState currentState)
        {
            _logs.Add(new Log {Step = currentState.IntegratorStep});
        }
    }
}