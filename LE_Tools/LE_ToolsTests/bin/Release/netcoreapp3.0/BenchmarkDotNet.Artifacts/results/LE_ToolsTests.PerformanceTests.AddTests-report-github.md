``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|    Method |     Mean |     Error |    StdDev |   Median |
|---------- |---------:|----------:|----------:|---------:|
|   ByteAdd | 635.9 ns | 14.945 ns | 19.952 ns | 633.7 ns |
|  ByteAdd2 | 579.4 ns | 11.564 ns | 16.211 ns | 572.7 ns |
|  ShortAdd | 624.5 ns |  9.902 ns |  9.263 ns | 625.6 ns |
| UShortAdd | 596.9 ns | 10.003 ns |  9.357 ns | 597.2 ns |
|    IntAdd | 640.2 ns | 12.802 ns | 34.611 ns | 629.0 ns |
|   UIntAdd | 315.4 ns |  4.877 ns |  4.562 ns | 316.9 ns |
|   LongAdd | 617.7 ns | 11.711 ns | 10.954 ns | 619.3 ns |
|  ULongAdd | 318.9 ns |  6.302 ns | 11.038 ns | 318.0 ns |
