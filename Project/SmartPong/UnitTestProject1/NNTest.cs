using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPong.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class NNTest
    {
        [TestMethod]
        public void nntest()
        {
            NeuralNetwork nn = new NeuralNetwork();
            nn.Run(2, 3, () => Assert.IsTrue(true), () => Assert.IsTrue(false));
            nn.Run(3, 2, () => Assert.IsTrue(false), () => Assert.IsTrue(true));
            nn.Run(3, 3, () => Assert.IsTrue(true), () => Assert.IsTrue(true));
        }
    }
}
