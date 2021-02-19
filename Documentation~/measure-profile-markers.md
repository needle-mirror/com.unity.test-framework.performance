# Measure.ProfilerMarkers()

Used to record profiler markers. Profiler marker timings are recorded automatically and sampled within the scope of the `using` statement. Names should match profiler marker labels. Profiler markers are sampled once per frame. Sampling the same profiler marker per frame will result in the sum of all invocations. Note that deep and editor profiling is not available. Profiler markers created using `Profiler.BeginSample()` are not supported, switch to `ProfilerMarker` if possible. 

#### Example: Measuring profiler markers in a scope

``` csharp
[Test, Performance]
public void Test()
{
    string[] markers =
    {
        "Instantiate",
        "Instantiate.Copy",
        "Instantiate.Produce",
        "Instantiate.Awake"
    };

    using(Measure.ProfilerMarkers(markers))
    {
        ...
    }
}
```
