``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|    Method |     Mean |     Error |     StdDev |
|---------- |---------:|----------:|-----------:|
|   ByteAdd | 598.7 ns | 11.900 ns | 11.1314 ns |
|  ByteAdd2 | 613.9 ns | 12.549 ns | 30.0675 ns |
|  ShortAdd | 605.9 ns |  8.362 ns |  7.8223 ns |
| UShortAdd | 601.8 ns |  2.552 ns |  2.2621 ns |
|    IntAdd | 601.9 ns |  1.071 ns |  0.8364 ns |
|   UIntAdd | 307.0 ns |  2.469 ns |  2.1887 ns |
|   LongAdd | 313.4 ns |  6.273 ns |  5.5608 ns |
|  ULongAdd | 308.3 ns |  1.753 ns |  1.4642 ns |
