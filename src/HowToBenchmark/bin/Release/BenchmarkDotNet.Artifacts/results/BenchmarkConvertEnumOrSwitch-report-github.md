``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0


```
|                                        Method |       Mean |     Error |   StdDev |   Gen 0 | Allocated |
|---------------------------------------------- |-----------:|----------:|---------:|--------:|----------:|
|                  TryGetDictionaryValueToUpper |   873.4 us |  2.645 us | 2.474 us | 81.0547 |  256013 B |
| TryGetDictionaryValueWithDictionaryIgnoreCase | 2,078.3 us | 10.367 us | 9.698 us |       - |       0 B |
|                                    SwitchCase |   743.5 us |  3.523 us | 3.295 us | 81.0547 |  256013 B |
|                                        IfElse | 1,688.1 us |  5.814 us | 5.438 us |       - |       0 B |
