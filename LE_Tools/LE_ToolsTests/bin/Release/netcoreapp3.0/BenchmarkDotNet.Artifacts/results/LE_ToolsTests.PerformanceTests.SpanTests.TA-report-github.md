``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|         Method |        Mean |     Error |     StdDev |      Median |
|--------------- |------------:|----------:|-----------:|------------:|
|        Channge | 308.4726 ns | 2.3035 ns |  2.1547 ns | 308.3247 ns |
| StaticProperty | 321.8949 ns | 6.5304 ns | 12.2656 ns | 317.4331 ns |
|     SafeChange | 323.7574 ns | 7.0100 ns | 16.5233 ns | 316.7792 ns |
|  BeforeChannge |   0.9213 ns | 0.0422 ns |  0.0374 ns |   0.9157 ns |
|            Add | 307.2919 ns | 1.9530 ns |  1.6309 ns | 306.7836 ns |
|         AddInt | 314.5736 ns | 3.8513 ns |  3.2160 ns | 315.1451 ns |
