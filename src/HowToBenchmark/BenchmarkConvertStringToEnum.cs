using System;
using BenchmarkDotNet.Attributes;

namespace HowToBenchmark
{
    [MemoryDiagnoser]

    public class BenchmarkConvertStringToEnum
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
        public void ToStringD()
        {
            for (var i = 0; i < Loop; i++)
            {
                var errorCodeText = ToStringD(ErrorCodeV2.Fifth, ErrorCodeV2.First);
            }
        }

        [Benchmark]
        public void UseCastToInt()
        {
            for (var i = 0; i < Loop; i++)
            {
                var errorCodeText = UseCastToInt(ErrorCodeV2.Fifth, ErrorCodeV2.First);
            }
        }

        internal string ToStringD(ErrorCodeV2 value, ErrorCodeV2 defaultValue)
        {
            return Enum.IsDefined(typeof(ErrorCodeV2), value)
                ? value.ToString("D")
                : defaultValue.ToString("D");
        }

        internal string UseCastToInt(ErrorCodeV2 value, ErrorCodeV2 defaultValue)
        {
            return Enum.IsDefined(typeof(ErrorCodeV2), value)
                ? ((int)value).ToString()
                : ((int)defaultValue).ToString();
        }
    }
}