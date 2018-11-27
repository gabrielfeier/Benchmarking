``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|                      Method |        Mean |      Error |     StdDev |     Gen 0 |   Allocated |
|---------------------------- |------------:|-----------:|-----------:|----------:|------------:|
|                   UsingLinq |  1,394.8 us |  18.873 us |  17.654 us |  253.9063 |   781.95 KB |
| ConvertHexStringToByteArray |  1,434.7 us |   7.707 us |   7.209 us |  179.6875 |   555.39 KB |
|              StrToByteArray | 28,517.1 us | 564.544 us | 713.968 us | 9875.0000 | 30488.28 KB |
|    StringToByteArrayFastest |    111.4 us |   1.081 us |   1.011 us |   17.9443 |    55.38 KB |
