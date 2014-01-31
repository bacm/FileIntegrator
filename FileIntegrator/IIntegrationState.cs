namespace FileIntegrator
{
    public interface IIntegrationState
    {
        EIntegratorStep IntegratorStep { get; }

        IIntegrationState NextState();
    }
}