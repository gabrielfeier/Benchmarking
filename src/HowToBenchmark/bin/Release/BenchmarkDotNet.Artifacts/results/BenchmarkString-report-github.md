``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.1088)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
Frequency=3215219 Hz, Resolution=311.0208 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2650.0


```
|              Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |----------:|----------:|----------:|-------:|----------:|
| StringConcatenation |  33.38 ns | 0.3396 ns | 0.3011 ns | 0.0228 |      72 B |
| StringInterpolation | 116.20 ns | 0.8138 ns | 0.7612 ns | 0.0126 |      40 B |
