using System.Runtime.CompilerServices;
using MstestStaticScope.Shared;

namespace MstestStaticScope.Isolated.Tests;

[DoNotParallelize]
[TestClass]
public sealed class TwoIsolatedTests
{
    [TestMethod]
    public void TestTwoIsolatedA()
    {
        LogBefore();
        StaticClass.State = nameof(TestTwoIsolatedA);
        LogAfter();
    }

    [TestMethod]
    public void TestTwoIsolatedB()
    {        
        LogBefore();
        StaticClass.State =  nameof(TestTwoIsolatedB);
        LogAfter();
    }

    private void LogBefore([CallerMemberName]string methodName=null)
    {
        Console.WriteLine($"{DateTime.UtcNow} - Before {typeof(TwoIsolatedTests).FullName}.{methodName}: {StaticClass.State}");
    }

    private void LogAfter([CallerMemberName]string methodName=null)
    {
        Console.WriteLine($"{DateTime.UtcNow} - After {typeof(TwoIsolatedTests).FullName}.{methodName}: {StaticClass.State}");
    }
}