``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-6200U CPU 2.30GHz (Skylake), 1 CPU, 4 logical cores and 2 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3190.0


```
|                    Method |         Mean |      Error |    StdDev |  Gen 0 |  Gen 1 | Allocated |
|-------------------------- |-------------:|-----------:|----------:|-------:|-------:|----------:|
|                UsingMutex |     383.0 us |  11.668 us | 11.982 us | 2.4414 |      - |   3.96 KB |
| UsingConcurrentDictionary | 254,413.3 us | 100.323 us | 88.934 us |      - |      - |      3 KB |
|     UsingManualResetEvent |     118.6 us |   2.343 us |  2.301 us | 2.1973 | 0.4883 |   3.42 KB |
