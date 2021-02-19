using System.Threading;
using Unity.PerformanceTesting.Meters;
using NUnit.Framework;
using Unity.PerformanceTesting;
using Unity.PerformanceTesting.Measurements;

public class MeasureMethodTests
{
    [Test, Performance]
    public void MeasureMethod_With_NoArguments()
    {
        var call_count = 0;
        Measure.Method(() =>
        {
            call_count++;
            Thread.Sleep(1);
        }).Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 1);
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, MethodMeasurement.k_MeasurementCount);
        Assert.IsTrue(AllSamplesHigherThan0(test));
        Assert.Greater(call_count, 9);
    }

    [Test, Performance]
    public void MeasureMethod_With_MeasurementCount()
    {
        var s_CallCount = 0;
        Measure.Method(() => { s_CallCount++; })
            .MeasurementCount(10)
            .Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 1);
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, 10);
        Assert.AreEqual(10, s_CallCount);
    }

    [Test, Performance]
    public void MeasureMethod_With_MeasurementCountAndSetupCleanup()
    {
        var s_CallCount = 0;
        Measure.Method(() => { s_CallCount++; })
            .MeasurementCount(10)
            .SetUp(() => s_CallCount++)
            .CleanUp(() => s_CallCount++)
            .Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 1);
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, 10);
        Assert.AreEqual(30, s_CallCount);
    }

    [Test, Performance]
    public void MeasureMethod_With_MeasurementCountAndSetup()
    {
        var s_CallCount = 0;
        Measure.Method(() => { })
            .MeasurementCount(10)
            .SetUp(() => s_CallCount++)
            .Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, 10);
        Assert.AreEqual(10, s_CallCount);
    }

    [Test, Performance]
    public void MeasureMethod_With_MeasurementCountAndCleanup()
    {
        var s_CallCount = 0;
        Measure.Method(() => { })
            .MeasurementCount(10)
            .CleanUp(() => s_CallCount++)
            .Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, 10);
        Assert.AreEqual(10, s_CallCount);
    }

    [Test, Performance]
    public void MeasureMethod_With_MeasurementCountAndIterationCount()
    {
        var watch = new FakeWatch();

        var s_CallCount = 0;
        Measure.Method(() =>
            {
                s_CallCount++;
                watch.Sample = s_CallCount;
            })
            .StopWatch(watch)
            .WarmupCount(10)
            .MeasurementCount(10)
            .IterationsPerMeasurement(5)
            .Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 1);
        Assert.AreEqual(test.SampleGroups[0].Samples.Count, 10);
        Assert.AreEqual(test.SampleGroups[0].Samples[0], 5D, 0.1D);
        Assert.AreEqual(100, s_CallCount);
    }

    [Test, Performance]
    public void MeasureMethod_With_GarbageCollectionMarker()
    {
        Measure.Method(() => { }).GC().Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 2);
        Assert.AreEqual(test.SampleGroups[0].Name, "Time.GC()");
        Assert.IsTrue(LessThanOne(test.SampleGroups[0]));
    }

    [Test, Performance]
    public void MeasureMethod_With_EmptyProfilerMarkers()
    {
        Measure.Method(() => { }).ProfilerMarkers("empty").Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 1);
    }

    [Test, Performance]
    public void MeasureMethod_With_ValidProfilerMarkers()
    {
        Measure.Method(() => { MeasureProfilerSamplesTests.CreatePerformanceMarker("loop", 1); })
            .ProfilerMarkers("loop").Run();

        var test = PerformanceTest.Active;
        Assert.AreEqual(test.SampleGroups.Count, 2);
        Assert.AreEqual(test.SampleGroups[0].Name, "Time");
        Assert.AreEqual(test.SampleGroups[1].Name, "loop");
    }

    private static bool AllSamplesHigherThan0(PerformanceTest test)
    {
        foreach (var sampleGroup in test.SampleGroups)
        {
            foreach (var sample in sampleGroup.Samples)
            {
                if (sample <= 0) return false;
            }
        }

        return true;
    }

    private static bool LessThanOne(SampleGroup sampleGroup)
    {
        foreach (var sample in sampleGroup.Samples)
        {
            if (sample > 1f)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Implementation of IStopWatch used to track call counts in tests
    /// </summary>
    private class FakeWatch : IStopWatch
    {
        public double Sample = 0D;

        public void Start()
        {
        }

        public double Split()
        {
            return Sample;
        }
    }
}