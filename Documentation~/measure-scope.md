# Measure.Scope(string name = "Time")

Measures execution time for the scope as a single time, for both synchronous and coroutine methods. Passing the name argument overrides the name of the created SampleGroup.

#### Example: Measuring a scope; execution time is measured for everything in the using statement

``` csharp
[Test, Performance]
public void Test()
{
    using(Measure.Scope())
    {
        ...
    }
}
```
