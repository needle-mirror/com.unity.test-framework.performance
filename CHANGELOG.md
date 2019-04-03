# Changelog


## [0.1.27] - 2018-5-31

### Add meta files to npm ignore

## [0.1.26] - 2018-5-31

### Preparing package for moving to public registry

Inversed changelog order
Excluded CI files from published package


## [0.1.25] - 2018-5-31

### Remove missing meta files


## [0.1.24] - 2018-5-31

### Print out json to xml by default for backwards compatability


## [0.1.23] - 2018-5-30

### Issues with packman, bumping up version

Issues with packman, bumping up version


## [0.1.22] - 2018-5-29

### Measure.Method Execution and Warmup count

Can now specify custom execution and warmup count


## [0.1.21] - 2018-5-25

### Fix issues introduced by .18 fix


## [0.1.19] - 2018-5-24

### Rename package

Package has been renamed to `com.unity.test-framework.performance` to match test framework


## [0.1.18] - 2018-5-24

### Fix SetUp and TearDown for 2018.1


## [0.1.17] - 2018-5-23

### Meatada collecting and changes to method/frames measurements

Refactor Method and Frames measurements
Metadata collected using internal test runner API and player connection for 2018.3+


## [0.1.16] - 2018-5-09

### Bug fix

Bug fix regarding measureme methods being disposed twice


## [0.1.15] - 2018-5-02

### Bug fix for metadata test

The test was failing if a json file was missing for playmode tests


## [0.1.14] - 2018-4-30

### Measure method refactor

Introduced SampleGroupDefinition
Addition of measuring a method or frames for certain amount of times or for duration
Refactored measuring methods
Removes linq usage for due to issues with AOT platforms


## [0.1.13] - 2018-4-15

### Updates to aggregation and metadata for android

Fixed android metadata collecting
Removed totaltime from frametime measurements
Added total, std and sample count aggregations
Added sample unit to multi sample groups


## [0.1.12] - 2018-4-11

### Change naming and fix json serialization


## [0.1.11] - 2018-4-09

### Fix 2018.1 internal namespaces

Fix 2018.1 internal namespaces


## [0.1.10] - 2018-4-09

### Collect metadata and update coding style

Change fields to UpperCamelCase
Added editmode and playmode tests that collect metadata


## [0.1.9] - 2018-4-06

### Add json output for 2018.1

After test run, we will now print json output


## [0.1.8] - 2018-4-03

### Fix for 2018.1

Fix an exception on 2018.1


## [0.1.7] - 2018-4-03

### improvements to overloads and documentation

Changed some of the names to match new convention
Addressed typos in docs
Multiple overloads replaced by using default arguments


## [0.1.6] - 2018-3-28

### improvements to overloads and documentation

Measure.Custom got a new overload with SampleGroup
Readme now includes installation and more examples


## [0.1.5] - 2018-3-20

### Adding checks for usage outside of Performance tests

Adding checks for usage outside of Performance tests


## [0.1.4] - 2018-3-20

### Adding system info to performance test output

Preparing for reporting test data


## [0.1.3] - 2018-03-14

### Removed tests

Temporarily removing tests from the package into separate repo.


## [0.1.2] - 2018-03-14

### Bug fix

Update for a missing bracket


## [0.1.1] - 2018-03-14

### Updates to test results and measurement methods

Test output now includes json that can be used to parse performance data from TestResults.xml
Added defines to be compatible with 2018.1 and newer
Removed unnecessary overloads for measurements due to introduction of SampleGroup
Measurement methods can now take in SampleGroup as argument.


## [0.1.0] - 2018-02-27

### This is the first release of *Unity Package performancetesting*.

Initial version.