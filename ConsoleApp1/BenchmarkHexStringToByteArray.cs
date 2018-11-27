using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    [MemoryDiagnoser]
    public class BenchmarkHexStringToByteArray
    {
        private const string HexString = "AC0105E92ED496ACD373D7496B76C1C8";
        private const int Loop = 1000;

        [Benchmark]
        public List<byte[]> UsingLinq()
        {
            var list = new List<byte[]>();
            LoopAction(() =>
            {
                var hexConverted = Enumerable.Range(0, HexString.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x =>
                        Convert.ToByte(HexString.Substring(x, 2), 16))
                    .ToArray();

                list.Add(hexConverted);
            });

            return list;
        }

        [Benchmark]
        public List<byte[]> ConvertHexStringToByteArray()
        {
            var list = new List<byte[]>();
            LoopAction(() =>
            {
                if (HexString.Length % 2 != 0)
                {
                    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture,
                        "The binary key cannot have an odd number of digits: {0}", HexString));
                }

                byte[] data = new byte[HexString.Length / 2];
                for (int index = 0; index < data.Length; index++)
                {
                    string byteValue = HexString.Substring(index * 2, 2);
                    data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }

                list.Add(data);
            });

            return list;
        }

        [Benchmark]
        public List<byte[]> StrToByteArray()
        {
            var list = new List<byte[]>();
            LoopAction(() =>
            {
                Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
                for (int i = 0; i <= 255; i++)
                    hexindex.Add(i.ToString("X2"), (byte)i);

                List<byte> hexres = new List<byte>();
                for (int i = 0; i < HexString.Length; i += 2)
                    hexres.Add(hexindex[HexString.Substring(i, 2)]);

                list.Add(hexres.ToArray());
            });

            return list;
        }

        [Benchmark]
        public List<byte[]> StringToByteArrayFastest()
        {
            var list = new List<byte[]>();
            LoopAction(() =>
            {
                if (HexString.Length % 2 == 1)
                    throw new Exception("The binary key cannot have an odd number of digits");

                var arr = new byte[HexString.Length >> 1];

                for (var i = 0; i < HexString.Length >> 1; ++i)
                {
                    arr[i] = (byte)((GetHexVal(HexString[i << 1]) << 4) + (GetHexVal(HexString[(i << 1) + 1])));
                }

                list.Add(arr);
            });

            return list;
        }


        public int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public void LoopAction(Action action)
        {
            for (var i = 0; i < Loop; i++)
            {
                action();
            }
        }
    }
}