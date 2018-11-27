``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 2 [1703, Creators Update] (10.0.15063.877)
Intel Core i5-4590 CPU 3.30GHz (Haswell), 1 CPU, 4 logical cores and 4 physical cores
Frequency=3215218 Hz, Resolution=311.0209 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2115.0


```
| Method |     Mean |     Error |    StdDev |
|------- |---------:|----------:|----------:|
| Sha256 | 93.94 us | 0.9085 us | 0.8498 us |
|    Md5 | 21.85 us | 0.3023 us | 0.2827 us |
