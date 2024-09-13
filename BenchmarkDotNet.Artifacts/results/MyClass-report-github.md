```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
12th Gen Intel Core i7-12800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.401
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method             | Mean         | Error       | StdDev       | Gen0        | Gen1        | Gen2        | Allocated  |
|------------------- |-------------:|------------:|-------------:|------------:|------------:|------------:|-----------:|
| StringImplicitPlus | 418,568.1 μs | 8,510.40 μs | 25,093.11 μs | 965000.0000 | 962000.0000 | 962000.0000 | 3436.29 MB |
| StringBuilder      |     549.6 μs |    10.97 μs |     30.41 μs |    199.2188 |    199.2188 |    199.2188 |     2.3 MB |
| StringJoin         |     488.0 μs |     9.15 μs |     18.27 μs |    396.4844 |    319.8242 |    319.8242 |    2.29 MB |
