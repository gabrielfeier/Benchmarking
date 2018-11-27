using System.Xml.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HowToBenchmark
{
    [MemoryDiagnoser]
    public class BenchmarkXml
    {
        private const string CarlinhosValue = "123";
        private const string CarlinhosValue7 = "123123123123123123123";

        [Benchmark]
        public string StringConcatenation()
        {
            return "<Carlos><Carlinhos>" + CarlinhosValue + CarlinhosValue + CarlinhosValue + CarlinhosValue + CarlinhosValue + CarlinhosValue + CarlinhosValue + "</Carlinhos></Carlos>";
        }

        [Benchmark]
        public string StringInterpolation()
        {
            return $"<Carlos><Carlinhos>{CarlinhosValue}{CarlinhosValue}{CarlinhosValue}{CarlinhosValue}{CarlinhosValue}{CarlinhosValue}{CarlinhosValue}</Carlinhos></Carlos>";
        }

        [Benchmark]
        public string XElementToString()
        {
            var xElement = new XElement("Carlos");
            xElement.Add(new XElement("Carlinhos", CarlinhosValue7));

            return xElement.ToString();
        }

        [Benchmark]
        public string XmlSerializer()
        {
            var carlosClass = new Carlos();
            return carlosClass.ToXml();
        }

        public class Carlos
        {
            public string Carlinhos { get; set; }
        }
    }
}