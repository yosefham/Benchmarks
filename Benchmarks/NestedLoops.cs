using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class NestedLoops
{

    [Benchmark]
    public void IntVersion()
    {
        int u = new Random(DateTime.UtcNow.Second).Next();
        int rand = new Random(DateTime.UtcNow.Millisecond).Next();
        int r = rand % 1000;
        Span<int> a = stackalloc int[10_000];

        for (int i = 0; i < 10_000; i++)
        {
            for (int j = 0; j < 100_000; j++)
            {
                a[i] = a[i] + j % u;
            }
            a[i] += r;
        }
        Console.WriteLine(a[r]);
    }

    [Benchmark]
    public void DoubleVersion()
    {
        double u = new Random(DateTime.UtcNow.Second).Next();
        double rand = new Random(DateTime.UtcNow.Millisecond).Next();
        double r = rand % 1000;
        Span<int> a = stackalloc int[10_000];

        for (int i = 0; i < 10_000; i++)
        {
            for (int j = 0; j < 100_000; j++)
            {
                a[i] = a[i] + j % (int)u;
            }
            a[i] += (int)r;
        }
        Console.WriteLine(a[(int)r]);
    }

    [Benchmark]
    public void DoubleExtended()
    {
        int u = new Random(DateTime.UtcNow.Second).Next();
        int rand = new Random(DateTime.UtcNow.Millisecond).Next();
        int r = rand % 1000;
        Span<int> a = stackalloc int[10_000];

        for (int i = 0; i < 10_000; i++)
        {
            for (int j = 0; j < 100_000; j++)
            {
                double q = j / (double)u;
                q = Math.Truncate(q);
                double remainder = j - u * q;
                a[i] = a[i] + (int)remainder;
            }
            a[i] += r;
        }
        Console.WriteLine(a[r]);
    }

    // [Benchmark]
    // public void DecimalVersion()
    // {
    //     int u = new Random(DateTime.UtcNow.Second).Next();
    //     int rand = new Random(DateTime.UtcNow.Millisecond).Next();
    //     int r = rand % 1000;
    //     Span<int> a = stackalloc int[10_000];
    //
    //     for (int i = 0; i < 10000; i++)
    //     {
    //         for (int j = 0; j < 10000; j++)
    //         {
    //             decimal q = j / (decimal)u;
    //             q = Math.Truncate(q);
    //             decimal remainder = j - u * q;
    //             a[i] = a[i] + (int)remainder;
    //         }
    //         a[i] += r;
    //     }
    //     Console.WriteLine(a[r]);
    // }
}
