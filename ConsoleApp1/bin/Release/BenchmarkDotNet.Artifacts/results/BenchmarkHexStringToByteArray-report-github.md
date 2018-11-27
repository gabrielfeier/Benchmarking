``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-6200U CPU 2.30GHz (Skylake), 1 CPU, 4 logical cores and 2 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0  [AttachedDebugger]
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0


```
|                      Method |        Mean |        Error |      StdDev |      Median |      Gen 0 |   Allocated |
|---------------------------- |------------:|-------------:|------------:|------------:|-----------:|------------:|
|                   UsingLinq |  2,775.2 us |   122.916 us |   362.42 us |  2,773.9 us |   316.4063 |   488.64 KB |
| ConvertHexStringToByteArray |  2,227.4 us |    63.530 us |   186.32 us |  2,216.5 us |   222.6563 |   348.02 KB |
|              StrToByteArray | 51,972.4 us | 1,498.834 us | 4,276.26 us | 51,333.4 us | 13562.5000 | 20901.83 KB |
|    StringToByteArrayFastest |    172.0 us |     6.815 us |    19.44 us |    164.1 us |    22.9492 |    35.51 KB |
