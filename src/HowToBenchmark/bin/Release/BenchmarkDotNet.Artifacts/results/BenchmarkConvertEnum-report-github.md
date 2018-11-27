``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10.0.17134
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0


```
|                                            Method |     Mean |     Error |    StdDev |   Gen 0 | Allocated |
|-------------------------------------------------- |---------:|----------:|----------:|--------:|----------:|
|                                         IsDefined | 113.2 us | 0.4429 us | 0.4143 us |  7.5684 |  23.44 KB |
|                               IsDefinedWithMethod | 245.1 us | 0.8223 us | 0.7289 us | 22.4609 |  70.32 KB |
|                                          TryParse | 388.2 us | 2.2942 us | 2.0337 us | 32.7148 | 101.56 KB |
| TryParseExtensionMethodWithEnumToObjectWithTypeof | 245.7 us | 0.5044 us | 0.4471 us | 22.4609 |  70.32 KB |
|           TryParseExtensionMethodWithEnumToObject | 257.1 us | 1.8473 us | 1.7280 us | 30.2734 |  93.76 KB |
|              TryParseExtensionMethodWithEnumParse | 531.2 us | 3.8773 us | 3.6268 us | 40.0391 | 125.02 KB |
|               TryParseExtensionMethodWithTryParse | 383.3 us | 3.3295 us | 3.1144 us | 32.7148 | 101.56 KB |
|                        TryParseExtensionMethodInt | 236.3 us | 0.9977 us | 0.9333 us | 22.7051 |  70.32 KB |
