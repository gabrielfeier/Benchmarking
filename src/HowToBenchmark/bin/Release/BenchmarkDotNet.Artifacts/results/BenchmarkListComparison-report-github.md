``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.1088)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
Frequency=3215219 Hz, Resolution=311.0208 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0


```
|             Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------------- |---------:|----------:|----------:|-------:|----------:|
|    ScrambledEquals | 1.568 us | 0.0052 us | 0.0046 us | 0.2918 |     920 B |
| EnumerableSolution | 1.472 us | 0.0049 us | 0.0046 us | 0.2785 |     880 B |
