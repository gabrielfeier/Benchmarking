``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3110.0


```
|              Method |          Mean |      Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |--------------:|-----------:|-----------:|-------:|----------:|
| StringConcatenation |     0.0488 ns |  0.0333 ns |  0.0311 ns |      - |       0 B |
| StringInterpolation |   412.6914 ns |  2.2962 ns |  2.1479 ns | 0.0734 |     232 B |
|    XElementToString | 1,753.0497 ns | 14.2281 ns | 13.3089 ns | 4.5853 |   14477 B |
|       XmlSerializer | 9,083.1232 ns | 68.0330 ns | 63.6381 ns | 5.4626 |   17220 B |
