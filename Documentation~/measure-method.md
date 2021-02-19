# Measure.Method()

Executes the provided method, sampling performance using the following additional properties/methods to control how the measurements are taken:
* **WarmupCount(int n)** - number of times to execute before measurements are collected. If unspecified, a default warmup is executed for 100 ms or until at least 3 method executions have completed, whichever is longer.
* **MeasurementCount(int n)** - number of measurements to capture, defaults to 9 if not specified.
* **IterationsPerMeasurement(int n)** - number of method executions per measurement to use. If this value is not specified, the method is executed as many times as possible until approximately 100 ms has elapsed.
* **SampleGroup(string name)** - name of the measurement, defaults to "Time" if unspecified.
* **GC()** - if specified, measures the total number of Garbage Collection allocation calls.
* **SetUp(Action action)** - is called every iteration before method execution. Setup time is not measured.
* **CleanUp(Action action)** - is called every iteration after method execution. Cleanup time is not measured.


#### Example 1: Simple method measurement using default values

``` csharp
[Test, Performance]
public void Test()
{
    Measure.Method(() => { ... }).Run();
}
```

#### Example 2: Customize Measure.Method properties

```
[Test, Performance]
public void Test()
{
    Measure.Method(() => { ... })
        .WarmupCount(10)
        .MeasurementCount(10)
        .IterationsPerMeasurement(5)
        .GC()
        .SetUp(()=> {/*setup code*/})
        .CleanUp(()=> {/*cleanup code*/})
        .Run();
}
```
