using System;
using BenchmarkDotNet.Attributes;

namespace HowToBenchmark
{
    public enum ErrorCode
    {
        First = 1,
        Second,
        Third,
        Fourth,
        Fifth,
        UnknownError
    }

    [MemoryDiagnoser]
    public class BenchmarkConvertEnum
    {
        private const int Loop = 1000;

        [Benchmark]
        public void IsDefined()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = Enum.IsDefined(typeof(ErrorCode), code) ? (ErrorCode)code : ErrorCode.UnknownError;
            }
        }

        [Benchmark]
        public void IsDefinedWithMethod()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = ConvertToEnum(code, ErrorCode.UnknownError);
            }
        }

        private static T2 ConvertToEnum<T1, T2>(T1 value, T2 defaultValue)
        {
            return Enum.IsDefined(typeof(T2), value)
                ? (T2)Enum.ToObject(typeof(T2), value)
                : defaultValue;
        }

        [Benchmark]
        public void TryParse()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                if (!Enum.TryParse<ErrorCode>(code.ToString(), out var errorCode)) errorCode = ErrorCode.UnknownError;
            }
        }

        [Benchmark]
        public void TryParseExtensionMethodWithEnumToObjectWithTypeof()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = code.Parse1(ErrorCode.UnknownError);
            }
        }

        [Benchmark]
        public void TryParseExtensionMethodWithEnumToObject()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = code.Parse2(ErrorCode.UnknownError);
            }
        }

        [Benchmark]
        public void TryParseExtensionMethodWithEnumParse()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = code.Parse3(ErrorCode.UnknownError);
            }
        }

        [Benchmark]
        public void TryParseExtensionMethodWithTryParse()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = code.TryParse(ErrorCode.UnknownError);
            }
        }

        [Benchmark]
        public void TryParseExtensionMethodInt()
        {
            for (var i = 0; i < Loop; i++)
            {
                var code = 1;
                var errorCode = code.ParseToEnum(ErrorCode.UnknownError);
            }
        }
    }

    public static class EnumExtensions
    {
        public static T2 TryParse<T1, T2>(this T1 value, T2 defaultValue) where T2 : struct
        {
            return Enum.TryParse(value.ToString(), out T2 result)
                ? result
                : defaultValue;
        }
        public static T2 Parse1<T1, T2>(this T1 value, T2 defaultValue)
        {
            return Enum.IsDefined(typeof(T2), value)
                ? (T2)Enum.ToObject(typeof(T2), value)
                : defaultValue;
        }

        public static T2 Parse2<T1, T2>(this T1 value, T2 defaultValue)
        {
            return Enum.IsDefined(typeof(T2), value)
                ? (T2)Enum.ToObject(defaultValue.GetType(), value)
                : defaultValue;
        }

        public static T2 Parse3<T1, T2>(this T1 value, T2 defaultValue)
        {
            return Enum.IsDefined(typeof(T2), value)
                ? (T2)Enum.Parse(typeof(T2), value.ToString())
                : defaultValue;
        }
    }

    public static class IntExtensions
    {
        /// <summary>
        /// Parse an integer to a Enum.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Enum Default Value</param>
        /// <returns>Enum</returns>
        public static T ParseToEnum<T>(this int value, T defaultValue)
        {
            return System.Enum.IsDefined(typeof(T), value)
                ? (T)System.Enum.ToObject(defaultValue.GetType(), value)
                : defaultValue;
        }
    }
}