using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class FindOrFirstBenchmarks
{
    private readonly List<int> _array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    [Benchmark]
    public void Find()
    {
        var value = _array.Find(x => x == 4);
    }
    
    [Benchmark]
    public void FirstOrDefault()
    {
        var value = _array.FirstOrDefault(x => x == 4);
    }
    
    [Benchmark]
    public void First()
    {
        var value = _array.First(x => x == 4);
    }
}
