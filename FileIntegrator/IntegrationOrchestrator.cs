using System;

namespace FileIntegrator
{
    public class IntegrationOrchestrator : IIntegrationOrchestrator
    {
        private readonly ILogCollection _collection;
        private readonly IIntegrationStateFactory _factory;

        public IntegrationOrchestrator(IIntegrationStateFactory factory, ILogCollection collection)
        {
            _factory = factory;
            _collection = collection;
        }

        public void Start(string filepath)
        {
            var currentState = _factory.Start(filepath);

            try
            {
                do
                {
                    _collection.Append(currentState);
                    currentState = currentState.NextState();
                } while (currentState.IntegratorStep != EIntegratorStep.ProcessingEndedSuccessfully);
            }
            catch (StateException se)
            {
            }
            catch (Exception ex)
            {
                // check 
                // http://msdn.microsoft.com/en-us/library/dn440728(v=pandp.60).aspx
            }
        }
    }
}