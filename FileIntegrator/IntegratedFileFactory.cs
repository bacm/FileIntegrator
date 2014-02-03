using FileIntegrator.Interfaces;

namespace FileIntegrator
{
    public class IntegratedFileFactory : IIntegratedFileFactory
    {
        public IntegratedFile Create(string filepath)
        {
            return new IntegratedFile {Filepath = filepath};
        }
    }
}