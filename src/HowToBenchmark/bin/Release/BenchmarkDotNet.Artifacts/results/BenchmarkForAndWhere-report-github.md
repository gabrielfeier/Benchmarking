``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0


```
| Method |     Mean |    Error |   StdDev |  Gen 0 | Allocated |
|------- |---------:|---------:|---------:|-------:|----------:|
|    For | 343.1 ns | 4.665 ns | 4.363 ns | 0.0453 |     144 B |
|  Where | 443.4 ns | 2.519 ns | 2.103 ns | 0.1092 |     344 B |