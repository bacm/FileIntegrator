namespace FileIntegrator.Interfaces
{
    public interface IIntegrationState
    {
        EIntegratorStep IntegratorStep { get; }

        void Execute();

        IIntegrationState NextState();
    }
}