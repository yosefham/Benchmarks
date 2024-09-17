using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public record IntWrapper(int Value);

[MemoryDiagnoser]
public class FindOrFirstBenchmarks
{
    private readonly List<int> _numbers = Enumerable.Range(0, 1000).ToList();
    private readonly List<IntWrapper> _wrapperNumbers = Enumerable.Range(0, 1000).Select(x => new IntWrapper(x)).ToList();

    [Benchmark]
    public int FindRaw()
    {
        return _numbers.Find(x => x == 500);
    }
    
    [Benchmark]
    public int FirstOrDefaultRaw()
    {
        return _numbers.FirstOrDefault(x => x == 500);
    }
    
    [Benchmark]
    public IntWrapper? FindWrapped()
    {
        return _wrapperNumbers.Find(x => x.Value == 500);
    }
    
    [Benchmark]
    public IntWrapper? FirstOrDefaultWrapped()
    {
        return _wrapperNumbers.FirstOrDefault(x => x.Value == 500);
    }
    // [Benchmark]
    // public void First()
    // {
    //     var value = _array.First(x => x == 4);
    // }
}
