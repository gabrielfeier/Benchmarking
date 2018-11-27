using System;
using System.Globalization;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace HowToBenchmark
{
    [MemoryDiagnoser]
    public class BenchmarkParseTime
    {
        public int Loop { get; set; }

        public string MaskWithoutMilliseconds = "HH:mm:ss";

        public string MaskWithMilliseconds = "HH:mm:ss:fffffff";


        [Benchmark]
        public DateTime TryParseExact_ThenParseExact()
        {
            var time = DateTime.MinValue;
            var values = new[] { "10:29:59", "10:29:59.9999999" };
            foreach (var value in values)
            {
                for (var i = 0; i < Loop; i++)
                {
                    if (!DateTime.TryParseExact(value, MaskWithoutMilliseconds, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out time))
                        time = DateTime.ParseExact(value, MaskWithMilliseconds, CultureInfo.InvariantCulture,
                            DateTimeStyles.None);
                }
            }

            return time;
        }

        [Benchmark]
        public DateTime CalculateLength()
        {
            var time = DateTime.MinValue;
            var values = new[] { "10:29:59", "10:29:59.9999999" };
            foreach (var value in values)
            {
                for (var i = 0; i < Loop; i++)
                {
                    switch (value.Length)
                    {
                        case 8:
                            time = DateTime.ParseExact(value, MaskWithoutMilliseconds, CultureInfo.InvariantCulture);
                            break;
                        default:
                            time = DateTime.ParseExact(value, MaskWithMilliseconds, CultureInfo.InvariantCulture,
                                DateTimeStyles.None);
                            break;
                    }

                }
            }

            return time;
        }

        [Benchmark]
        public DateTime Regex()
        {
            var time = DateTime.MinValue;
            var values = new[] { "10:29:59", "10:29:59.9999999" };
            foreach (var value in values)
            {
                for (var i = 0; i < Loop; i++)
                {
                    var regex = new Regex(@"(^\d{1,2})\:(\d{1,2})\:(\d{1,2})(\.(\d+))?$");
                    var match = regex.Match(value);
                    if (!match.Success)
                        throw new Exception("");

                    switch (match.Groups.Count)
                    {
                        case 4:
                            time = DateTime.ParseExact(value, MaskWithoutMilliseconds, CultureInfo.InvariantCulture);
                            break;
                        case 5:
                            time = DateTime.ParseExact(value, MaskWithoutMilliseconds, CultureInfo.InvariantCulture);
                            break;
                        default:
                            time = DateTime.ParseExact(value, MaskWithMilliseconds, CultureInfo.InvariantCulture, DateTimeStyles.None);
                            break;
                    }
                }
            }

            return time;
        }
    }
}