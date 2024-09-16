using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class StringBenchmarks
{
    private static readonly IEnumerable<string> ListStrings = Enumerable.Range(0, 10000).Select(x => new Guid().ToString());


    [Benchmark]
    public void StringImplicitPlus()
    {
        string sum = "Hello, World!";
        foreach (var str in ListStrings)
        {
            sum += str;
        }
    }

    [Benchmark]
    public void StringBuilder()
    {
        var sb = new StringBuilder();
        sb.Append("Hello, World!");
        foreach (var s in ListStrings)
        {
            sb.Append(s);
        }
        string sum = sb.ToString();
    }

    [Benchmark]
    public void StringJoin()
    {
        var sum = "Hello, World!" + string.Join("", ListStrings);
    }
}