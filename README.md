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