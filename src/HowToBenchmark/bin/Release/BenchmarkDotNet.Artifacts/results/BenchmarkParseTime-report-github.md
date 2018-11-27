``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|                       Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------------------- |---------:|----------:|----------:|-------:|----------:|
| TryParseExact_ThenParseExact | 14.90 ns | 0.2586 ns | 0.2419 ns | 0.0127 |      40 B |
|              CalculateLength | 13.68 ns | 0.1841 ns | 0.1722 ns | 0.0127 |      40 B |
|                        Regex | 14.11 ns | 0.0677 ns | 0.0565 ns | 0.0127 |      40 B |
