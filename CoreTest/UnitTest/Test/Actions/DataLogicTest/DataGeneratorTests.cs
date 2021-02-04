using NUnit.Framework;

namespace Core.UnitTest.Test.Data
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DataGeneratorTests : BaseFixture
    {
        [Test]
        public void GenerateString_Successful()
        {
            string result = DataGenerator.GenerateString(10);
            result.Length.AreEqual(10);
        }

        [Test]
        public void GenerateInt_Successful()
        {
            string result = DataGenerator.GenerateString(10, true);
            result.Length.AreEqual(10);
        }

    }
}
