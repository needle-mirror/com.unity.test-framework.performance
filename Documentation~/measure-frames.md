# Measure.Frames()

Records time per frame by default and provides additional properties/methods to control how the measurements are taken:
* **WarmupCount(int n)** - number of times to execute before measurements are collected. If unspecified, a default warmup is executed for 80 ms or until at least 3 full frames have rendered, whichever is longest.
* **MeasurementCount(int n)** - number of frames to capture measurements for. If this value is not specified, as many frames as possible are captured until approximately 500 ms has elapsed.
* **DontRecordFrametime()** - disables frametime measurement.
* **ProfilerMarkers(...)** - sample profile markers per frame. Does not work for deep profiling and `Profiler.BeginSample()`
* **SampleGroup(string name)** - name of the measurement, defaults to "Time" if unspecified.
* **Scope()** - measures frame times in a given coroutine scope.


#### Example 1: Simple frame time measurement using default values of at least 7 frames and default WarmupCount (see description above).

``` csharp
[UnityTest, Performance]
public IEnumerator Test()
{
    ...

    yield return Measure.Frames().Run();
}
```

#### Example 2: Sample profile markers per frame, disable frametime measurement

If you'd like to sample profiler markers across multiple frames and don't need to record frametime, it is possible to disable the frame time measurement.

``` csharp
[UnityTest, Performance]
public IEnumerator Test()
{
    ...

    yield return Measure.Frames()
        .ProfilerMarkers(...)
        .DontRecordFrametime()
        .Run();
}
```

#### Example 3: Sample frame times in a scope

``` csharp
[UnityTest, Performance]
public IEnumerator Test()
{
    using (Measure.Frames().Scope())
    {
        yield return ...;
    }
}
```

#### Example 4: Specify custom WarmupCount and MeasurementCount per frame

If you want more control, you can specify how many frames you want to measure.

``` csharp
[UnityTest, Performance]
public IEnumerator Test()
{
    ...

    yield return Measure.Frames()
        .WarmupCount(5)
        .MeasurementCount(10)
        .Run();
}
```
