using FileIntegrator;
using FileIntegrator.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var state = new CheckFileNameState(new IntegratedFile());
            state.Execute();
        }
    }
}