``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3132.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3132.0


```
|       Method |     Mean |     Error |    StdDev |   Gen 0 | Allocated |
|------------- |---------:|----------:|----------:|--------:|----------:|
|    ToStringD | 362.3 us | 0.9715 us | 0.8612 us | 40.5273 | 125.01 KB |
| UseCastToInt | 315.0 us | 1.0153 us | 0.9000 us | 25.3906 |  78.13 KB |
