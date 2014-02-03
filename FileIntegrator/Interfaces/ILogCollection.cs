using System.Collections.Generic;
using System.Collections.ObjectModel;
using FileIntegrator.States;

namespace FileIntegrator.Interfaces
{
    public interface ILogCollection
    {
        void Append(IIntegrationState currentState);
    }

    public class LogCollection : ILogCollection
    {
        private readonly ICollection<Log> _logs = new Collection<Log>();

        public void Append(IIntegrationState currentState)
        {
            _logs.Add(new Log {Step = currentState.IntegratorStep});
        }
    }
}