using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class BenchmarkConvertEnumV2
    {
        internal enum ErrorCodeV2
        {
            First = 1,
            Second,
            Third,
            Fourth,
            Fifth,
            UnknownError
        }

        private const int Loop = 1000;

        [Benchmark]
        public void IsDefinedWithIntTryParse()
        {
            for (var i = 0; i < Loop; i++)
            {
                var text = "1";

                var errorCodeText = Enum.IsDefined(typeof(ErrorCodeV2), text)
                    ? (ErrorCodeV2)ConvertToInt(text, (int)ErrorCodeV2.UnknownError)
                    : ErrorCodeV2.UnknownError;
            }
        }

        [Benchmark]
        public void TryParse()
        {
            for (var i = 0; i < Loop; i++)
            {
                var text = "1";
                var errorCodeText = Enum.TryParse(text, out ErrorCodeV2 result) ? result : ErrorCodeV2.UnknownError;
            }
        }

        public int ConvertToInt(string text, int defaultValue)
        {
            return !int.TryParse(text, out var result) ? defaultValue : result;
        }

        //private readonly HashSet<int> _values = new HashSet<int>((int[])Enum.GetValues(typeof(ErrorCodeV2)));

        [Benchmark]
        public void GetValues()
        {
            var _values = ((int[]) Enum.GetValues(typeof(ErrorCodeV2))).Select(_ => _.ToString()).ToList();
            for (var i = 0; i < Loop; i++)
            {
                ErrorCodeV2 errorCodeText;
                var text = "1";
                //if (!int.TryParse(text, out var result))
                //{
                //    errorCodeText = ErrorCodeV2.UnknownError;
                //    continue;
                //}

                errorCodeText = _values.Contains(text)
                   ? (ErrorCodeV2)int.Parse(text)
                   : ErrorCodeV2.UnknownError;
            }
        }
    }
}