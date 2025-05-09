# MsTest Static Scope Experiement

This experiment consists of two test assemblies and one shared project. The goal is to determine what extent static variables are shared between test runs.

All tests are run with [DoNotParallelize] to force determinstic order.

After running, it is clear that static variables are shared between test classes in a test assembly, but not across assembly boundaries. 

```
5/7/2025 7:45:05 PM - Before TestOneB: 
5/7/2025 7:45:05 PM - After TestOneB: TestOneB
5/7/2025 7:45:05 PM - Before TestOneOtherA: TestOneB
5/7/2025 7:45:05 PM - After TestOneOtherA: TestOneOtherA
5/7/2025 7:45:05 PM - Before TestOneA: TestOneOtherA
5/7/2025 7:45:05 PM - After TestOneA: TestOneA
5/7/2025 7:45:05 PM - Before TestOneOtherB: TestOneA
5/7/2025 7:45:05 PM - After TestOneOtherB: TestOneOtherB
5/7/2025 7:45:06 PM - Before TestTwoB: 
5/7/2025 7:45:06 PM - After TestTwoB: TestTwoB
5/7/2025 7:45:06 PM - Before TestTwoA: TestTwoB
5/7/2025 7:45:06 PM - After TestTwoA: TestTwoA
5/7/2025 7:45:06 PM - Before TestTwoA: TestTwoA
5/7/2025 7:45:06 PM - After TestTwoA: TestTwoA
5/7/2025 7:45:06 PM - Before TestTwoB: TestTwoA
5/7/2025 7:45:06 PM - After TestTwoB: TestTwoB
```

# Isolation

One way to get isolation is to load the static class into an isolated AssemblyLoadContext and proxy all calls to static variables through the assembly load context. 
After doing that, you can see calls to the same variable are isolated between a test using AssemblyLoadContext and one not using AssemblyLoadContext.

In the results below, "OneIsolatedTests" is using AssemblyLoadContext and "TwoIsolatedTests" is using the static varible from the Default AssemblyLoadContext. 
The test classes no longer share static state, but the individual test methods in the test class still share state.

```
5/9/2025 12:53:04 PM - Before MstestStaticScope.Isolated.Tests.OneIsolatedTests.TestOneIsolatedA: 
5/9/2025 12:53:04 PM - After MstestStaticScope.Isolated.Tests.OneIsolatedTests.TestOneIsolatedA: TestOneIsolatedA
5/9/2025 12:53:04 PM - Before MstestStaticScope.Isolated.Tests.OneIsolatedTests.TestOneIsolatedB: TestOneIsolatedA
5/9/2025 12:53:04 PM - After MstestStaticScope.Isolated.Tests.OneIsolatedTests.TestOneIsolatedB: TestOneIsolatedB
5/9/2025 12:53:04 PM - Before MstestStaticScope.Isolated.Tests.TwoIsolatedTests.TestTwoIsolatedA: 
5/9/2025 12:53:04 PM - After MstestStaticScope.Isolated.Tests.TwoIsolatedTests.TestTwoIsolatedA: TestTwoIsolatedA
5/9/2025 12:53:04 PM - Before MstestStaticScope.Isolated.Tests.TwoIsolatedTests.TestTwoIsolatedB: TestTwoIsolatedA
5/9/2025 12:53:04 PM - After MstestStaticScope.Isolated.Tests.TwoIsolatedTests.TestTwoIsolatedB: TestTwoIsolatedB
```