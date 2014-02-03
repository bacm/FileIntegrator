using FileIntegrator.Interfaces;

namespace FileIntegrator.States
{
    public class AnalysisState : IIntegrationState
    {
        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.Analysis; }
        }

        public IIntegrationState NextState()
        {
            return new IntegrationEndedState();
        }

        public void Execute(IntegratedFile file)
        {
            OberthurFileIntegratorEventSource.Log.AnalysisDone(_file.Filepath);
        }
    }
}