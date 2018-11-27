``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3132.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3132.0


```
|                   Method |      Mean |     Error |    StdDev |   Gen 0 | Allocated |
|------------------------- |----------:|----------:|----------:|--------:|----------:|
| IsDefinedWithIntTryParse |  78.53 us | 0.3671 us | 0.3434 us |       - |       0 B |
|                 TryParse | 373.29 us | 1.3537 us | 1.1304 us | 22.4609 |   72001 B |
|                GetValues |  98.03 us | 0.3587 us | 0.3180 us |  0.1221 |     633 B |
