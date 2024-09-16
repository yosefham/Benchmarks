using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class ForVsForEach
{
    private readonly int[] _array = Enumerable.Range(0, 1000).ToArray();

    [Benchmark]
    public void ForEach()
    {
        foreach (var i in _array)
        {
            if (i == 400)
                return;
        }
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < _array.Length; i++)
        {
           if(_array[i] == 400)
               return;
        }
    }
}