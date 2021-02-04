using NUnit.Framework;
using Serilog;

namespace CoreTest.UnitTest.Test.Common
{
    [TestFixture]
    class ElasticLogTest
    {
        [Test]
        public void ElasticLog_LogInformation_Successfully() {
            Log.Logger = Logging.GetElasticSearchConfig("http://localhost:9200").CreateLogger();
            Log.Information("ZXCV");
            Log.CloseAndFlush();
        }
    }
}
