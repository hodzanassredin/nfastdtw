
using MathNet.Numerics.LinearAlgebra.Double;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace NFastdtw.Tests
{
    public class FastDtwTests
    {
        
        [Fact]
        public void ShouldCorrectlyCalculateDtw()
        {
            var data = JsonConvert.DeserializeObject<TestData>(File.ReadAllText("test.json"));
            //var result = new Fastdtw(data.x, data.y).GetCost();
            var result = new Fastdtw(data.x, data.y, (x, y) => (new DenseVector(x) - new DenseVector(y)).L2Norm()).GetCost();
            Assert.Equal(1.085367424306426, result);
        }
        private class TestData
        {
            public double[][] x { get; set; }
            public double[][] y { get; set; }
        }

    }


    
}