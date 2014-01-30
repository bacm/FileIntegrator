namespace ConsoleApplication1
{
    public interface IIntegrationState
    {
        EIntegratorStep IntegratorStep { get; }

        IIntegrationState NextState();
    }
}